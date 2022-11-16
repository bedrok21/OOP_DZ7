using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Examples
{
    // Mainapp test application 
    class MainApp
    {
        public static void Main()
        {
            Console.WriteLine("Input comand:");
            Console.WriteLine("0 - sell asset on Binance");
            Console.WriteLine("1 - sell asset on WhiteBit");

            TradeFecade exchange = new TradeFecade();
            int comand;
            try
            {
                comand = int.Parse(Console.ReadLine());
                if (comand == 0) { exchange.sellOnBinance(); }
                if (comand == 1) { exchange.sellOnWhiteBit(); }
            }
            catch
            {
                Console.WriteLine("wrong comand");
            }
        }
    }


    // "Subsystem ClassA" 
    class Binance
    {
        public decimal Price { get; }
        public string Adress { get; }

        public Binance()
        {
            Price = 16000; //get data from Binance in real time 
            Adress = "0xqlwfk9jtgv1o04n9i134034iverrr"; //get current user Binance asset adress
        }
        public void Sell(decimal vol)
        {
            //sell Asset
            Console.WriteLine($"Sold {vol} of asset on Binance");
        }
    }

    // Subsystem ClassB" 
    class WhiteBit
    {
        public decimal Price { get; }
        public string Adress { get; }

        public WhiteBit()
        {
            Price = 16000; //get data from WhiteBit in real time 
            Adress = "0xqlwfk9jtgv1o04n9i134034iverrr"; //get current user Wbt asset adress
        }
        public void Sell(decimal vol)
        {
            //sell Asset
            Console.WriteLine($"Sold {vol} of asset on WhiteBit");
        }
    }
    // Subsystem ClassC" 
    class ColdWallet
    {
        private string userColdAdress;
        private decimal volume;
        public ColdWallet()
        {
            userColdAdress = "0xbtTUQJk8q94buyiqKMkj4y382";
            volume = 1;
        }
        public void Send(string adress, decimal vol)
        {
            //sending asset
            Console.WriteLine($"Sent {vol} of asset to {adress}");
        }
    }
    // "Facade" 
    class TradeFecade
    {
        Binance banan;
        WhiteBit wbt;
        ColdWallet cold;

        public TradeFecade()
        {
            banan = new Binance();
            wbt = new WhiteBit();
            cold = new ColdWallet();
        }

        public void sellOnBinance()
        {
            cold.Send(banan.Adress, (decimal)0.1);
            banan.Sell((decimal)0.1);
        }

        public void sellOnWhiteBit()
        {
            cold.Send(wbt.Adress, (decimal)0.1);
            wbt.Sell((decimal)0.1);
        }
    }
}
