using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Oreo : Makanan
    {
        public Oreo(int Stock, double Price)
            : base(Stock, Price)
        {
        }

        // polymorphism example
        // duplicate code, just to perform polymorphism
        public override void Pembayaran(double note, int quantity, ref double payable, ref double change)
        {
            if (base.notes.Contains(note))
            {
                base.Pembayaran(note, quantity, ref payable, ref change);
            }
            else
            {
                throw new ArgumentException("Pecahan tidak dikenali, transaksi dibatalkan");
            }
        }
    }
}
