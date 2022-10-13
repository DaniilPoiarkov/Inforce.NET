using Inforce.NET.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inforce.NET.Common.DTOs
{
    public class ShortedUrlDto
    {
        public int Id { get; set; }

        public string? URL { get; set; }

        public string? ShortUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        public User? CreatedBy { get; set; }

        public int CreatedById { get; set; }
    }
}
