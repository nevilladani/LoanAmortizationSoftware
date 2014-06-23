using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loanAmortization
{
    // Class to define object for arrayList storing EMI table in class LoanValue Table
    class ArrayDataView
    {
        private int payNumber;
        private double principleFrac;
        private double interestFrac;
        private double remainingAmt;
        private double remainingP;

        public ArrayDataView(int payNum, double principleF, double interestF, double remAmt, double remP) 
        {
            this.payNumber = payNum;
            this.principleFrac = principleF;
            this.interestFrac = interestF;
            this.remainingAmt = remAmt;
            this.remainingP = remP;

        }
        public int PayNumber
        {
            get { return payNumber; }
        }
        public double PrincipleFrac
        {
            get { return principleFrac; }
        }
        public double InterestFrac
        {
            get { return interestFrac; }
        }
        public double RemainingAmt
        {
            get { return remainingAmt; }
        }
        public double RemainingP
        {
            get { return remainingP; }
        }
 

    }
}
