using GAP.Base.Exceptions;
using GAP.Domain.Entities.Seguridad;
using GAP.Repository.LocalScheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Cqrs.Implementation.CommandHandler.UsuarioPackage
{
    public class RefreshTokenFactoryMocked : IRefreshTokenFactory
    {
        private static RefreshTokenFactoryMocked instance;

        private RefreshTokenFactoryMocked() 
        {
            listaClientes = new List<Cliente>();

            listaClientes.Add(new Cliente
            {
                Id = "AngularApp",
                Secret = "123123",
                Name = "AngularApp",
                ApplicationType = ApplicationTypes.JavaScript,
                Active = true,
                RefreshTokenLifeTime = 2,
                AllowedOrigin = "*"
            });

            listaClientes.Add(new Cliente
            {
                Id = "Back-end",
                Secret = "123123",
                Name = "Back-end",
                ApplicationType = ApplicationTypes.NativeConfidential,
                Active = true,
                RefreshTokenLifeTime = 14000,
                AllowedOrigin = "*"
            });

            listaTokens = new List<RefreshToken>();
        }

        public static RefreshTokenFactoryMocked Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new RefreshTokenFactoryMocked();
                }
                return instance;
            }
        }


        private readonly RepositoryLocalScheme _repositryLocalScheme;

        private string _PACKAGE_NAME = "PCK_SEGURIDAD_SC.";



        private List<Cliente> listaClientes;

        private List<RefreshToken> listaTokens;


        public Cliente FindClient(string clientId)
        {
            
            foreach (Cliente cliente in listaClientes)
            {
                if (cliente.Id.Equals(clientId))
                {
                    return cliente;
                }
            }
            return null;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {            

            RefreshToken encontrado = null;

            foreach (RefreshToken refreshToken in listaTokens)
            {
                if(refreshToken.ClientId.Equals(token.ClientId) 
                    && refreshToken.Subject.Equals(token.Subject)){

                    encontrado = refreshToken;
                    break;
                }
            }
            if (encontrado != null)
            {
                RemoveRefreshToken(encontrado);
            }

            listaTokens.Add(token);

            return true;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            RefreshToken encontrado = null;

            foreach (RefreshToken refreshToken in listaTokens)
            {
                if (refreshToken.Id.Equals(refreshTokenId))
                {
                    encontrado = refreshToken;
                    break;
                }
            }
            listaTokens.Remove(encontrado);
            return true;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken encontrado = null;

            foreach (RefreshToken refreshTokenAux in listaTokens)
            {
                if (refreshTokenAux.Id.Equals(refreshToken.Id))
                {
                    encontrado = refreshToken;
                    break;
                }
            }
            listaTokens.Remove(encontrado);
            return true;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            foreach (RefreshToken refreshToken in listaTokens)
            {
                if (refreshToken.Id.Equals(refreshTokenId))
                {
                    return refreshToken;                    
                }
            }
            return null;
        }

       
    }
}
