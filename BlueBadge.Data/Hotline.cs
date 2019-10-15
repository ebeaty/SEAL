﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Hotline
    {
        [Key]
        public int HotlineId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        public bool IsTextFriendly { get; set; }
        [Required]
        public bool IsMultilingual { get; set; }
        public string Details { get; set; }
    }
}
