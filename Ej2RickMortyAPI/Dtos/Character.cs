using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2RickMortyAPI.Dtos
{
    public class Character
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
    }
}
