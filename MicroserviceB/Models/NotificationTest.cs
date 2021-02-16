using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceB.Models
{
    public class NotificationTest
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string NotifMessage { get; set; }
        public string Status { get; set; }
    }
}
