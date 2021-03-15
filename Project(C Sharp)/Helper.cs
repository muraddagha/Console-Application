using System;
using System.Collections.Generic;
using System.Text;

namespace Project_C_Sharp_
{
    class Helper
    {
        public static bool YesNo(string text, string endtext)
        {
            Console.Write($"{text}... [y] :\n{endtext}");
            ConsoleKey response = Console.ReadKey(false).Key;
            Console.WriteLine();
            return (response == ConsoleKey.Y);
        }
        public static bool YesNo(string text)
        {
            Console.Write($"{text}... [y] :\nGeri qayıtmaq üçün istenilen düymeye basın...\n");
            ConsoleKey response = Console.ReadKey(false).Key;
            Console.WriteLine();
            return (response == ConsoleKey.Y);
        }

        public static Kateqoriya CategorySetter(string kateqoriya)
        {


            string kateq = kateqoriya;
            Kateqoriya kateqoriyaEnum = (Kateqoriya)Convert.ToInt32(kateqoriya);
            switch (kateq)
            {
                case "1":
                    kateqoriyaEnum = Kateqoriya.Telefon;
                    break;
                case "2":
                    kateqoriyaEnum = Kateqoriya.Laptop;
                    break;
                case "3":
                    kateqoriyaEnum = Kateqoriya.SSD;
                    break;
                case "4":
                    kateqoriyaEnum = Kateqoriya.HDD;
                    break;
                case "5":
                    kateqoriyaEnum = Kateqoriya.Televizor;
                    break;
                default:
                    break;
            }
            return kateqoriyaEnum;
        }

        public static bool CategoryValid(string kateqoriya)
        {
            bool check = true;
            try
            {
                string kateq = kateqoriya;
                Kateqoriya kateqoriyaEnum = (Kateqoriya)Convert.ToInt32(kateqoriya);
                switch (kateq)
                {
                    case "1":
                        kateqoriyaEnum = Kateqoriya.Telefon;
                        return true;
                    case "2":
                        kateqoriyaEnum = Kateqoriya.Laptop;
                        return true;
                    case "3":
                        kateqoriyaEnum = Kateqoriya.SSD;
                        return true;
                    case "4":
                        kateqoriyaEnum = Kateqoriya.HDD;
                        return true;
                    case "5":
                        kateqoriyaEnum = Kateqoriya.Televizor;
                        return true;
                    default:
                        return false;
                }

            }
            catch (Exception)
            {

                Console.WriteLine("\nXETA BAS VERDI !\nDUZGUN SECIM EDIN !\n");
                check = false;
            }
            return check;




        }

        public static void Category()
        {
            Console.WriteLine("\nKateqoriya secin: \n");
            Console.WriteLine("1-Telefon");
            Console.WriteLine("2-Laptop");
            Console.WriteLine("3-SSD");
            Console.WriteLine("4-HDD");
            Console.WriteLine("5-Televizor");
            Console.Write("\nSecim edin: ");
        }

        public static List<Mehsul> FindProductbyKod(string kod)
        {
            var Kod = Program.MarketMenu.Products.FindAll(p => p.Kod == kod);
            return Kod;
        }
        public static int FindSalesNo()
        {
            int No = 0;
            foreach (var item in Program.MarketMenu.Sales)
            {
                No = item.No;

            }
            return No;
        }
        public static SalesItems FindSalesItemsBySalesNo(int no, int salesitemno)
        {

            Satis satis = Program.MarketMenu.Sales.Find(n => n.No == no);

            SalesItems salesItems = satis.SalesItems.Find(n => n.No == salesitemno);
            return salesItems;


        }

        public static int FindSalesItemDynamicNo()
        {
            int num = 0;
            foreach (var sales in Program.MarketMenu.Sales)
            {
                foreach (var item in sales.SalesItems)
                {
                    num = item.No;
                }
            }
            return num;
        }

        public static void ShowProductInfo()
        {
            string kod = "";
            string name = "";
            int count = 0;
            Kateqoriya kateqoriya = Kateqoriya.HDD;
            double price = 0;

            foreach (var item in Program.MarketMenu.Products)
            {
                kod = item.Kod;
                name = item.Name;
                count = item.Count;
                kateqoriya = item.Kateqoriya;
                price = item.Price;
            }
            Console.WriteLine($"\nMehsulun kodu: {kod}\nAdi: {name}\nQiymeti: {price} AZN\nKateqoriyasi: {kateqoriya}\nSayi: {count}");

        }

        public static Satis FindSatis(int no)
        {
            Satis satis = Program.MarketMenu.Sales.Find(s => s.No == no);
            return satis;
        }

        public static int FindSalesIteamCountByNo(int no, int salesitemno)
        {
            int count = 0;

            foreach (var item in FindSatis(no).SalesItems)
            {
                if (item.No == salesitemno)
                {
                    count = item.Count;
                }
            }
            return count;
        }

        public static Mehsul FindProduct(string kod)
        {
            Mehsul mehsul = Program.MarketMenu.Products.Find(p => p.Kod == kod);
            return mehsul;
        }

        public static void AddItemsUserInput()
        {

            Console.WriteLine("Mehsulun kodunu daxil edin");
            string kod = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(kod) && Program.MarketMenu.Products.Exists(p => p.Kod == kod))
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("                                 MEHSUL MELUMATLARI: ");
                Console.WriteLine("*******************************************************************");
                foreach (var product in Helper.FindProductbyKod(kod))
                {
                    Console.WriteLine($"\nMehsulun adi: {product.Name}\nSayi: {product.Count}\nKateqoriyasi: {product.Kateqoriya}");
                }

                Console.WriteLine("Bu mehsulun satilacaq sayin daxil edin");
                string input = Console.ReadLine();
                int count = 0;
                if (int.TryParse(input,out count)&& count > 0)
                {
                    if (Helper.FindProduct(kod).Count >= count && count > 0)
                    {

                        Program.MarketMenu.AddSaleItems(FindProduct(kod), count);
                        Console.WriteLine("\nMEHSUL ELAVE EDILDI !");

                    }
                    else
                    {
                        Console.WriteLine("Daxil etdiyiniz sayda mehsul yoxdur");
                    }
                }
                else
                {
                    Console.WriteLine("YALNIZ REQEM DAXIL EDIN!");
                }
                

            }
            else
            {
                Console.WriteLine("Bu koda uygun mehsul yoxdur");
            }

        }

        public static int ShowProductsCount()
        {
            int count = 0;

            foreach (var item in Program.MarketMenu.Products)
            {
                count += item.Count;
            }
            return count;
        }

    }
}
