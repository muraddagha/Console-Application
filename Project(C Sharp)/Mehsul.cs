using System;
using System.Collections.Generic;
using System.Text;

namespace Project_C_Sharp_
{
    class Mehsul
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Kateqoriya Kateqoriya { get; set; }
        public int Count { get; set; }
        public string Kod { get; set; }
        public Mehsul(string name,double price,Kateqoriya kateqoriya,int count,string kod)
        {
            this.Name = name;
            this.Price = price;
            this.Kateqoriya = kateqoriya;
            this.Count = count;
            this.Kod = kod;
        }
    }
}
