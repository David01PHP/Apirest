using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apirest.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Creation_date { get; set; }
        public int Id_priority { get; set; }
    }

    
}