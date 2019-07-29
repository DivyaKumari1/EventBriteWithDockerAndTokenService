using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(string uri,
            string authorizationToken = null,  //for token service
            string authorizationMethod = "Bearer"); //for token service

        Task<HttpResponseMessage> PostAsync<T>(string uri,
            T item,
           string authorizationToken = null,  //for token service
           string authorizationMethod = "Bearer"); //for token service

        Task<HttpResponseMessage> PutAsync<T>(string uri,
           T item,
          string authorizationToken = null,  //for token service
          string authorizationMethod = "Bearer"); //for token service

        Task<HttpResponseMessage> DeleteAsync<T>(string uri,
          string authorizationToken = null,  //for token service
          string authorizationMethod = "Bearer"); //for token service
    }
}
