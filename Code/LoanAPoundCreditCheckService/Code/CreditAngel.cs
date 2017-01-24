using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoanAPoundCreditCheckService.Models;

namespace LoanAPoundCreditCheckService.Code
{
    // This class will know how to get the credit score from the "Credit Angel" credit check provider.
    // GetCreditScore() will implement that credit check provider specific code to get the credit score.
    // It may either call a known function in its known dll or call a rest API or any other url to get the score
    // For simplicity sake we return a constant value from GetCreditScore() 
    public class CreditAngel:ICreditScoreService
    {
        public int GetCreditScore(Applicant applicant)
        {
            // The applicant details are passed in so it can pass the neccessary details to the third party crdit check/score provider 
            // and get the score.
            // For simplicity we are not testing or calling the third party provider and returning a hard coded value as if we are getting it 
            //  from the credit check/score provider.
            //
            return 650;
        }
    }
}