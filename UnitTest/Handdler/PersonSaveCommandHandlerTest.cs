using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GAP.Repository.LocalScheme;
using GAP.Visitor.Implementation.Visitor;
using GAP.Cqrs.Implementation.CommandHandler;
using GAP.Cqrs.Implementation.Command;
using GAP.Domain.Entities;
using GAP.Base.ResultValidation;
using GAP.Visitor.Implementation.ServicePerson.ServiceBusinessStructure;

namespace UnitTest.Handdler
{

    [TestClass]
    public class PersonSaveCommandHandlerTest : UnitTestBase
    {

        private Mock<RepositoryLocalScheme> _mockedRepository;
        private Mock<VisitorPersonSave> _mockedVisitorPersonSave;
        private Mock<VisitorPersonUpdate> _mockedVisitorPersonUpdate;
        private Mock<PersonServiceBusiness> _mockedPersonServiceBusiness;
        private Mock<Result> _mockedResult;


        private PersonSaveCommandHandler _personSaveCommandHandler;
        private PersonSaveCommand _personSaveCommand;

        
        public override void Initialize()
        {
            _mockedRepository = new Mock<RepositoryLocalScheme>();
            _mockedVisitorPersonSave = new Mock<VisitorPersonSave>(_mockedRepository.Object);
            _mockedVisitorPersonUpdate = new Mock<VisitorPersonUpdate>(_mockedRepository.Object);
            _mockedPersonServiceBusiness = new Mock<PersonServiceBusiness>(_mockedVisitorPersonSave.Object, _mockedVisitorPersonUpdate.Object);
            _mockedResult = new Mock<Result>();
            _personSaveCommandHandler = new PersonSaveCommandHandler(_mockedPersonServiceBusiness.Object, _mockedRepository.Object);
        }

        [TestMethod]
        public void Save_Person_Success()
        {   
            _mockedPersonServiceBusiness.Setup(x => x.ValidateSave(It.IsAny<Person>())).Returns(_mockedResult.Object);
            _mockedResult.Setup(x => x.HasError()).Returns(false);
            _mockedRepository.Setup(x => x.Create<Person>(It.IsAny<Person>()));

            Assert.AreEqual(true, _mockedResult.Object.success);
        }

        [TestMethod]
        public void Save_Person_NotSuccess()
        {
            _mockedPersonServiceBusiness.Setup(x => x.ValidateSave(It.IsAny<Person>())).Returns(_mockedResult.Object);
            _mockedResult.Setup(x => x.HasError()).Returns(true);

            Assert.AreEqual(false, _mockedResult.Object.success);
        }


    }
}
