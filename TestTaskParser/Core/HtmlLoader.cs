using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestTaskParser.Interfaces;

namespace TestTaskParser.Core
{
    public class HtmlLoader
    {
        private readonly HttpClient _client;
        private readonly string _url;
        private readonly Dictionary<string, string> _headers;

        public HtmlLoader(IClientSettings settings)
        {
            _client = new HttpClient();
            _url = $"{settings.BaseUrl}/{settings.Prefix}/";
            _headers = settings.Headers;
        }


        public async Task<Response> GetRequest()
        {
            var response = new Response();
            try
            {
                _client.DefaultRequestHeaders.Clear();
                foreach (var item in _headers)
                {
                    _client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

                var responseMessage = await _client.GetAsync(_url);
                responseMessage.EnsureSuccessStatusCode();
                var message = await responseMessage.Content.ReadAsStringAsync();
                response.Message = message;
                response.IsError = false;
            }
            catch (Exception e)
            {
                response.MessageError = e.Message;
                response.IsError = true;
            }
            return response;
        }
    }
}
