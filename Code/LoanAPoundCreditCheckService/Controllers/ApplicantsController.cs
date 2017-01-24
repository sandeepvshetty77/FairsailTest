using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LoanAPoundCreditCheckService.Models;
using LoanAPoundCreditCheckService.Code;

namespace LoanAPoundCreditCheckService.Controllers
{
    public class ApplicantsController : Controller
    {
        private LoanAPoundDataEntities db = new LoanAPoundDataEntities();
        //
        // GET: /Applicant/
        public ActionResult Index()
        {
            return View(db.Applicants.ToList());
        }

        
        [HttpPost]
        public ActionResult Details(int id, IEnumerable<string> SelectedCreditCheckProvider) 
        {

            CreditCheckProcessor creditCheckProcessor = new CreditCheckProcessor();
            ApplicantCreditCheckResults applnCreditCheckResults = creditCheckProcessor.GetCreditCheckResults(id, SelectedCreditCheckProvider);

            if (applnCreditCheckResults == null)
            {
                // Display error on the page
                @ViewBag.Message = "There was some error in getting the credit score";

                // Keep the control on the same page
                return Details(id);
            }
            else
                return View("CreditCheckResults", applnCreditCheckResults); // display the credit scores
        }

        //
        // GET: /Applicant/Details/5
        public ActionResult Details(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();

            foreach (CreditCheckProvider creditcheckprov in db.CreditCheckProviders)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = creditcheckprov.Name,
                    Value = creditcheckprov.CreditCheckProviderID.ToString(),
                };
                listSelectListItems.Add(selectList);
            }

            ApplicantCreditCheckView appcreditCheckView = new ApplicantCreditCheckView()
            {
                applicant = applicant,
                CreditCheckProviders = listSelectListItems
            };

            return View(appcreditCheckView);
        }
        
    }
}
