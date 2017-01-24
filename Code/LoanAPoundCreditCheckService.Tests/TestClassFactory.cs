using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanAPoundCreditCheckService.Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoanAPoundCreditCheckService.Tests
{
    [TestClass]
    public class TestClassFactory
    {
        [TestMethod]
        public void TestCreationExperianCreditScoreServiceObject_Valid()
        {
            // Arrange
            CreditScoreServiceFactory creditCheckServiceFactory = new CreditScoreServiceFactory();
            int creditCheckId = (int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.ExperianCreditCheckIndex; 

            // Act
            ICreditScoreService creditCheckProcessor = creditCheckServiceFactory.GetCreditScoreProvider(creditCheckId);

            // Assert
            Assert.IsNotNull(creditCheckProcessor);
            Assert.IsInstanceOfType(creditCheckProcessor, typeof(ExperianCreditCheck));            
        }

        [TestMethod]
        public void TestCreationEquifaxCreditScoreServiceObject_Valid()
        {
            // Arrange
            CreditScoreServiceFactory creditCheckServiceFactory = new CreditScoreServiceFactory();
            int creditCheckId = (int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.EquifaxCreditCheckIndex;

            // Act
            ICreditScoreService creditCheckProcessor = creditCheckServiceFactory.GetCreditScoreProvider(creditCheckId);

            // Assert
            Assert.IsNotNull(creditCheckProcessor);
            Assert.IsInstanceOfType(creditCheckProcessor, typeof(EquifaxCreditCheck));
        }

        [TestMethod]
        public void TestCreationMyCreditMonitorCreditScoreServiceObject_Valid()
        {
            // Arrange
            CreditScoreServiceFactory creditCheckServiceFactory = new CreditScoreServiceFactory();
            int creditCheckId = (int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.MyCreditMonitorIndex;
            
            // Act
            ICreditScoreService creditCheckProcessor = creditCheckServiceFactory.GetCreditScoreProvider(creditCheckId);

            // Assert
            Assert.IsNotNull(creditCheckProcessor);
            Assert.IsInstanceOfType(creditCheckProcessor, typeof(MyCreditMonitor));
        }

        [TestMethod]
        public void TestCreationCreditAngelCreditScoreServiceObject_Valid()
        {
            // Arrange
            CreditScoreServiceFactory creditCheckServiceFactory = new CreditScoreServiceFactory();
            int creditCheckId = (int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.CreditAngelIndex;

            // Act
            ICreditScoreService creditCheckProcessor = creditCheckServiceFactory.GetCreditScoreProvider(creditCheckId);

            // Assert
            Assert.IsNotNull(creditCheckProcessor);
            Assert.IsInstanceOfType(creditCheckProcessor, typeof(CreditAngel));
        }

        [TestMethod]
        public void TestCreationCreditScoreServiceObject_InValid()
        {
            // Arrange
            CreditScoreServiceFactory creditCheckServiceFactory = new CreditScoreServiceFactory();
            int invalidCreditCheckId = 999;

            // Act
            ICreditScoreService creditCheckProcessor = creditCheckServiceFactory.GetCreditScoreProvider(invalidCreditCheckId);

            // Assert
            Assert.IsNull(creditCheckProcessor);
        }

    }
}
