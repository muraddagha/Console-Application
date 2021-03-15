using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Project_C_Sharp_
{
    class Program
    {
        public static Market MarketMenu = new Market();
        public static TextInfo MyText = new CultureInfo("en-US", false).TextInfo;

        static void Main(string[] args)
        {
            bool wantToContinue = true;
            while (wantToContinue)
            {
                Console.Clear();
                Console.WriteLine("\rChose an option...");
                Console.WriteLine("****************************************");
                Console.WriteLine("1) Mehsullar uzerinde emeliyyat aparmaq");
                Console.WriteLine("2) Satislar uzerinde emeliyyat aparmaq");
                Console.WriteLine("3) Sistemden cixmaq");
                Console.WriteLine("****************************************");
                Console.WriteLine("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        do
                        {
                            MehsullarUzerindeEmeliyyat();

                        } while (Helper.YesNo("\nMehsullar Uzerinde Emeliyyat menyusu ucun...","Ana menyuya qayıtmaq üçün istenilen düymeye basın...\n"));
                        break;
                    case "2":
                        do
                        {
                            SatislarUzerindeEmeliyyat();
                        } while (Helper.YesNo("\nSatislar Uzerinde Emeliyyat menyusu ucun...","Ana menyuya qayıtmaq üçün istenilen düymeye basın...\n"));
                        break;
                    case "3":
                        wantToContinue = false;
                        break;
                    default:
                        break;
                }

            }

        }
        private static void MehsullarUzerindeEmeliyyat()
        {
            {
                Console.Clear();
                Console.WriteLine("Chose an option:");
                Console.WriteLine("****************************************");
                Console.WriteLine("1.1) Add New Product");
                Console.WriteLine("1.2) Modify Product");
                Console.WriteLine("1.3) Remove Product");
                Console.WriteLine("1.4) Show All Products");
                Console.WriteLine("1.5) Show Products by Category");
                Console.WriteLine("1.6) Show Proudcts by Price Range");
                Console.WriteLine("1.7) Search Products by Name");
                Console.WriteLine("1.8) Esas menyuya qayit");
                Console.WriteLine("****************************************");
                Console.WriteLine("\nGeri qayıtmaq üçün istenilen düymeye basın...\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        ModifyProduct();
                        break;
                    case "3":
                        RemoveProduct();
                        break;
                    case "4":
                        ShowAllProducts();
                        break;
                    case "5":
                        ShowProductsbyCategory();
                        break;
                    case "6":
                        ShowProductsbyPrice();
                        break;
                    case "7":
                        ShowProductsbyText();
                        break;
                    case "8":
                        break;
                    default:
                        break;
                }

            }
        }

        #region menu 1.1
        private static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("                               MEHSUL ELAVE ETMEK ");
            Console.WriteLine("*******************************************************************");
            bool loop = true;
            while (loop)
            {
                Console.Write("\nMehsulun adini daxil edin: ");

                string name = Console.ReadLine();
                name = MyText.ToTitleCase(name.Trim());
                name= Regex.Replace(name, @"\s+", " ");
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (!MarketMenu.Products.Exists(m => m.Name.ToLower() == name.ToLower()&&m.Name.ToUpper()==name.ToUpper()))
                    {
                        while (loop)
                        {
                            Console.Write("Mehsulun qiymetini daxil edin: ");
                            string inputprice = Console.ReadLine();
                            double price = 0;

                            if (double.TryParse(inputprice,out price) && price > 0)
                            {
                                while (loop)
                                {
                                    Helper.Category();

                                    string kateqoryia = Console.ReadLine();

                                    if (kateqoryia.Length != 0 && Helper.CategoryValid(kateqoryia))
                                    {
                                        while (loop)
                                        {
                                            Console.Write("Mehsulun sayini daxil edin: ");
                                            string inputcount = Console.ReadLine();
                                            int count = 0;
                                           
                                            if (int.TryParse(inputcount,out count)&&count > 0)
                                            {
                                                while (loop)
                                                {

                                                    Console.Write("Mehsulun kodunu daxil edin: ");
                                                    string Kod = Console.ReadLine();
                                                    Kod = Kod.Trim();
                                                    Kod = Regex.Replace(Kod, @"\s+", "");
                                                    if (!string.IsNullOrWhiteSpace(Kod))
                                                    {

                                                        if (!MarketMenu.Products.Exists(m => m.Kod.ToLower() == Kod.ToLower() && m.Kod.ToUpper() == Kod.ToUpper()))
                                                        {

                                                            MarketMenu.AddNewProduct(name, price, kateqoryia, count, Kod);
                                                            Console.Clear();
                                                            Console.WriteLine();
                                                            Console.WriteLine("*******************************************************************");
                                                            Console.WriteLine("                               MEHSUL ELAVE EDILDI !");
                                                            Console.WriteLine("*******************************************************************");
                                                            Helper.ShowProductInfo();

                                                            loop = false;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Bu kodda mehsul artiq movcuddur!\n");
                                                            if (!Helper.YesNo("Basqa bir kod yoxlamaq ucun secin..."))
                                                            {
                                                                loop = false;
                                                            }

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Mehsulun kodu bos buraxila bilmez!\n");
                                                        if (!Helper.YesNo("Basqa bir kod yoxlamaq ucun secin..."))
                                                        {
                                                            loop = false;
                                                        }
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Dogru eded daxil edin!\n");
                                                if (!Helper.YesNo("Basqa bir eded yoxlamaq ucun secin..."))
                                                {
                                                    loop = false;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Kateqoriya secilmeyib\nBir kateqoriya secin\n");
                                        if (!Helper.YesNo("Basqa bir kateqoriya yoxlamaq ucun secin..."))
                                        {
                                            loop = false;
                                        }

                                    }

                                }

                            }
                            else
                            {
                                Console.WriteLine("Dogru eded daxil edin!\n");
                                if (!Helper.YesNo("Basqa bir eded yoxlamaq ucun secin..."))
                                {
                                    loop = false;
                                }
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Bu adda mehsul artiq movcuddur!\n");
                        if (!Helper.YesNo("Basqa bir ad yoxlamaq ucun secin..."))
                        {
                            loop = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ad bos buraxila bilmez!\n");
                    if (!Helper.YesNo("Basqa bir ad yoxlamaq ucun secin..."))
                    {
                        loop = false;
                    }
                    
                }

            }

        }
        private static void ModifyProduct()
        {
            if (MarketMenu.Products.Count > 0)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("                                 MODIFY PRODUCT: ");
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("\n1) Mehsulun adini deyismek");
                Console.WriteLine("2) Mehsulun sayini deyismek");
                Console.WriteLine("3) Mehsulun qiymetini deyismek");
                Console.WriteLine("4) Mehsulun kateqoriyasini deyismek");
                Console.Write("\nSecim edin....");

                switch (Console.ReadLine())
                {
                    case "1":
                        changeProductName();
                        break;
                    case "2":
                        changeProductCount();
                        break;
                    case "3":
                        changeProductPrice();
                        break;
                    case "4":
                        changeProductCategory();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Hec bir mehsul elave edilmeyib\nMehsul elave edin!\n");
            }

        }
        #region Modify
        private static void changeProductName()
        {
            Console.Clear();
            ShowAllProducts();
            bool loop = true;
            while (loop)
            {
                
                Console.WriteLine("\nMehsulun kodunu daxil edin: ");
                string kod = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(kod) && MarketMenu.Products.Exists(m => m.Kod.ToLower() == kod.ToLower() && m.Kod.ToUpper() == kod.ToUpper()))
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

                    while (loop)
                    {
                        Console.WriteLine("\nYeni ad elave edin: ");
                        string name = Console.ReadLine();
                        name = MyText.ToTitleCase(name.Trim());
                        if (!string.IsNullOrWhiteSpace(name) && !MarketMenu.Products.Exists(m => m.Name.ToLower() == name.ToLower() && m.Name.ToUpper() == name.ToUpper()))
                        {
                            MarketMenu.ModifyProduct(kod, name);

                            Console.WriteLine($"Ad deyisildi\nMehsulun yeni adi: {MarketMenu.ShowProductName(kod)}");
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("\nDAXIL EDILEN AD YALNISDIR!\nVe yaxud bu ad artiq movcuddur\n");
                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                            {
                                loop = false;
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Bu koda uygun mehsul yoxdur\n");
                    if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                    {
                        loop = false;
                    }
                }

            }
           
        }

        private static void changeProductCount()
        {
            Console.Clear();
            ShowAllProducts();
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("\nMehsulun kodunu daxil edin: ");
                string kod = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(kod) && MarketMenu.Products.Exists(p => p.Kod == kod))
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

                    while (loop)
                    {
                        Console.WriteLine("\nYeni miqdar elave edin: ");
                        string input = Console.ReadLine();
                        int count = 0;
                        if (int.TryParse(input, out count) && count > 0)
                        {
                            MarketMenu.ModifyProduct(kod, count);

                            Console.WriteLine($"Miqdar deyisildi\nMehsulun yeni miqdari: {MarketMenu.ShowProductCount(kod)}");
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("\nDAXIL EDILEN MIQDAR YALNISDIR!\n");
                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                            {
                                loop = false;
                            }
                        }
                    }

                    

                }
                else
                {
                    Console.WriteLine("Bu koda uygun mehsul yoxdur\n");
                    if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                    {
                        loop = false;
                    }
                }

            }
            
        }
        private static void changeProductPrice()
        {
            Console.Clear();
            ShowAllProducts();
            bool loop = true;
            while (loop)
            {
                
                Console.WriteLine("\nMehsulun kodunu daxil edin: ");
                string kod = Console.ReadLine();
                if (!string.IsNullOrEmpty(kod) && MarketMenu.Products.Exists(p => p.Kod == kod))
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

                    while (loop)
                    {
                        Console.WriteLine("\nYeni qiymet elave edin: ");
                        string input = Console.ReadLine();
                        double price = 0;
                        if (double.TryParse(input, out price) && price > 0)
                        {
                            MarketMenu.ModifyProduct(kod, price);
                            Console.WriteLine($"Qiymet deyisildi\nMehsulun yeni qiymeti: {MarketMenu.ShowProductPrice(kod)} AZN");
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("\nDAXIL EDILEN MIQDAR YALNISDIR!\n");
                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                            {
                                loop = false;
                            }
                        }
                    }

                    

                }
                else
                {
                    Console.WriteLine("Bu koda uygun mehsul yoxdur\n");
                    if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                    {
                        loop = false;
                    }
                }

            }
            
        }

        private static void changeProductCategory()
        {
            Console.Clear();
            ShowAllProducts();
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("\nMehsulun kodunu daxil edin: ");
                string kod = Console.ReadLine();
                if (!string.IsNullOrEmpty(kod) && MarketMenu.Products.Exists(p => p.Kod == kod))
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
                    while (loop)
                    {
                        Console.WriteLine("\nYeni Kateqoriya teyin edin");
                        Helper.Category();
                        string kateqoriya = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(kateqoriya) && Helper.CategoryValid(kateqoriya))
                        {
                            MarketMenu.ModifyProduct(kod, Helper.CategorySetter(kateqoriya));
                            Console.WriteLine($"Kateqoriya deyisildi\nMehsulun yeni kateqoriyasi: {MarketMenu.ShowProductCategory(kod)}");
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("Kateqoriya secilmeyib\nBir kateqoriya secin\n");
                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                            {
                                loop = false;
                            }
                        }
                    }
                    

                }
                else
                {
                    Console.WriteLine("Bu koda uygun mehsul yoxdur\n");
                    if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                    {
                        loop = false;
                    }
                }

            }
            
        }
        #endregion
        private static void RemoveProduct()
        {
            bool loop = true;
            
            if (MarketMenu.Products.Count > 0)
            {
                while (loop)
                {
                    Console.WriteLine("Silinecek mehsulunu kodunu daxil edin");
                    string kod = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(kod) && MarketMenu.Products.Exists(p => p.Kod == kod))
                    {
                        var toremove = MarketMenu.Products.RemoveAll(p => p.Kod == kod);
                        Console.WriteLine("Mehsul Silindi");
                        foreach (var item in MarketMenu.Products)
                        {
                            Console.WriteLine($"Qalan mehsullar: {item.Name}");
                        }
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("\nBU KODA UYGUN MEHSUL YOXDUR!");
                        if (!Helper.YesNo("\nBasqa kod yoxlamaq ucun..."))
                        {
                            loop = false;
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Hec bir mehsul elave edilmeyib\nMehsul elave edin!\n");

            }

        }
        private static void ShowAllProducts()
        {

            if (MarketMenu.Products.Count > 0)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("                               MÖVCUD MEHSULLAR:");
                Console.WriteLine("*******************************************************************");
                foreach (var item in MarketMenu.Products)
                {
                    Console.WriteLine($"\nMehsulun kodu: {item.Kod}\nMehsulun adi: {item.Name}\nMehsulun qiymeti: {item.Price} AZN\nMehsulun Kateqoriyasi: {item.Kateqoriya}\nMehsulun sayi: {item.Count}");
                }
            }
            else
            {
                Console.WriteLine("Hec bir mehsul elave edilmeyib\nMehsul elave edin!\n");
            }

        }

        private static void ShowProductsbyCategory()
        {
            bool loop = true;
            if (MarketMenu.Products.Count > 0)
            {
                while (loop)
                {
                    Console.Clear();
                    Helper.Category();
                    string kateqory = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(kateqory) && Helper.CategoryValid(kateqory))
                    {
                        if (MarketMenu.Products.Exists(p => p.Kateqoriya == Helper.CategorySetter(kateqory)))
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("*******************************************************************");
                            Console.WriteLine("                               BU KATEQORIYADAKI MEHSULLAR:");
                            Console.WriteLine("*******************************************************************");
                            foreach (var item in MarketMenu.GetProductsByCategory(Helper.CategorySetter(kateqory)))
                            {
                                Console.WriteLine($"\r\nMehsulun kodu: {item.Kod}\nAdi: {item.Name}\nQiymeti: {item.Price} AZN\nKateqoriyasi: {item.Kateqoriya}\nSayi: {item.Count}");
                            }
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("Bu kateqoriyada mehsul yoxdur\n");
                            if (!Helper.YesNo("Basqa bir kateqoriya yoxlamaq ucun.."))
                            {
                                loop = false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nKateqoriya secilmeyib\nBir kateqoriya secin\n");
                        if (!Helper.YesNo("Basqa bir kateqoriya yoxlamaq ucun.."))
                        {
                            loop = false;
                        }
                    }
                    
                }
                

            }
            else
            {
                Console.WriteLine("Hec bir mehsul elave edilmeyib\nMehsul elave edin!\n");
            }
        }

        private static void ShowProductsbyPrice()
        {
            bool loop = true;
            if (MarketMenu.Products.Count>0)
            {
               
                while (loop)
                {
                    Console.WriteLine("Qiymet araligini daxil edin: ");
                    Console.Write("min. ");
                    double min = Convert.ToDouble(Console.ReadLine());
                    if (min > 0)
                    {
                        Console.Write("maks. ");
                        double maks = Convert.ToDouble(Console.ReadLine());
                        if (maks > 0)
                        {

                            if (MarketMenu.Products.Exists(p => p.Price >= min && p.Price <= maks))
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("*******************************************************************");
                                Console.WriteLine("                              BU QIYMET ARALIGINDAKI MEHSULLAR:");
                                Console.WriteLine("*******************************************************************");
                                foreach (var item in MarketMenu.GetProductsByPrice(min, maks))
                                {
                                    Console.WriteLine($"\nMehsulun kodu: {item.Kod}\nAdi: {item.Name}\nQiymeti: {item.Price} AZN\nKateqoriyasi: {item.Kateqoriya}\nSayi: {item.Count}");
                                }
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("Bu qiymet araligina uygun mehsul yoxdur\n");
                                if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                {
                                    loop = false;
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("DUZGUN EDED DAXIL EDIN !\n");
                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                            {
                                loop = false;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("DUZGUN EDED DAXIL EDIN !\n");
                        if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                        {
                            loop = false;
                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("MEHSUL YOXDUR!\n");
            }

        }

        private static void ShowProductsbyText()
        {
            bool loop = true;
            if (MarketMenu.Products.Count>0)
            {
               
                while (loop)
                {
                    Console.WriteLine("Axtaracaginiz mehsulu daxil edin");
                    string text = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(text) && MarketMenu.Products.Exists(p => p.Name.ToLower().Contains(text.ToLower())))
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("*******************************************************************");
                        Console.WriteLine("                                 TAPILAN MEHSULLAR: ");
                        Console.WriteLine("*******************************************************************");
                        foreach (var item in MarketMenu.SearchProductsByName(text))
                        {
                            Console.WriteLine($"\nMehsulun kodu: {item.Kod}\nAdi: {item.Name}\nQiymeti: {item.Price} AZN\nKateqoriyasi: {item.Kateqoriya}\nSayi: {item.Count}");
                        }
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("MEHSUL TAPILMADI!\n");
                        if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                        {
                            loop = false;
                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("MEHSUL YOXDUR!\n");
            }
           
        }

        #endregion
        private static void SatislarUzerindeEmeliyyat()
        {

            Console.Clear();
            Console.WriteLine("Secim edin:... ");
            Console.WriteLine("****************************************");
            Console.WriteLine("1) Yeni satis elave etmek");
            Console.WriteLine("2) Satisdaki mehsulun qaytarilmasi");
            Console.WriteLine("3) Satisin silinmesi");
            Console.WriteLine("4) Butun satislari goster");
            Console.WriteLine("5) Tarix araligina gore satislari goster");
            Console.WriteLine("6) Mebleg araligina gore satislari goster");
            Console.WriteLine("7) Tarixe gore satisin gosterlimesi");
            Console.WriteLine("8) Nomreye esasen satisin melumatlarini goster");
            Console.WriteLine("9) Esas menyuya qayit");
            Console.WriteLine("****************************************");
            Console.WriteLine("\nGeri qayıtmaq üçün istenilen düymeye basın...\n");


            switch (Console.ReadLine())
            {
                case "1":
                    AddSale();
                    break;
                case "2":
                    CancelProduct();
                    break;
                case "3":
                    RemoveSale();
                    break;
                case "4":
                    ShowAllSales();
                    break;
                case "5":
                    ShowSalesbyDateRange();
                    break;
                case "6":
                    ShowSalesbyPrice();
                    break;
                case "7":
                    ShowSalesbyDate();
                    break;
                case "8":
                    ShowSalesbyNo();
                    break;
                case "9":
                    break;
                default:
                    break;
            }
        }
        #region Menu 1.2
        private static void AddSale()
        {
            if (Helper.ShowProductsCount() > 0)
            {
                Console.Clear();
                ShowAllProducts();
                bool loop = true;
                while (loop)
                {
                    Console.WriteLine("\n*******************************************************************");
                    Console.WriteLine("\nMehsulun kodunu daxil edin");
                    string kod = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(kod))
                    {
                        
                        if (MarketMenu.Products.Exists(p => p.Kod == kod))
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
                            while (loop)
                            {
                                Console.WriteLine("\nBu mehsulun satilacaq sayin daxil edin");
                                string input = Console.ReadLine();
                                int count = 0;
                                if (int.TryParse(input, out count))
                                {
                                    if (Helper.FindProduct(kod).Count >= count && count > 0)
                                    {

                                        MarketMenu.AddNewSale(Helper.FindProduct(kod), count);
                                        Console.WriteLine("\nMEHSUL ELAVE EDILDI !");
                                        while (Helper.YesNo("\nBasqa mehsul elave etmek ucun secin..."))
                                        {

                                            if (Helper.ShowProductsCount() > 0)
                                            {
                                                Helper.AddItemsUserInput();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nMEHSUL YOXDUR !");
                                                break;
                                            }

                                        }
                                        Console.Clear();
                                        Console.WriteLine();
                                        Console.WriteLine("*******************************************************************");
                                        Console.WriteLine("                                 SATIS ELAVE EDILDI! ");
                                        Console.WriteLine("*******************************************************************");

                                        foreach (var salesItems in Helper.FindSatis(Helper.FindSalesNo()).SalesItems)
                                        {
                                            Console.WriteLine($"\nMehsulun adi: {salesItems.Mehsul.Name}\nSatisa elave edilen mehsul sayi: {salesItems.Count}\nMehsulun satis nomresi: {salesItems.No}");
                                        }
                                        loop = false;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Daxil etdiyiniz sayda mehsul yoxdur\n");
                                        if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                        {
                                            loop = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nYALNIZ REQEM DAXIL EDIN!\n");
                                    if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                    {
                                        loop = false;
                                    }
                                }


                            }

                        }
                        else
                        {
                            Console.WriteLine("Bu koda uygun mehsul yoxdur\n");
                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                            {
                                loop = false;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Setr bos buraxila bilmez!\n");
                        if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                        {
                            loop = false;
                        }
                    }
                   
                }

            }
            else
            {
                Console.WriteLine("Mehsul yoxdur \nMehsul elave edin!\n");
            }

        }
        private static void CancelProduct()
        {
            bool loop = true;
            if (MarketMenu.Sales.Count>0)
            {
                
                while (loop)
                {
                    Console.WriteLine("\nSatisin nomresini daxil edin");
                    string input = Console.ReadLine();
                    int no = 0;
                    if (int.TryParse(input, out no))
                    {
                        if (MarketMenu.Sales.Exists(s => s.No == no))
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("*******************************************************************");
                            Console.WriteLine("                                 SATISDAKI MEHSULLAR: ");
                            Console.WriteLine("*******************************************************************");
                            foreach (var sales in Helper.FindSatis(no).SalesItems)
                            {
                                Console.WriteLine($"\nSatis mehsulunun nomresi: {sales.No}\nMehsulun adi: {sales.Mehsul.Name}\nSatisda olan mehsul sayi: {sales.Count}");
                            }

                            while (loop)
                            {
                                Console.WriteLine("\nSatis mehsulunun nomresini daxil edin");
                                string input2 = Console.ReadLine();
                                int saleitemno = 0;

                                if (int.TryParse(input2, out saleitemno))
                                {
                                    if (Helper.FindSatis(no).SalesItems.Exists(n => n.No == saleitemno) && saleitemno > 0)
                                    {
                                        while (loop)
                                        {
                                            Console.WriteLine("Mehsulun geri qaytaracaginiz sayini elave edin");
                                            string input3 = Console.ReadLine();
                                            int count = 0;
                                            if (int.TryParse(input3, out count))
                                            {
                                                if (Helper.FindSalesIteamCountByNo(no, saleitemno) >= count && count > 0)
                                                {
                                                    MarketMenu.RefundProduct(no, saleitemno, count);

                                                    Console.Clear();
                                                    Console.WriteLine();
                                                    Console.WriteLine("*******************************************************************");
                                                    Console.WriteLine("                                 SATISDA QALAN MEHSUL SAYI: ");
                                                    Console.WriteLine("*******************************************************************");
                                                    Console.WriteLine($"\nMehsulun satis nomresi:{Helper.FindSalesItemsBySalesNo(no, saleitemno).No}\nSatisda olan mehsul sayi: {Helper.FindSalesItemsBySalesNo(no, saleitemno).Count}");
                                                    loop = false;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Daxil etdiyiniz sayda mehsul yoxdur\n");
                                                    if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                                    {
                                                        loop = false;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("YALNIZ REQEM DAXIL EDIN!\n");
                                                if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                                {
                                                    loop = false;
                                                }
                                            }

                                        }


                                    }
                                    else
                                    {
                                        Console.WriteLine("Daxil etdiyiniz edede uygun satis mehsulu yoxdur\n");
                                        if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                        {
                                            loop = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("YALNIZ REQEM DAXIL EDIN!\n");
                                    if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                    {
                                        loop = false;
                                    }
                                }

                            }

                        }
                        else
                        {
                            Console.WriteLine("\nBu nomreye uygun satis yoxdur\n");
                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                            {
                                loop = false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("YALNIZ REQEM DAXIL EDIN!\n");
                        if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                        {
                            loop = false;
                        }
                    }

                }

                
            }
            else
            {
                Console.WriteLine("Hec bir satis bas vermeyib");
            }
            

            


        }
        private static void RemoveSale()
        {
            bool loop = true;
            if (MarketMenu.Sales.Count > 0)
            {
                

                while (loop)
                {
                    Console.WriteLine("Satis nomresini daxil edin");
                    string input = Console.ReadLine();
                    int no = 0;
                    if (int.TryParse(input, out no))
                    {
                        if (no > 0 && MarketMenu.Sales.Exists(s => s.No == no))
                        {
                            MarketMenu.RefundTotalSale(no);
                            Console.WriteLine("Satis silindi");
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("\nBu nomreye uygun satis yoxdur\n");
                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                            {
                                loop = false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYALNIZ REQEM DAXIL EDIN!\n");
                        if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                        {
                            loop = false;
                        }
                    }
                }

                
               
            }
            else
            {
                Console.WriteLine("\nHec bir satis bas vermeyib");
            }


        }

        private static void ShowAllSales()
        {
            if (MarketMenu.Sales.Count > 0)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("                                 SATIS MELUMATLARI: ");
                Console.WriteLine("*******************************************************************");
                foreach (var sales in MarketMenu.Sales)
                {
                    Console.WriteLine($"\nSatisin Nomresi: { sales.No}\nUmimi meblegi: {sales.TotalAmount} AZN\nTarixi: {sales.Date}");
                    if (Helper.FindSatis(sales.No).SalesItems.Count > 0)
                    {
                        int count = 0;
                        foreach (var item in Helper.FindSatis(sales.No).SalesItems)
                        {
                            count += item.Count;
                        }
                        Console.WriteLine($"Satisda olan mehsullarin sayi: {count}");
                    }
                    else
                    {
                        foreach (var item in sales.SalesItems)
                        {

                            Console.WriteLine($"Satisda olan mehsullarin sayi: {item.Count}");
                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("Hec bir satis bas vermeyib\nSatis elave edin!\n");
            }

        }
        private static void ShowSalesbyDateRange()
        {
            bool loop = true;
            if (MarketMenu.Sales.Count>0)
            {
                while (loop)
                {
                    
                    Console.WriteLine("\nBaslangic tarixi daxil edin (gün/ay/il)");
                    string sDate = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(sDate))
                    {
                        DateTime startdate = new DateTime();
                        if (DateTime.TryParse(sDate, out startdate))
                        {
                            Console.WriteLine("\nBitis tarixi daxil edin (gün/ay/il)");
                            string eDate = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(eDate))
                            {

                                DateTime enddate = new DateTime();
                                if (DateTime.TryParse(eDate, out enddate))
                                {
                                    if (enddate>startdate)
                                    {
                                       
                                        if (MarketMenu.GetSales(startdate,enddate).Exists(s=> s.Date.Date >= startdate.Date && s.Date.Date<=enddate.Date))
                                        {
                                            foreach (var sales in MarketMenu.GetSales(startdate, enddate))
                                            {
                                                Console.WriteLine($"\nSatin Nomresi: { sales.No}\nSatisin Umimi meblegi: {sales.TotalAmount} AZN\nSatisin tarixi: {sales.Date}");
                                                if (Helper.FindSatis(sales.No).SalesItems.Count > 0)
                                                {
                                                    int count = 0;
                                                    foreach (var item in Helper.FindSatis(sales.No).SalesItems)
                                                    {
                                                        count += item.Count;
                                                    }
                                                    Console.WriteLine($"Satisda olan mehsullarin sayi: {count}");

                                                }
                                                else
                                                {
                                                    foreach (var item in sales.SalesItems)
                                                    {
                                                        Console.WriteLine($"Satisda olan mehsullarin sayi: {item.Count}");
                                                    }

                                                }

                                            }
                                            loop = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Bu tarix araligina uygun satis tapilmadi");
                                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                            {
                                                loop = false;
                                            }
                                        }
                                       
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nBu tarix araligina uygun satis yoxdur\n");
                                        if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                        {
                                            loop = false;
                                        }
                                    }

                                    
                                }
                                else
                                {
                                    Console.WriteLine("Tarix duzgun daxil edilmeyib!\n");
                                    if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                    {
                                        loop = false;
                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine("SETR BOS BURAXILA BILMEZ!\n");
                                if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                {
                                    loop = false;
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Tarix duzgun daxil edilmeyib!\n");
                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                            {
                                loop = false;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("SETR BOS BURAXILA BILMEZ!\n");
                        if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                        {
                            loop = false;
                        }
                    }

                }
                
            }
            else
            {
                Console.WriteLine("Hec bir satis bas vermeyib");
            }
            
        }

        private static void ShowSalesbyPrice()
        {
            bool loop = true;
            if (MarketMenu.Sales.Count > 0)
            {
                while (loop)
                {
                   
                    Console.WriteLine("Qiymet araligini daxil edin: ");
                    Console.Write("min. ");
                    string inputmin = Console.ReadLine();
                    double min = 0;

                    if (double.TryParse(inputmin, out min) && min > 0)
                    {
                        Console.Write("maks. ");
                        string inputmax = Console.ReadLine();
                        double max = 0;

                        if (double.TryParse(inputmax, out max) && min > 0)
                        {

                            if (MarketMenu.Sales.Exists(p => p.TotalAmount >= min && p.TotalAmount <= max))
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("*******************************************************************");
                                Console.WriteLine("                                 SATIS MELUMATLARI: ");
                                Console.WriteLine("*******************************************************************");

                                foreach (var sales in MarketMenu.GetSalesByAmount(min, max))
                                {
                                   
                                    Console.WriteLine($"\nSatislarin Nomresi: { sales.No}\nSatislarin Umimi meblegi: {sales.TotalAmount} AZN\nSatislarin tarixi: {sales.Date}");
                                    if (Helper.FindSatis(sales.No).SalesItems.Count > 0)
                                    {
                                        int count = 0;
                                        foreach (var item in Helper.FindSatis(sales.No).SalesItems)
                                        {
                                            count += item.Count;
                                        }
                                        Console.WriteLine($"Satisda olan mehsullarin sayi:{count}");
                                    }
                                    else
                                    {
                                        foreach (var item in sales.SalesItems)
                                        {

                                            Console.WriteLine($"Satisda olan mehsullarin sayi: {item.Count}");
                                        }
                                    }
                                }
                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("Bu qiymet araligina uygun satis yoxdur\n");
                                if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                {
                                    loop = false;
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("DUZGUN EDED DAXIL EDIN!\n");
                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                            {
                                loop = false;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("DUZGUN EDED DAXIL EDIN!\n");
                        if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                        {
                            loop = false;
                        }
                    }

                }
               

            }
            else
            {
                Console.WriteLine("Hec bir satis bas vermeyib\nSatis elave edin!\n");
            }


        }

        private static void ShowSalesbyDate()
        {
            bool loop = true;
            if (MarketMenu.Sales.Count>0)
            {
                while (loop)
                {
                    
                    Console.WriteLine("Tarix daxil edin (gun/ay/il)");
                    string Date = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(Date))
                    {
                        DateTime date;

                        if (DateTime.TryParse(Date, out date))
                        {
                           
                            if (MarketMenu.GetSales(date).Exists(s => s.Date.Date == date.Date))
                            {
                                foreach (var sales in MarketMenu.GetSales(date))
                                {

                                    Console.WriteLine($"\nSatis Nomresi: { sales.No}\nSatisin Umimi meblegi: {sales.TotalAmount} AZN\nTarixi: {sales.Date}");
                                    if (Helper.FindSatis(sales.No).SalesItems.Count > 0)
                                    {
                                        int count = 0;
                                        foreach (var item in Helper.FindSatis(sales.No).SalesItems)
                                        {
                                            count += item.Count;
                                        }
                                        Console.WriteLine($"Satisda olan mehsullarin sayi: {count}");
                                    }
                                    else
                                    {
                                        foreach (var item in sales.SalesItems)
                                        {

                                            Console.WriteLine($"Satisda olan mehsullarin sayi: {item.Count}");
                                        }
                                    }

                                }

                                loop = false;
                            }
                            else
                            {
                                Console.WriteLine("Bu tarixe uygun satis yoxdur");
                                if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                                {
                                    loop = false;
                                }
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Tarix duzgun daxil edilmeyib!\n");
                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                            {
                                loop = false;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("SETR BOS BURAXILA BILMEZ!\n");
                        if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                        {
                            loop = false;
                        }
                    }

                }
               
            }
            else
            {
                Console.WriteLine("Hec bir satis bas vermeyib");
            }
           
            
        }

        private static void ShowSalesbyNo()
        {
            bool loop = true;
            if (MarketMenu.Sales.Count>0)
            {
                while (loop)
                {
                    
                    Console.WriteLine("Satisin nomresini daxil edin: ");
                    string input = Console.ReadLine();
                    int No = 0;
                    if (int.TryParse(input, out No))
                    {
                        if (MarketMenu.Sales.Exists(p => p.No == No))
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("*******************************************************************");
                            Console.WriteLine("                                 SATIS MELUMATLARI: ");
                            Console.WriteLine("*******************************************************************");
                            foreach (var sales in MarketMenu.GetSalesByNo(No))
                            {

                                Console.WriteLine($"\nSatisin Nomresi: { sales.No}\nSatisin Umimi meblegi: {sales.TotalAmount} AZN\nTarixi: {sales.Date}");
                                foreach (var item in sales.SalesItems)
                                {
                                    Console.WriteLine($"\nSatisda olan mehsulun adi: {item.Mehsul.Name}\nNomresi: {item.No}\nSayi: {item.Count}");
                                }
                            }
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("Bu nomreye uygun satis yoxudur\n");
                            if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                            {
                                loop = false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYALNIZ REQEM DAXIL EDIN!\n");
                        if (!Helper.YesNo("Yeniden yoxlamaq ucun secin..."))
                        {
                            loop = false;
                        }
                    }

                }

            }
            else
            {
                Console.WriteLine("\nHECBIR SATIS BAS VERMEYIB!\n");
            }
           

        }
        #endregion
        
    }

}
