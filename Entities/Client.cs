using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClient.Entities
{
    public class Client
    {
         public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CardName { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public int CardCode { get; set; }
    }
}