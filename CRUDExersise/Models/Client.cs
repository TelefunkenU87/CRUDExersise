using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
    }
}
