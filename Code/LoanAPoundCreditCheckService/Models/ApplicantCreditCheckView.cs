using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LoanAPoundCreditCheckService.Models
{
    public class ApplicantCreditCheckView
    {
        public Applicant applicant;
        public IEnumerable<string> SelectedCreditCheckProvider { get; set; }
        public IEnumerable<SelectListItem> CreditCheckProviders { get; set; }
    }
}
