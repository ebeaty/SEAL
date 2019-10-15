using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class HotlineCreate
    {
        [Required]
        [MaxLength(140)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string Website { get; set; }
        [Required]
        public bool IsTextFriendly { get; set; }
        [Required]
        public bool IsMultilingual { get; set; }
        [MaxLength(800)]
        public string Details { get; set; }
    }
}
