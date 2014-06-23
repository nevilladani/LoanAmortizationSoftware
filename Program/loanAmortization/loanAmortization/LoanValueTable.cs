using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loanAmortization
{
    // Class to store the generated EMI table
    class LoanValueTable
    {
        public List<ArrayDataView> loanTable = new List<ArrayDataView>();
        // arrayList of object of class ArrayDataView to store PayNumber, Principle Fraction , Interest Fraction , Remaining Balance,  Remaining Principle;
        
        public LoanValueTable() { }
        public double amt;
        public double total;
        public LoanValueTable(float p,int m, float r)
        {
            AmortCal amr = new AmortCal();
            amt = amr.Cal(p,m,r);
            loanTable = amr.generateTable(p, m, r, amt);
            // Generating EMI table using the method generateTable of class AmortCal . The table is stored in arrayList loanTable
            total = amt * m;
        }
       
    }
}
