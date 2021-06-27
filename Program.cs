using Ejercicio_5.Class;
using System;
using System.Collections.Generic;

namespace Ejercicio_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var classTransaction = new TransactionSale();
            DateTime DateSearch = new DateTime(2021, 6, 22);
            List<Sale> Lst = classTransaction.GenerateSales();
            Console.WriteLine("Fecha de busqueda:{0}", DateSearch.ToString());
            Console.WriteLine(classTransaction.CalculateAmount(Lst,1,DateSearch));
        }
    }
}
