using MicroserviceB.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceB.Services.Helpers
{
    public class ConvertResponseHelper
    {
        public static ApiResponse<T> ConvertResponseToObject<T>(IRestResponse response)
        {
            try
            {
                var status = response.StatusCode.ToString();
                var data = JsonConvert.DeserializeObject<T>(response.Content);

                return new ApiResponse<T>
                {
                    Data = data,
                    Status = status
                };
            }
            catch (Exception e)
            {
                throw new Exception("Error Convert: " + e.Message);
            }
        }

        public static T GetResponseData<T>(IRestResponse response)
        {
            ApiResponse<T> responses = new ApiResponse<T>();
            T data = default(T);
            try
            {
                responses = ConvertResponseToObject<T>(response);
            }
            catch (Exception e)
            {
                data = default(T);
            }
            finally
            {
                data = responses.Data;
            }
            return data;
        }
    }
}
