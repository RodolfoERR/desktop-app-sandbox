using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlAlmacen
{
    public class LocationResponse
    {
        public List<Location> Data { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
