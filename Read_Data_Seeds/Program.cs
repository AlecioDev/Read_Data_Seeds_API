using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace Read_Data_Seeds
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Leitura de arquivo .TXT
            List<Seed> list = new List<Seed>();
            string[] array = System.IO.File.ReadAllLines("C:\\Data_Application\\seeds.txt");

            for (int i = 0; i < array.Length; i++)
            {
                Seed a = new Seed();

                string[] tabela = array[i].Split(',');
                a.SeedType = tabela[0];
                a.SeedLevel = 100 * Convert.ToDouble(tabela[1], CultureInfo.InvariantCulture);
                a.SeedStatus = tabela[2];
                a.PlantingDate = Convert.ToDateTime(tabela[3]);
                list.Add(a);
            }

            //Envia valores p/ API
            var json = JsonConvert.SerializeObject(list);
            StringContent? httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://localhost:7073/Controller_Seeds/Process_Data", httpContent);

            //Retona valores
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);
            Console.ReadKey();
            
        }
    }
}


