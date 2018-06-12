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
        string restUrl = "http://momlyrestservice.azurewebsites.net/{0}";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<MomlyFriend>> RefreshMomlyFriends()
        {
            List<MomlyFriend> friends = new List<MomlyFriend>();

            var uri = new Uri(string.Format(restUrl, "api/walk"));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    friends = JsonConvert.DeserializeObject<List<MomlyFriend>>(content);
                }

            }
            catch (Exception)
            {
                return friends;
            }
            return friends;
        }

        public async Task<string> CreateMomlyActivity(MomlyFriend momlyFriend)
        {
            var uri = new Uri(string.Format(restUrl, "api/walk"));

            var json = JsonConvert.SerializeObject(momlyFriend);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await client.PostAsync(uri, content);
            
            if (response.IsSuccessStatusCode)
            {
                return "OK";
            }

            return "Error";
        }

        public async Task<List<CheckListItem>> RefreshCheckListItems()
        {
            List<CheckListItem> items = new List<CheckListItem>();

            var uri = new Uri(string.Format(restUrl, "api/checklist"));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<CheckListItem>>(content);
            }
            return items;
        }

        public async Task<string> RefreshPictureEvaluation()
        {
            string text = "error";
            var uri = new Uri(string.Format(restUrl, "api/picture"));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                text = JsonConvert.DeserializeObject<string>(content);
            }
            return text;
        }
    }
}
