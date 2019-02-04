using GAP.Base.ResultValidation;
using GAP.Cqrs.Implementation.Command.UsuarioPackage;
using GAP.Cqrs.Implementation.CommandHandler.UsuarioPackage;
using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceBusinessStructure.ServiceUsuario;
using GAP.Visitor.Implementation.Visitor.VisitorsUsuario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Handdler
{
    [TestClass]
    public class UsuarioSaveCommandHandlerTest : UnitTestBase
    {

        private Mock<RepositoryLocalScheme> _mockedRepository;

        private Mock<VisitorUsuarioSave> _mockedVisitorUsuarioSave;
        private Mock<VisitorRolUsuarioSave> _mockedVisitorRolUsuarioSave;
        
        private Mock<UsuarioServiceBusiness> _mockedUsuarioServiceBusiness;
        private Mock<RolServiceBusiness> _mockedRolServiceBusiness;
        private Mock<Result> _mockedResult;
        private UsuarioSaveCommandHandler _usuarioSaveCommandHandler;


        public override void Initialize()
        {
            _mockedRepository = new Mock<RepositoryLocalScheme>();

            _mockedVisitorUsuarioSave = new Mock<VisitorUsuarioSave>(_mockedRepository.Object) { CallBase = true };
            _mockedVisitorRolUsuarioSave = new Mock<VisitorRolUsuarioSave>(_mockedRepository.Object) { CallBase = true };

            _mockedUsuarioServiceBusiness = new Mock<UsuarioServiceBusiness>(_mockedVisitorUsuarioSave.Object) { CallBase = true };
            _mockedRolServiceBusiness = new Mock<RolServiceBusiness>(_mockedVisitorRolUsuarioSave.Object) { CallBase = true };

            _usuarioSaveCommandHandler = new UsuarioSaveCommandHandler(_mockedRepository.Object, _mockedUsuarioServiceBusiness.Object, _mockedRolServiceBusiness.Object);
        }


        /*[TestMethod]
        public void Save_Usuario_Success()
        {
            var usuario = new Usuario();
            usuario.Cuil = "2332669254";
            usuario.rol = 1;

            var command = new UsuarioSaveCommand() { usuario = usuario };
            Result result=_usuarioSaveCommandHandler.Execute(command);

            Assert.AreEqual(false, result.success);
        }*/

        

    }
}
