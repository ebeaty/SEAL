using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models
{
    public class MedicalDetail
    {
        public int MedicalId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        [Display(Name="Financial Aid Available")]
        public bool FinancialAid { get; set; }
        public string Details { get; set; }
    }
}
