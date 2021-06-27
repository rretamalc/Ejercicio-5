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
            DateTime DateSearch = new(2021, 6, 22);
            int IdStore = 1;
            //Genera una lista de Venta Aleatorias
            List<Sale> LstRandomSales = classTransaction.GenerateRandomSales();
            Console.WriteLine("Ventas Generadas Aleatoria");
            foreach (var item in LstRandomSales)
            {
                Console.WriteLine("Id:{0}, Cliente:{1}, Tienda:{2}, Monto Venta:{3}, Fecha Venta:{4}", item.Id, item.IdClient, item.IdStore, item.SaleAmount, item.SaleDate);
            }
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("Fecha de busqueda:{0} Id tienda de busqueda:{1}", DateSearch.ToString(),IdStore);
           
            //Genera Lista de Clientes agrupando el total de compras que realizan de acuerdo a la fecha y id de la tienda
            IList<Sale> ILst = classTransaction.IListClientAmount(LstRandomSales, IdStore, DateSearch);
            foreach (var item in ILst)
            {
                Console.WriteLine("IdClient:{0}|Amount:{1}",item.IdClient,item.SubTotal);
            }

            //Genera el total de compras realizadas en una tienda de acuerda a la fecha y id de la tienda
            Console.WriteLine("Total Sale:{0}",classTransaction.TotalAmount(LstRandomSales, IdStore, DateSearch));

        }
    }
}
