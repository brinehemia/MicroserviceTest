using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceB.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {

        }
        public ApiResponse(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public string Status { get; set; }
    }

    public class Config
    {
        public int promo_grab_2020 { get; set; }
        public int max_upload_file_size { get; set; }
    }
}
