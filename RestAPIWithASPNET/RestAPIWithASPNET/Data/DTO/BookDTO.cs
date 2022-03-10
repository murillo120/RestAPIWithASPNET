using RestAPIWithASPNET.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASPNET.Data.DTO
{
    public class BookDTO
    {
        public long Id { get; set; }

        public string Author { get; set; }

        
        public DateTime LaunchDate { get; set; }

       
        public decimal Price { get; set; }

        
        public string Title { get; set; }
    }
}
