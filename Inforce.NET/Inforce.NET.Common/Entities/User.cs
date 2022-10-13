using Inforce.NET.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inforce.NET.Common.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public UserRole Role { get; set; }

        public string FullName { get; set; } = null!;

        public List<ShortedUrl> OwnedUrls { get; set; } = new();
    }
}
