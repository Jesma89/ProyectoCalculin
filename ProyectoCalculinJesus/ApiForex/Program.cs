using System;
using ForexQuotes;

namespace TestForex
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            // https://github.com/1Forge/dotnet-forex-quotes
            var testForexDataClient = new TestForexDataClient();
            testForexDataClient.Test();

            Console.Read();
        }
    }


    public class TestForexDataClient
    {
        public async void Test()
        {
            var client = new ForexDataClient("i3drSZDmC8Kis9rruVPtCciybrr3ut3s");

            // Get the list of available symbols
            var symbols = client.GetSymbols();
            foreach (var symbol in symbols) Console.WriteLine(symbol);

            // Console.Read();


            // Get quotes for specified symbols
            var quotes = client.GetQuotes(new[] {"EURUSD", "GBPJPY", "BTCUSD"});
            foreach (var quote in quotes) Console.WriteLine(quote);

            // Console.Read();

            // Convert from one currency to another:

            var conversion = client.Convert("EUR", "USD", 100);
            Console.WriteLine(conversion);

            //Console.Read();


            // Check if the market is open:

            var marketStatus = client.GetMarketStatus();
            Console.WriteLine(marketStatus.marketIsOpen ? "The market is open!" : "The market is closed!");

            // Quota used

            var quota = client.GetQuota();
            Console.WriteLine(quota);
        }
    }
}