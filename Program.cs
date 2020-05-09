using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.xNet;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading;
namespace fadit
{
    class tota
    {
        static Random random { get; set; }
        private static object syncObj = new object();
        private static void InitRandomNumber(int seed)
        {
            random = new Random(seed);
        }
        public static int GenerateRandomNumber(int max)
        {
            lock (syncObj)
            {
                if (random == null)
                    random = new Random(); // Or exception...
                return random.Next(max);
            }
        }
        StringBuilder pop = new StringBuilder("");
        public string ipcreator()
        {
            pop.Clear();

            int chunk = GenerateRandomNumber(254);
            int chunk2 = GenerateRandomNumber(254);
            int chunk3 = GenerateRandomNumber(254);
            int chunk4 = GenerateRandomNumber(254);
            //Console.WriteLine(chunk);
            //Console.WriteLine(chunk2);
            pop.Append(string.Concat(chunk + "." + chunk2 + "." + chunk3 + "." + chunk4));
            //Console.WriteLine(pop);
            return pop.ToString();



        }
    }
    class Program
    {
        public string proxy = "";
        public string monia()
        {
            
            int d = 0;

            string folder = Environment.CurrentDirectory;
            List<string> proxies = File.ReadAllLines(folder + "/proxies.txt").ToList<string>();


            d = tota.GenerateRandomNumber(proxies.Count());

            return proxies[d].ToString();
        }
        static long CountLinesInStringSlow(string s)
        {
            Regex r = new Regex("\n", RegexOptions.Multiline);
            MatchCollection mc = r.Matches(s);
            return mc.Count + 1;
        }

         public void checker ()

        { string hm = "";
            tota fun = new tota();
            string folder = System.Environment.CurrentDirectory;
            string result = "";
            StringBuilder link = new StringBuilder("");
            var t = new Program();
            hm = t.monia();
            HttpRequest request = new HttpRequest();
            request.Proxy = Socks4ProxyClient.Parse(hm);
            request.Proxy.ConnectTimeout = 5000;


            try
            {
                result = request.Get("https://api.hackertarget.com/reverseiplookup/?q=" + fun.ipcreator()).ToString();
                //Console.WriteLine(request.Get("https://api.hackertarget.com/reverseiplookup/?q=104.18.40.1"));

                if (result.Substring(0, 2) == "No")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("found 0 site hosted on this ip");
                    Console.ResetColor();
                }
                else
                {
                    link.Append(result);
                    link.Append(Environment.NewLine);
                    File.AppendAllText(folder + "/edited.txt", link.ToString());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("site found {0}", CountLinesInStringSlow(link.ToString()));
                    Console.ResetColor();
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("bad proxies");
            }
        }   
        static void Main(string[] args)
        {   
            var popsa = new Program();
            while (true)
            {
                int threads = 100;
                ThreadPool.SetMinThreads(threads, threads);
                ThreadPool.SetMaxThreads(threads, threads);
                Parallel.For(0, 100000, new ParallelOptions { MaxDegreeOfParallelism = threads },
                   index => {
                       popsa.checker();
                   });
            }
        }
    }
}
