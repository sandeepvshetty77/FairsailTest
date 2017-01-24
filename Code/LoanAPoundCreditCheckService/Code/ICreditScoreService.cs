using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanAPoundCreditCheckService.Models;

namespace LoanAPoundCreditCheckService.Code
{
    public interface ICreditScoreService
    {
        int GetCreditScore(Applicant applicant);
    }
}
