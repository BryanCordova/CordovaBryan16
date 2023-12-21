using System;
using System.Collections.Generic;
using System.Text;

namespace CordobaBryan16.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string expirationDate { get; set; }
        public bool isNew { get; set; }
        public int stock { get; set; }

    }
}
