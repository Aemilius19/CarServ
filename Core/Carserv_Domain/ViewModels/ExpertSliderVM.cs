using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carserv_Domain.ViewModels
{
	public class ExpertSliderVM
	{
        public int ID { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string FullName { get; set; }
		[Required]
		[MinLength(1)]
		[MaxLength(100)]
		public string Designation { get; set; }
        [NotMapped]
        public IFormFile ImgFIle { get; set; }

    }
}
