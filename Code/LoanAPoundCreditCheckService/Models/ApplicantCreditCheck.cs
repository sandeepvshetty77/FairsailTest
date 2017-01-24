using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanAPoundCreditCheckService.Models
{
    public class ApplicantCreditCheck
    {
        public Applicant applicant;
        public IEnumerable<string> SelectedCreditCheckProvider { get; set; }        
    }
}