using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    public class Rent
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public double RentPrice { get; set; }

        public Rent()
        {}

        public Rent(int id, DateTime rentDate, double rentPrice)
        {
            Id = id;
            RentDate = rentDate;
            RentPrice = rentPrice;
        }
    }
}
