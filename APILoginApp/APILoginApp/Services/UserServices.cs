using APILoginApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APILoginApp.Services
{
    class UserServices
    {
        private string url;
        HttpClient client;

        public UserServices()
        {
            url = "https://apiapptrainingnewapp.azurewebsites.net/api/Products";
            client = new HttpClient();
        }

        public async Task<List<UserInfo>> GetProductInfoDataAsync()
        {
            List<UserInfo> users = new List<UserInfo>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonContents = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<UserInfo>>(jsonContents);
            }
            return users;
        }

        public async Task<UserInfo> PostProductInfoAsync(UserInfo user)
        {
            string jsonRequest = JsonConvert.SerializeObject(user);
            StringContent requestContents = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, requestContents);
            if (response.IsSuccessStatusCode)
            {
                string jsonContents = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<UserInfo>(jsonContents);
            }
            return user;
        }

    }
}
