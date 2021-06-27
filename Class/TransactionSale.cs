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
        public List<Sale> GenerateRandomSales()
        {
            List<Sale> Lst=new();
            for (int i = 0; i < 50; i++)
            {
                Lst.Add(new Sale { Id = i, IdClient = Gen.Next(1, 20), SaleAmount = 2000.00 + Gen.Next(100, 1000), SaleDate = RandomDay(), IdStore = Gen.Next(1,3)});
            }

            return Lst;

        }

        
        public DateTime RandomDay()
        {
            DateTime start = new(2021, 6, 20);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(Gen.Next(range));
        }

        public double TotalAmount(List<Sale> LstSale, int IdStore, DateTime SaleDate)
        {
            var date = Convert.ToDateTime(SaleDate).Date;
            var nextDay = date.AddDays(1);
            double total = LstSale.Where(item => item.IdStore == IdStore && (item.SaleDate >= date && item.SaleDate < nextDay)).Sum(item => item.SaleAmount);
            return total;
        }

        public IList<Sale> IListClientAmount(List<Sale> LstSale, int IdStore, DateTime SaleDate)
        {
            var date = Convert.ToDateTime(SaleDate).Date;
            var nextDay = date.AddDays(1);
            IList<Sale> result = LstSale.Where(item => item.IdStore == IdStore && (item.SaleDate >= date && item.SaleDate < nextDay)).OrderBy(item=> item.IdClient).GroupBy(item => item.IdClient)
                           .Select(t => new Sale
                           {
                               IdClient = t.Key,
                               SubTotal = t.Sum(ta => ta.SaleAmount),
                           }).ToList();   
            return result;
        }
    }
}
