using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace drill_csharp
{
    public class DrillBit
    {
        private readonly HttpClient _client;
        private string _address;
        
        public DrillBit(HttpClient httpClient, IConfiguration configuration)
        {
            _client = httpClient;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _address = configuration["drillAddress"];
        }

        public async Task<string> PostRequest(string url, Dictionary<string, string> body)
        {
            var content = JsonConvert.SerializeObject(body);
            var con = new StringContent(content, Encoding.UTF8,
                                    "application/json");
            var response = await _client.PostAsync(_address + url, con);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;

            }
            else
            {
                var resContent = await response.Content.ReadAsStringAsync();
                var message = $"Failed with code {response.StatusCode.ToString()} and message: {resContent}";
                throw new Exception(message);
            }
        }
    }
}
