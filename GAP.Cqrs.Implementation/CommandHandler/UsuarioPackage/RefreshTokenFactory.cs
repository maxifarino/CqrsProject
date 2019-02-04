using GAP.Base;
using GAP.Base.Dto.Seguridad;
using GAP.Base.Exceptions;
using GAP.Cqrs.Implementation.CommandHandler.UsuarioPackage;
using GAP.Domain.Entities.Seguridad;
using GAP.Repository.LocalScheme;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.Command.UsuarioPackage
{
    public class RefreshTokenFactory : IRefreshTokenFactory
    {
        
        private readonly RepositoryLocalScheme _repositryLocalScheme;

        private string _PACKAGE_NAME = GlobalVars.PackageName;

        public RefreshTokenFactory()
        {
            _repositryLocalScheme = new RepositoryLocalScheme();
        }

        public Cliente FindClient(string clientId)
        {
            var querysession = _repositryLocalScheme.Session.CallFunction<ClienteDto>( _PACKAGE_NAME + "PR_GET_CLIENTE(?)")

            .SetParameter(0, clientId);

            List<ClienteDto> clientes = (List<ClienteDto>)querysession.List<ClienteDto>();

            ClienteDto cliente = clientes[0];

            ApplicationTypes appType = new ApplicationTypes();
            if ((int) ApplicationTypes.JavaScript == (cliente.ApplicationTypeId))
            {
                appType = ApplicationTypes.JavaScript;
            }
            else if ((int)ApplicationTypes.NativeConfidential == (cliente.ApplicationTypeId))
            {
                appType = ApplicationTypes.NativeConfidential;
            }

            return new Cliente
            {
                Id = cliente.IdCliente,
                Secret = cliente.Secret,
                Name = cliente.Name,
                ApplicationType = appType,
                Active = cliente.Active.Equals("S"),
                RefreshTokenLifeTime = cliente.RefreshTokenLifeTime,
                AllowedOrigin = cliente.AllowedOrigin
            };
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {
            
               var querysession = _repositryLocalScheme.Session.CallFunction<RefreshTokenDto>(_PACKAGE_NAME + "PR_GET_REFRESH_TOKEN_BY_SUB(?,?)")
                .SetParameter(0, token.ClientId)
                .SetParameter(1, token.Subject);

                List<RefreshTokenDto> refreshTokenList = (List<RefreshTokenDto>)querysession.List<RefreshTokenDto>();

                if (refreshTokenList != null && refreshTokenList.Any())
                {
                    var result = await RemoveRefreshToken(refreshTokenList[0].IdRefreshToken);
                }

                var insert = _repositryLocalScheme.Session.CallFunction( _PACKAGE_NAME + "PR_INSERT_REFRESH_TOKEN(?,?,?,?,?,?)")
                .SetParameter(0, token.Id)
                .SetParameter(1, token.Subject)
                .SetParameter(2, token.ClientId)
                .SetParameter(3, token.IssuedUtc)
                .SetParameter(4, token.ExpiresUtc)
                .SetParameter(5, token.ProtectedTicket);

                insert.UniqueResult();          
            
            return true; 
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
             if (String.IsNullOrEmpty(refreshTokenId))
                {
                    return false;
                }
                var insert = _repositryLocalScheme.Session.CallFunction( _PACKAGE_NAME + "PR_DELETE_REFRESH_TOKEN(?)")
                .SetParameter(0, refreshTokenId);

                insert.UniqueResult();
                return true;                       
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
           
                if (refreshToken == null || String.IsNullOrEmpty(refreshToken.Id))
                {
                    return false;
                }
                var insert = _repositryLocalScheme.Session.CallFunction( _PACKAGE_NAME + "PR_DELETE_REFRESH_TOKEN(?)")
                .SetParameter(0, refreshToken.Id);

                insert.UniqueResult();
                return true;           
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var querysession = _repositryLocalScheme.Session.CallFunction<RefreshTokenDto>( _PACKAGE_NAME + "PR_GET_REFRESH_TOKEN(?)")
                
                    .SetParameter(0, refreshTokenId);
                List<RefreshTokenDto> refreshTokenList = (List<RefreshTokenDto>)querysession.List<RefreshTokenDto>();

                if (refreshTokenList != null && refreshTokenList.Any())
                {
                    RefreshTokenDto refreshTokenDto = refreshTokenList[0];

                    return new RefreshToken
                    {
                        Id = refreshTokenDto.IdRefreshToken,
                        Subject = refreshTokenDto.Subject,
                        ClientId = refreshTokenDto.ClientId,
                        IssuedUtc = refreshTokenDto.IssuedUtc,
                        ExpiresUtc = refreshTokenDto.ExpiresUtc,
                        ProtectedTicket = refreshTokenDto.ProtectedTicket,
                    };
                }            
           
            return null;
        }
        

    }
}
