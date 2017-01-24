using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanAPoundCreditCheckService.Code
{


    public class CreditScoreServiceFactory : ICreditScoreServiceFactory
    {
        public enum enumCreditCheckProviders
        {
            ExperianCreditCheckIndex = 4,
            EquifaxCreditCheckIndex,
            CreditAngelIndex,
            MyCreditMonitorIndex
        };

        public ICreditScoreService GetCreditScoreProvider(int id)
        {
            ICreditScoreService objCreditCheckProcessor = null;

            switch (id)
            {
                case (int)enumCreditCheckProviders.ExperianCreditCheckIndex:
                    objCreditCheckProcessor = new ExperianCreditCheck();
                    break;
                case (int)enumCreditCheckProviders.EquifaxCreditCheckIndex:
                    objCreditCheckProcessor = new EquifaxCreditCheck();
                    break;
                case (int)enumCreditCheckProviders.CreditAngelIndex:
                    objCreditCheckProcessor = new CreditAngel();
                    break;
                case (int)enumCreditCheckProviders.MyCreditMonitorIndex:
                    objCreditCheckProcessor = new MyCreditMonitor();
                    break;
                default:
                    objCreditCheckProcessor = null;
                    break;
            }


            return objCreditCheckProcessor;
        }
    }
}