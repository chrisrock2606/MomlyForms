using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MomlyForms.Models;
using Newtonsoft.Json;

namespace MomlyForms.Data
{
    public class RestService
    {
        HttpClient client;
        string restUrl = "http://momlyrestservice.azurewebsites.net/api/walk";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<MomlyFriend>> RefreshMomlyFriends()
        {
            List<MomlyFriend> friends = new List<MomlyFriend>();

            var uri = new Uri(string.Format(restUrl, string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                friends = JsonConvert.DeserializeObject<List<MomlyFriend>>(content);
            }
            return friends;
        }

        public async Task<List<CheckListItem>> RefreshCheckListItems()
        {
            List<CheckListItem> items = new List<CheckListItem>();

            var uri = new Uri(string.Format(restUrl, string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<CheckListItem>>(content);
            }
            return items;
        }
    }
}
