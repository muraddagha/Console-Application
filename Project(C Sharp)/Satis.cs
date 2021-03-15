using System;
using System.Collections.Generic;
using System.Text;

namespace Project_C_Sharp_
{
    class Satis
    {
        private static int _TotalNo { get; set; }
        private int _no { get; set; }
        public int No { get => _no; }

        public double TotalAmount { get; set; }
        public List<SalesItems> SalesItems { get; set; }
        
        public DateTime Date { get; set; }
        
        public Satis(List<SalesItems> salesItems)  
        {
            _TotalNo++;
            this._no = _TotalNo;
            Date = DateTime.Now;

            SalesItems = new List<SalesItems>();
            this.SalesItems = salesItems;

            foreach (var item in SalesItems)
            {
                TotalAmount += item.Count * item.Mehsul.Price;
            }
        }

    }
}
