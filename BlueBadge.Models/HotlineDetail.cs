using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class HotlineDetail
    {
        public int HotlineId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public bool IsTextFriendly { get; set; }
        public bool IsMultilingual { get; set; }
        public string Details { get; set; }
    }
}
