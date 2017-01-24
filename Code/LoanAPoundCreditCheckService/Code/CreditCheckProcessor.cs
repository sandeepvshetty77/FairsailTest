using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoanAPoundCreditCheckService.Models;

namespace LoanAPoundCreditCheckService.Code
{
    public class CreditCheckProcessor
    {
        private LoanAPoundDataEntities db = new LoanAPoundDataEntities();

        public CreditCheckProcessor()
        {
        }

        public ApplicantCreditCheckResults GetCreditCheckResults(int applicantID, IEnumerable<string> selectedCreditCheckProvider)
        {           
            // Validating input parameters
            if (applicantID < 0 || selectedCreditCheckProvider == null || selectedCreditCheckProvider.Count() <= 0)
                return null;

            Applicant applicant = db.Applicants.Find(applicantID);

            if (applicant == null)
                return null;

            // Get the Credit Scores by Credit Score Providers  ( Credit Score Provider1 <-> Credit Score)
            //                                                  ( Credit Score Provider2 <-> Credit Score)
            //                                                  ( Credit Score Provider3 <-> Credit Score)
            //                                                                      ...
            // This will call the Credit Score Provider specific class to get the credit scores.
            Dictionary<int, int> creditCheckScoreByCreditCheckProvider = GetCheckScoreByCreditCheckProvider(applicant, 
                                                                                                            selectedCreditCheckProvider);

            // At this stage we can update the ApplicantCreditCheckScore table but 
            // not needed for the purposes of this excerise. But in implementation of the whole application
            // the update to table ApplicantCreditCheckScore will be done at this stage.
            UpdateApplicantCreditCheckScore(applicant.ApplicantID, creditCheckScoreByCreditCheckProvider);

            //
            // Fill the ApplicantCreditCheckResults class with the Applicant details and the credit score 
            // so that it can be displayed in the view
            //
            ApplicantCreditCheckResults applnCreditCheckResults = null;
            if (creditCheckScoreByCreditCheckProvider != null && creditCheckScoreByCreditCheckProvider.Count() > 0)
            {
                applnCreditCheckResults = FillApplicantCreditCheckResults(applicant, creditCheckScoreByCreditCheckProvider);
            }
            
            return applnCreditCheckResults;
        }

        private void UpdateApplicantCreditCheckScore(int applicantID, Dictionary<int, int> creditCheckScoreByCreditCheckProvider)
        {
            /*foreach(var item in creditCheckScoreByCreditCheckProvider)
            {
                ApplicantCreditCheckScore appCreditCheckScores = 
                appCreditCheckScores = 
                    db.ApplicantCreditCheckScores.Where( m => m.ApplicantID == applicantID && m.CreditCheckProviderID == item.Key).FirstOrDefault(); 
                if (null == appCreditCheckScores)
                {
                    appCreditCheckScores = new ApplicantCreditCheckScore();
                    appCreditCheckScores.ApplicantID = applicantID;
                    appCreditCheckScores.CreditCheckProviderID = item.Key;
                    appCreditCheckScores.CreditScore = item.Value;
                    db.ApplicantCreditCheckScores.Add(appCreditCheckScores);
                    db.SaveChanges();
                }
            }
            */
        }

        //
        // Get the Credit Scores by Credit Score Providers  ( Credit Score Provider1 <-> Credit Score)
        //                                                  ( Credit Score Provider2 <-> Credit Score)
        //                                                  ( Credit Score Provider3 <-> Credit Score)
        //                                                                      ...
        //
        private Dictionary<int, int> GetCheckScoreByCreditCheckProvider(Applicant applicant, IEnumerable<string> selectedCreditCheckProvider)
        {
            Dictionary<int, int> creditCheckScoreByCreditCheckProvider = null;
            CreditScoreServiceFactory creditCheckServiceFactory = new CreditScoreServiceFactory();
            foreach (string creditCheckId in selectedCreditCheckProvider)
            {
                int nCreditCheckId = int.Parse(creditCheckId);
                ICreditScoreService creditCheckService = creditCheckServiceFactory.GetCreditScoreProvider(int.Parse(creditCheckId));
                if (creditCheckService != null)
                {
                    int creditScore = creditCheckService.GetCreditScore(applicant);

                    if (creditCheckScoreByCreditCheckProvider == null)
                    {
                        creditCheckScoreByCreditCheckProvider = new Dictionary<int, int>();
                    }
                    creditCheckScoreByCreditCheckProvider.Add(nCreditCheckId, creditScore);
                }
            }

            return creditCheckScoreByCreditCheckProvider;
        }

        //
        // Fill the ApplicantCreditCheckResults class with the Applicant details and the credit score so that it can be displayed
        //
        private ApplicantCreditCheckResults FillApplicantCreditCheckResults(Applicant applicant, Dictionary<int, int> creditCheckScoreByCreditCheckProvider)
        {
            ApplicantCreditCheckResults applnCreditCheckResults = new ApplicantCreditCheckResults();
            applnCreditCheckResults.ApplicantID = applicant.ApplicantID;
            applnCreditCheckResults.ApplicantName = applicant.ApplicantFirstName + " " + applicant.ApplicantLastName;

            applnCreditCheckResults.CreditScoresByCreditCheckProvider = new Dictionary<string, int>();
            foreach (var item in creditCheckScoreByCreditCheckProvider)
            {
                int creditScore = item.Value;
                string creditCheckProviderName = GetCreditCheckProviderName(item.Key);
                if (!String.IsNullOrEmpty(creditCheckProviderName))
                {
                    applnCreditCheckResults.CreditScoresByCreditCheckProvider.Add(creditCheckProviderName, creditScore);
                }
            }

            return applnCreditCheckResults;
        }

        private string GetCreditCheckProviderName(int creditCheckProviderID)
        {
            string creditCheckProviderName = null;
            CreditCheckProvider creditCheckProvider = db.CreditCheckProviders.Find(creditCheckProviderID);
            if (creditCheckProvider != null)
            {
                creditCheckProviderName = creditCheckProvider.Name;
            }

            return creditCheckProviderName;
        }
    }
}