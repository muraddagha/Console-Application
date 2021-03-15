using System;
using System.Collections.Generic;
using System.Text;

namespace Project_C_Sharp_
{
    interface IMarketable
    {
        List<Satis> Sales { get; set; }
        List<Mehsul> Products { get; set; }

        void AddNewSale(Mehsul mehsuls, int count);

        void RefundProduct(int salesNo, int salesItemsNo, int SalesItemsCount);

        void RefundTotalSale(int salesNo);

        List<Satis> GetSales(DateTime date);
        List<Satis> GetSales(DateTime startdate, DateTime enddate);
        List<Satis> GetSalesByAmount(double startprice,double endprice);
        List<Satis> GetSalesByNo(int no);

        void AddNewProduct(string name, double price, string kateqoriya, int count, string kod);
        void ModifyProduct(string kod,string name);
        void ModifyProduct(string kod,int count);
        void ModifyProduct(string kod,double price);
        void ModifyProduct(string kod,Kateqoriya kateqoriya);
        List<Mehsul> GetProductsByCategory(Kateqoriya kateqoriya);
        List<Mehsul> GetProductsByPrice(double startprice,double endprice);
        List<Mehsul> SearchProductsByName(string name);


    }
}
