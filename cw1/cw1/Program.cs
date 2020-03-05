using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            args = new[] { "https://www.pja.edu.pl" };
            // var to skrocony zapis dla HttpClient jak w javie
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(args[0]);

            if (response.IsSuccessStatusCode)
            {
                string html = await response.Content.ReadAsStringAsync();
                var emailRegex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+");
                var matches = emailRegex.Matches(html);
                foreach(var match in matches)
                {
                    Console.WriteLine(match);
                }
            }


            Console.WriteLine("End");
        }
    }
}
