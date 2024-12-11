using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassoMobil.Models
{
    public class Aktive
    {
        public int Id { get; set; }
        public int CihazId { get; set; }
        public string Takim { get; set; }
        public int Adet { get; set; }
        public string Kategori { get; set; }
        public DateTime BulunduguZaman { get; set; }
    }
}
