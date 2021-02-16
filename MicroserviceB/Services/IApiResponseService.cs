using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceB.Services
{
    public interface IApiResponseService
    {
        Task<IRestResponse> GetResponse(string url);
        Task<IRestResponse> PostResponse(string url, object data);
        Task<IRestResponse> PutResponse(string url, object data);
        Task<IRestResponse> DeleteResponse(string url);
    }

    public class GetResponseService : IApiResponseService
    {
        private IUriService _uriService;
        public GetResponseService(IUriService uriService)
        {
            _uriService = uriService;
        }

        public async Task<IRestResponse> GetResponse(string url)
        {
            var getUrl = _uriService.GetAllUri(url);
            var client = new RestClient(getUrl);

            var request = new RestRequest(Method.GET);
            //request.AddHeader("X-Api-Key", "");
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<IRestResponse> PostResponse(string url, object data)
        {
            var getUrl = _uriService.GetAllUri(url);
            var client = new RestClient(getUrl);

            var request = new RestRequest(Method.POST);
            //request.AddHeader("X-Api-Key", "");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(data);
            var response = await client.ExecuteAsync(request);

            return response;
        }

        public async Task<IRestResponse> PutResponse(string url, object data)
        {
            var getUrl = _uriService.GetAllUri(url);
            var client = new RestClient(getUrl);

            var request = new RestRequest(Method.PUT);
            request.AddHeader("X-Api-Key", "");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(data);
            var response = await client.ExecuteAsync(request);

            return response;
        }

        public async Task<IRestResponse> DeleteResponse(string url)
        {
            var getUrl = _uriService.GetAllUri(url);
            var client = new RestClient(getUrl);
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("X-Api-Key", "");
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
