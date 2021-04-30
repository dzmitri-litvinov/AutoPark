using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    public class Rent
    {
        public DateTime RentDate { get; set; }
        public double RentPrice { get; set; }

        public Rent()
        {}

        public Rent(DateTime rentDate, double rentPrice)
        {
            RentDate = rentDate;
            RentPrice = rentPrice;
        }
    }
}
