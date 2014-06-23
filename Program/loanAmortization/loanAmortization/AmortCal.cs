using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loanAmortization
{
    class AmortCal
    {

        public double Cal(float p, int m, float r) // To calculate EMI and return it as "amt"
        {
            
            double amt,mRate,x;
            mRate = r/1200;
            x = Math.Pow((1+mRate),m);
            amt = p*(mRate*x)/(x - 1);
            return amt;
        }
        public List<ArrayDataView> generateTable(double p, int m, double r, double amt) // To generate EMI table
        {
            double remAmt,remP,interest,prinFrac,mRate;
            int payNum;
            mRate = r / 1200;
            remAmt = amt*m;
            remP = p;

            List<ArrayDataView> arrList = new List<ArrayDataView>();

            for (int i =0; i<m; i++)
            {
                payNum = i + 1;
                interest = remP*mRate;
                prinFrac = amt - interest;
                remAmt = remAmt - amt;
                remP = remP - prinFrac;
                arrList.Add(new ArrayDataView(payNum, prinFrac, interest, remAmt, remP));
            }

            return arrList;
        }
    }
}
