using System;
using System.Collections.Generic;
using System.Text;

namespace Project_C_Sharp_
{
    class SalesItems
    {
        private static int _TotalNo { get; set; }
        private int _no { get; set; }
        public int No { get => _no; }
        public Mehsul Mehsul { get; set; }
        public int Count { get; set; }

        public SalesItems(Mehsul mehsul)
        {
            
            _TotalNo++;
            _no = _TotalNo;
            this.Mehsul = mehsul;

        }
        
    }
}
