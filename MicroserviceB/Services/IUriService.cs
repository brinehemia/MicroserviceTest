using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceB.Services
{
    public enum ServiceUri { MicroserviceA, MicroserviceB };

    public interface IUriService
    {
        Uri GetAllUri(string query = null);
    }

    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;

        }

        public Uri GetAllUri(string apiPath = null)
        {
            var uri = new Uri(_baseUri);
            if (apiPath == null)
            {
                return uri;
            }

            var modifiedUri = _baseUri + "" + apiPath;
            return new Uri(modifiedUri);
        }
    }
}
