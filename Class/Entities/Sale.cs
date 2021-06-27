using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_5.Class
{
    public class Sale
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public double SaleAmount { get; set; }
        public DateTime SaleDate { get; set; }
        public double SubTotal { get; set; }
        public int IdStore { get; set; }

    }
}
