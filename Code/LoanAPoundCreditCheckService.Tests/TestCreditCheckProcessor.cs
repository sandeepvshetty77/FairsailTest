using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanAPoundCreditCheckService.Code;
using LoanAPoundCreditCheckService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoanAPoundCreditCheckService.Tests
{
    [TestClass]
    public class TestCreditCheckProcessor
    {
        private Applicant GetFakeApplicant()
        {
            return new Applicant()
            {
                ApplicantID = 1,
                ApplicantFirstName = "Sherlock",
                ApplicantLastName = "Holmes",
                Address = "221 Baker Street",
                AnnualSalary = 50000,
                NI_Number = "SH007P",
                Email = "SherlockHolmes@TheUnknown.com"
            };
        }

        private IEnumerable<string> GetListOfCreditCheckProviders(int index)
        {
            string creditCheckIndex = index.ToString();
            IEnumerable<string> selectedCreditCheckProvider = new List<string>() { creditCheckIndex };
            return selectedCreditCheckProvider;
        }


        [TestMethod]
        public void TestGetCheckScoreByCreditCheckProvider_ForExperianCreditCheckProvider()
        {
            // Arrange
            Applicant applicant = GetFakeApplicant();

            int index = (int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.ExperianCreditCheckIndex;
            string creditCheckIndex = index.ToString();
            IEnumerable<string> selectedCreditCheckProvider = new List<string>() { creditCheckIndex };

            // Act
            CreditCheckProcessor creditCheckProcessor = new CreditCheckProcessor();
            PrivateObject obj = new PrivateObject(creditCheckProcessor);
            Dictionary<int, int> creditCheckScoreByCreditCheckProvider = (Dictionary<int, int>)obj.Invoke("GetCheckScoreByCreditCheckProvider", applicant, selectedCreditCheckProvider);


            // Assert
            //
            // Check if the credit check provider is present in the dictionary
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsKey((int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.ExperianCreditCheckIndex));

            // Check if the credit score provided by the credit check providers is present in the dictionary
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsValue(550));

        }

        [TestMethod]
        public void TestGetCheckScoreByCreditCheckProvider_ForEquifaxCreditCheckProvider()
        {
            // Arrange
            Applicant applicant = GetFakeApplicant();
            IEnumerable<string> selectedCreditCheckProvider
                    = GetListOfCreditCheckProviders((int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.EquifaxCreditCheckIndex);

            // Act
            CreditCheckProcessor creditCheckProcessor = new CreditCheckProcessor();
            PrivateObject obj = new PrivateObject(creditCheckProcessor);
            Dictionary<int, int> creditCheckScoreByCreditCheckProvider = (Dictionary<int, int>)obj.Invoke("GetCheckScoreByCreditCheckProvider", applicant, selectedCreditCheckProvider);

            // Assert
            //
            // Check if the credit check provider is present in the dictionary
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsKey((int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.EquifaxCreditCheckIndex));

            // Check if the credit score provided by the credit check providers is present in the dictionary
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsValue(600));

        }

        [TestMethod]
        public void TestGetCheckScoreByCreditCheckProvider_ForMyCreditMonitorCreditCheckProvider()
        {
            // Arrange
            Applicant applicant = GetFakeApplicant();
            IEnumerable<string> selectedCreditCheckProvider
                    = GetListOfCreditCheckProviders((int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.MyCreditMonitorIndex);

            // Act
            CreditCheckProcessor creditCheckProcessor = new CreditCheckProcessor();
            PrivateObject obj = new PrivateObject(creditCheckProcessor);
            Dictionary<int, int> creditCheckScoreByCreditCheckProvider = (Dictionary<int, int>)obj.Invoke("GetCheckScoreByCreditCheckProvider", applicant, selectedCreditCheckProvider);

            // Assert
            //
            // Check if the credit check provider is present in the dictionary
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsKey((int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.MyCreditMonitorIndex));

            // Check if the credit score provided by the credit check providers is present in the dictionary
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsValue(700));

        }

        [TestMethod]
        public void TestGetCheckScoreByCreditCheckProvider_ForCreditAngelProvider()
        {
            // Arrange
            Applicant applicant = GetFakeApplicant();

            IEnumerable<string> selectedCreditCheckProvider
                   = GetListOfCreditCheckProviders((int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.CreditAngelIndex);

            // Act
            CreditCheckProcessor creditCheckProcessor = new CreditCheckProcessor();
            PrivateObject obj = new PrivateObject(creditCheckProcessor);
            Dictionary<int, int> creditCheckScoreByCreditCheckProvider = (Dictionary<int, int>)obj.Invoke("GetCheckScoreByCreditCheckProvider", applicant, selectedCreditCheckProvider);


            // Assert
            //
            // Check if the credit check provider is present in the dictionary
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsKey((int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.CreditAngelIndex));

            // Check if the credit score provided by the credit check providers is present in the dictionary
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsValue(650));

        }

        [TestMethod]
        public void TestGetCheckScoreByCreditCheckProvider_ForAllProviders()
        {
            // Arrange
            Applicant applicant = GetFakeApplicant();

            int index = (int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.ExperianCreditCheckIndex;
            string creditCheckIndex = index.ToString();
            index = (int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.EquifaxCreditCheckIndex;
            string creditCheckIndex1 = index.ToString();
            index = (int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.MyCreditMonitorIndex;
            string creditCheckIndex2 = index.ToString();
            index = (int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.CreditAngelIndex;
            string creditCheckIndex3 = index.ToString();

            IEnumerable<string> selectedCreditCheckProvider = new List<string>() {  creditCheckIndex,
                                                                                    creditCheckIndex1,
                                                                                    creditCheckIndex2,
                                                                                    creditCheckIndex3};


            // Act
            CreditCheckProcessor creditCheckProcessor = new CreditCheckProcessor();
            PrivateObject obj = new PrivateObject(creditCheckProcessor);
            Dictionary<int, int> creditCheckScoreByCreditCheckProvider = (Dictionary<int, int>)obj.Invoke("GetCheckScoreByCreditCheckProvider", applicant, selectedCreditCheckProvider);


            // Assert
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsKey((int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.CreditAngelIndex));
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsValue(650));
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsKey((int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.ExperianCreditCheckIndex));
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsValue(550));
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsKey((int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.EquifaxCreditCheckIndex));
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsValue(600));
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsKey((int)LoanAPoundCreditCheckService.Code.CreditScoreServiceFactory.enumCreditCheckProviders.MyCreditMonitorIndex));
            Assert.AreEqual(true, creditCheckScoreByCreditCheckProvider.ContainsValue(700));

        }
    }
}
