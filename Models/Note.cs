using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apirest.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Creation_date { get; set; }
        /*public DateTime Update_date { get; set; }*/
    }
}