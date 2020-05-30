using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Launch
    {
        static void Main(string[] args)
        {
            Makanan biskuit = new Biskuit(10, 6000);
            Makanan chips = new Chips(10, 8000);
            Makanan oreo = new Oreo(10, 10000);
            Makanan tango = new Tango(10, 12000);
            Makanan cokelat = new Cokelat(10, 15000);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("**** Self-service Vending Machine ****");
                Console.WriteLine("1.Biskuit Price 6000");
                Console.WriteLine("2.Chips Price 8000");
                Console.WriteLine("3.Oreo Price 10000");
                Console.WriteLine("4.Tango Price 12000");
                Console.WriteLine("5.Cokelat Price 15000");

                Console.WriteLine("Pilih sesuai angka :");
                int item = int.Parse(Console.ReadLine());

                switch (item)
                {
                    case 1:
                        Transaksi(biskuit);
                        break;
                    case 2:
                        Transaksi(chips);
                        break;
                    case 3:
                        Transaksi(oreo);
                        break;
                    case 4:
                        Transaksi(tango);
                        break;
                    case 5:
                        Transaksi(cokelat);
                        break;
                }
            }

        }

        private static void Transaksi(Makanan makanan)
        {
            try
            {
                double note = 0;
                double remainamount = 0;
                double changeamount = 0;

                Console.WriteLine("Masukan jumlah :");
                int quantity = int.Parse(Console.ReadLine());

                int stock = makanan.StockCheck(quantity);

                do
                {
                    Console.WriteLine("Masukan uang pecahan (2000, 5000, 10000, 20000, 50000):");
                    note = double.Parse(Console.ReadLine());
                    makanan.Pembayaran(note, quantity, ref remainamount, ref changeamount);
                    Console.WriteLine($"sisa bayar : {remainamount.ToString()}");
                    Console.WriteLine($"kembalian : {changeamount.ToString()}");
                    Console.WriteLine(" ");

                } while (remainamount != 0);

                makanan.StockSold(quantity);

                Console.WriteLine("Transaksi selesai");
                Console.WriteLine(" ");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(" ");
                Console.ReadKey();
            }
        }


    }
}
