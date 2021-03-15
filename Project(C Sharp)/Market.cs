using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Project_C_Sharp_
{
    class Market : IMarketable
    {
        static double PPrice { get; set; }
        public Market()
        {
            Products = new List<Mehsul>();
            Sales = new List<Satis>();
        }
        public List<Satis> Sales { get; set; }
        public List<Mehsul> Products { get; set; }

        public void AddNewProduct(string name,double price,string kateqoriya,int count,string kod)
        {
            Mehsul mehsul = new Mehsul(name, price, Helper.CategorySetter(kateqoriya), count, kod);
            if (!Products.Exists(p => p.Kod == kod))
            {
                Products.Add(mehsul);
            }
        }

        public void AddNewSale(Mehsul mehsuls, int count)
        {

            Mehsul mehsul = new Mehsul(mehsuls.Name, mehsuls.Price, mehsuls.Kateqoriya, mehsuls.Count, mehsuls.Kod);
            if (count > 0 && Products.Exists(p => p.Kod == mehsul.Kod))
            {
                SalesItems salesItems = new SalesItems(mehsul) { Count = count};
                List<SalesItems> salesItemsList = new List<SalesItems>();
                salesItemsList.Add(salesItems);
                Satis satis = new Satis(salesItemsList);
                
                Sales.Add(satis);
                mehsuls.Count -= count;
            }

        }

        public List<Mehsul> GetProductsByCategory(Kateqoriya kateqoriya)
        {
            var products = Products.FindAll(p => p.Kateqoriya == kateqoriya);
            return products;
        }

        public List<Mehsul> GetProductsByPrice(double startprice, double endprice)
        {
            var prices = Products.FindAll(p => p.Price >= startprice && p.Price <= endprice);
            return prices;
        }

        public List<Satis> GetSales(DateTime date)
        {
            var dates = Sales.FindAll(d => d.Date.Date == date.Date);
            return dates;
        }

        public List<Satis> GetSales(DateTime startdate, DateTime enddate)
        {
            var date = Sales.FindAll(d => d.Date.Date >= startdate.Date && d.Date.Date <= enddate.Date);
            return date;
        }

        public List<Satis> GetSalesByAmount(double startprice, double endprice)
        {

            var amounts = Sales.FindAll(a => a.TotalAmount >= startprice && a.TotalAmount <= endprice);
            return amounts;
        }

        public List<Satis> GetSalesByNo(int no)
        {
            var No = Sales.FindAll(k => k.No == no);
            return No;
        }

        public void ModifyProduct(string kod, string name)
        {
            Mehsul product = Products.Find(p => p.Kod == kod);
            if (product != null)
                product.Name = name;

        }

        public void ModifyProduct(string kod, int count)
        {
            Mehsul product = Products.Find(p => p.Kod == kod);
            if (product != null)
                product.Count += count;
        }

        public void ModifyProduct(string kod, double price)
        {
            Mehsul product = Products.Find(p => p.Kod == kod);
            if (product != null) 
            product.Price = price;
        }

        public void ModifyProduct(string kod, Kateqoriya kateqoriya)
        {
            Mehsul product = Products.Find(p => p.Kod == kod);
            if (product != null)
                product.Kateqoriya = kateqoriya;
        }

        public void RefundProduct(int salesNo, int salesItemsNo, int salesItemsCount)
        {

            foreach (var saless in Sales)
            {
                if (saless.No == salesNo)
                {
                    foreach (var salesitems in saless.SalesItems)
                    {
                        
                        if (salesitems.No == salesItemsNo)
                        {
                            Mehsul product = Products.Find(p => p.Kod == salesitems.Mehsul.Kod);
                            salesitems.Count -= salesItemsCount;
                            product.Count += salesItemsCount;
                            saless.TotalAmount -= salesitems.Mehsul.Price * salesItemsCount;
                            
                        }
                    }
                }
            }

        }

        public void RefundTotalSale(int salesNo)
        {

            Satis satis = Sales.Find(p => p.No == salesNo);
            foreach (var item in satis.SalesItems)
            {
                Mehsul product = Products.Find(p => p.Kod == item.Mehsul.Kod);
                product.Count += item.Count;
                satis.TotalAmount -= item.Mehsul.Price * item.Count;
                item.Count -= item.Count;
            }

            var stis = Sales.RemoveAll(s => s.No == salesNo);

        }

        public List<Mehsul> SearchProductsByName(string text)
        {
            
            var product = Products.FindAll(n => n.Name.ToLower().Contains(text.ToLower()));
            return product;
        }

        public string ShowProductName(string kod)
        {
            Mehsul product = Products.Find(p => p.Kod == kod);
            string name = product.Name;
            return name;
        }

        public int ShowProductCount(string kod)
        {
            Mehsul product = Products.Find(p => p.Kod == kod);
            int i = product.Count;
            return i;
        }
        public double ShowProductPrice(string kod)
        {
            Mehsul product = Products.Find(p => p.Kod == kod);
            double doub = product.Price;
            return doub;
        }
        public Kateqoriya ShowProductCategory(string kod)
        {
            Mehsul product = Products.Find(p => p.Kod == kod);
            Kateqoriya kateqoriya = product.Kateqoriya;
            return kateqoriya;
        }

        public void AddSaleItems(Mehsul mehsul, int count)
        {
            Mehsul mehsul1 = new Mehsul(mehsul.Name, mehsul.Price, mehsul.Kateqoriya, mehsul.Count, mehsul.Kod);
            SalesItems salesItems = new SalesItems(mehsul1) { Count = count };


            foreach (var item in Sales)
            {

                if (item.No == Helper.FindSalesNo())
                {
                    item.SalesItems.Add(salesItems);
                    item.TotalAmount += mehsul.Price * count;
                    mehsul.Count -= count;
                    foreach (var salesitems in item.SalesItems)
                    {
                        if (salesitems.No == Helper.FindSalesItemDynamicNo())
                        {
                            salesitems.Count = count;
                        }
                    }
                }

            }

        }
       
    }
}
