using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp80
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await GebeZahlenAus();
        }


        #region AsynEnumarable with yield return

        //https://docs.microsoft.com/de-de/aspnet/core/web-api/action-return-types?view=aspnetcore-5.0
        // Wird verwendet bei Service Layer / Clients z.b grpc oder WebAPI (Return Values) 
        public static async IAsyncEnumerable<int> GeneriereZahlen()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i; // i wird zu zahl zugewiesen
            }
        } //Hier verlässt er die Methode

        public static async Task GebeZahlenAus()
        {
            await foreach (int zahl in GeneriereZahlen())
            {
                Console.WriteLine(zahl);
            }
        }

        #endregion
    }
}
