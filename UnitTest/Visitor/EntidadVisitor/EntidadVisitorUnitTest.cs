using GAP.Domain.Entities;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServiceEntidad.ServiceBusinessStructure;
using GAP.Visitor.Implementation.Visitor.VisitorsEntidad;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Visitor.EntidadVisitor
{
    [TestClass]
    public class EntidadVisitorUnitTest : UnitTestBase
    {

        private Mock<RepositoryLocalScheme> _mockedRepository;
        private Mock<VisitorEntidadSave> _mockedVisitorEntidadSave;
        private EntidadServiceBusiness _entidadServiceBusiness;


        public override void Initialize()
        {
            _mockedRepository = new Mock<RepositoryLocalScheme>();
            _mockedVisitorEntidadSave = new Mock<VisitorEntidadSave>(_mockedRepository.Object) { CallBase = true };
        }

        [TestMethod]
        public void Validate_Entidad_Success()
        {
            var entidad = new Entidad() {RazonSocial="Sala 1",NombreFantasia="sala A",Cuit="23-32669254-9" };

            //_mockedVisitorEntidadSave.Setup(x => x.AlreadyExistEntidad(It.IsAny<string>())).Returns(false);

            _entidadServiceBusiness = new EntidadServiceBusiness(_mockedVisitorEntidadSave.Object);
            _result = _entidadServiceBusiness.ValidateSave(entidad);

            Assert.AreEqual(true, _result.success);

        }
        
        [TestMethod]
        public void Validate_Entidad_with_Error_exist_Entidad()
        { }


    }
}
