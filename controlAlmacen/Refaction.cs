using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlAlmacen
{

    public class RefactionResponse
    {
        public List<Refaction> Data { get; set; }  

    }

    public class RefactionSingleResponse
    {
        public string Message { get; set; }
        public Refaction Data { get; set; }
    }

    public class Refaction
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public int Total_quantity { get; set; }
        public int Unit_price { get; set; } 
        public bool Active { get; set; } 
        [JsonProperty("location_id")]
        public int LocationId { get; set; }
        public string Image { get; set; }

        public string LocationName { get; set; }

        public string ImageUrl { get; set; }
        
    }

    
}
