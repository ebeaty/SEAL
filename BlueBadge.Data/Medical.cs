using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Medical
    {
        [Key]
        public int MedicalId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        public bool FinancialAid { get; set; }
        public string Details { get; set; }
    }
}
