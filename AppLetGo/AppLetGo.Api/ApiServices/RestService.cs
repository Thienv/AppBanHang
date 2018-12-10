using AppLetGo.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AppLetGo.Api.ApiServices
{
    public interface IRestService
    {
        Task<List<HoaModel>> RefreshDataAsync();

        //Task SaveTodoItemAsync(TodoItem item, bool isNewItem);

        //Task DeleteTodoItemAsync(string id);
    }
    public class RestService: IRestService
    {
        HttpClient client;
        public List<HoaModel> hoas;
        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        //public Task DeleteTodoItemAsync(string id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<HoaModel>> RefreshDataAsync()
        {
            hoas = new List<HoaModel>();
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    hoas = JsonConvert.DeserializeObject<List<HoaModel>>(content);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"ERROR{0}", ex.Message);
            }
            return hoas;
        }

        //public Task SaveTodoItemAsync(TodoItem item, bool isNewItem)
        //{
        //    throw new NotImplementedException();
        //}
    }
}