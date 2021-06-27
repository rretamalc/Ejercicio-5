using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_5.Class
{
    public class TransactionSale
    {


        private Random Gen = new();
        public List<Sale> GenerateSales()
        {

            List<Sale> Lst=new List<Sale>();
            for (int i = 0; i < 10; i++)
            {
                Lst.Add(new Sale { Id = i, IdClient = Gen.Next(1, 20), SaleAmount = 2000 + Gen.Next(10, 80), SaleDate = RandomDay(), IdStore = Gen.Next(1,3)});
            }

            foreach (var item in Lst)
            {
                Console.WriteLine("Id:{0}, Cliente:{1}, Tienda:{2}, Monto Venta:{3}, Fecha Venta:{4}", item.Id, item.IdClient, item.IdStore, item.SaleAmount, item.SaleDate);
            }

            return Lst;

        }

        
        public DateTime RandomDay()
        {
            DateTime start = new DateTime(2021, 6, 20);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(Gen.Next(range));
        }

        public double CalculateAmount(List<Sale> LstSale, int IdStore, DateTime SaleDate)
        {
            var date = Convert.ToDateTime(SaleDate).Date;
            var nextDay = date.AddDays(1);
            double total = LstSale.Where(item => item.IdStore == IdStore && (item.SaleDate >= date && item.SaleDate < nextDay)).Sum(item => item.SaleAmount);
            return total;
        }
    }
}
