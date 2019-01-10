using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppLetGo.Models;
using Newtonsoft.Json;

namespace AppLetGo.API
{
    public static class databaseservice
    {
        public static HttpClient client;
        public static ObservableCollection<LoaiHoa> Items;

        public static async Task<ObservableCollection<LoaiHoa>> RefreshDataAsync()
        {
            ObservableCollection<LoaiHoa> Itemsl = new ObservableCollection<LoaiHoa>();
            client = new HttpClient();
            string RestUrl = "http://localhost:59138/api/loaihoa";
            var uri = new Uri(string.Format(RestUrl, string.Empty));

            try
            {
                using (var response = await client.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Itemsl = JsonConvert.DeserializeObject<ObservableCollection<LoaiHoa>>(content);
                        Items = Itemsl;
                    }
                }
                    
                return Itemsl;

            }
            catch (Exception ex)
            {
                return Itemsl;
            }


        }
    }
}
