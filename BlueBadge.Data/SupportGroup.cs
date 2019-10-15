﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class SupportGroup
    {
        [Key]
        public int SupportGroupId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Website { get; set; }
        public string Details { get; set; }
    }
}
