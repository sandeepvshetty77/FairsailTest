using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAPoundCreditCheckService.Code
{
    interface ICreditScoreServiceFactory
    {
        ICreditScoreService GetCreditScoreProvider(int id);
    }
}
