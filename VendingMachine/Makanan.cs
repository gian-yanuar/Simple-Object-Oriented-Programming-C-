using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public abstract class Makanan
    {
        private int stock;
        private double price;

        public readonly double[] notes = new double[] { 2000, 5000, 10000, 20000, 50000 };

        protected Makanan(int Stock, double Price)
        {
            this.Stock = Stock;
            this.Price = Price;
        }

        protected int Stock
        {
            get { return this.stock; }
            set { this.stock = value; }
        }

        protected double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public virtual int StockCheck(int Quantity)
        {
            if (this.stock == 0)
            {
                throw new ArgumentException($"Stock {GetType().Name} habis");
            }
            else if (this.Stock < Quantity)
            {
                throw new ArgumentException($"Stock {GetType().Name} tidak mencukupi");
            }
            
            return this.Stock;
        }

        public virtual void StockSold(int Quantity)
        {
            this.Stock -= Quantity;
        }

        public virtual void Pembayaran(double Note, int Quantity, ref double Payable, ref double Change)
        {
            if (Payable == 0)
                Payable = this.Price * (double)Quantity;
            
            Change = 0;
            Payable -= Note;
            if (Payable < 0)
            {
                Change = Payable * -1;
                Payable = 0;
            }
        }
    }
}
