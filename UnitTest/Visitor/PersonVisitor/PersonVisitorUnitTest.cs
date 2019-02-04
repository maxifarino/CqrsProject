using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GAP.CqrsCore.Commands;
using GAP.CqrsCore.Querys;
using Microsoft.Practices.ServiceLocation;
using GAP.Infraestructure;
using GAP.Cqrs.Implementation.Command;
using GAP.Domain.Entities;
using GAP.Cqrs.Implementation.Query;
using GAP.Cqrs.Implementation.QueryResult;
using Moq;
using GAP.Visitor.Implementation.Visitor;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.ServicePerson.ServiceBusinessStructure;
using GAP.Cqrs.Implementation.QueryResult.EntidadQuery;

namespace UnitTest.Visitor.PersonVisitor
{

    [TestClass]
    public class PersonVisitorUnitTest : UnitTestBase
    {

        private Mock<RepositoryLocalScheme> _mockedRepository;
        private Mock<VisitorPersonSave> _mockedVisitorPersonSave;
        private Mock<VisitorPersonUpdate> _mockedVisitorPersonUpdate;
        private PersonServiceBusiness _personServiceBusiness;


        public override void Initialize()
        {
            _mockedRepository = new Mock<RepositoryLocalScheme>();
            _mockedVisitorPersonSave = new Mock<VisitorPersonSave>(_mockedRepository.Object) { CallBase = true };
            _mockedVisitorPersonUpdate = new Mock<VisitorPersonUpdate>(_mockedRepository.Object);
        }


        [TestMethod]
        public void Validate_Person_Success()
        {

            //var query = new EntidadByFiltersQuery() { NombreFantasia = "maxi", RazonSocial = "dsad", Cuit = "654", FormaJuridicaId = 0 };
            //var result = _QueryDispatcher.Dispatch<EntidadByFiltersQuery, EntidadByFiltersQueryResult>(query);

            var persona = new Person() { Name = "Maximiliano" };
            _mockedVisitorPersonSave.Setup(x => x.existPersonByNombre(It.IsAny<string>())).Returns(false);

            _personServiceBusiness = new PersonServiceBusiness(_mockedVisitorPersonSave.Object, _mockedVisitorPersonUpdate.Object);
            _result = _personServiceBusiness.ValidateSave(persona);

            Assert.AreEqual(true, _result.success);
        }

        [TestMethod]
        public void Validate_Person_with_Error_exist_Person()
        {
            var persona = new Person() { Name = "Maximiliano" };
            _mockedVisitorPersonSave.Setup(x => x.existPersonByNombre(It.IsAny<string>())).Returns(true);

            _personServiceBusiness = new PersonServiceBusiness(_mockedVisitorPersonSave.Object, _mockedVisitorPersonUpdate.Object);
            _result = _personServiceBusiness.ValidateSave(persona);

            Assert.AreEqual(false, _result.success);
        }


        [TestMethod]
        public void Validate_Person_with_Error_of_Name()
        {
            var persona = new Person() { Id = 1, Name = string.Empty };

            _personServiceBusiness = new PersonServiceBusiness(_mockedVisitorPersonSave.Object, _mockedVisitorPersonUpdate.Object);
            _result = _personServiceBusiness.ValidateSave(persona);

            Assert.AreEqual(false, _result.success);
        }

    }
}
