using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanAPoundCreditCheckService.Models
{
    public class ApplicantCreditCheckResults
    {
        public int ApplicantID;
        public string ApplicantName;
        public Dictionary<string, int> CreditScoresByCreditCheckProvider;
    }
}