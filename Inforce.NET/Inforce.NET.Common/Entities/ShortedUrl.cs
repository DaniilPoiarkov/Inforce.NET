using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Inforce.NET.Common.Entities
{
    public class ShortedUrl
    {
        public int Id { get; set; }
        
        public string? URL { get ; set; }

        public DateTime CreatedDate { get; set; }

        public User? CreatedBy { get; set; }

        public int CreatedById { get; set; }
    }
}
