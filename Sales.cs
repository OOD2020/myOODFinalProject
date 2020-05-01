using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace last_time
{
    public class Sales
    {
        public DateTime Date { get; set; }
        public decimal SalesTotal { get; set; }
        public Sales(DateTime date, decimal salesTotal)
        {
            Date = date;
            SalesTotal = salesTotal;
        }
        public Sales()
        {

        }
    }
}
