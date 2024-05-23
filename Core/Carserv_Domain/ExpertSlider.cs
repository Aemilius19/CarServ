using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carserv_Domain
{
	public class ExpertSlider
	{
        public int ID { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string FullName { get; set; }

		[Required]
		[MinLength(1)]
		[MaxLength(100)]
		public string Desgination { get; set; }
		

		[MinLength(1)]
		[MaxLength(100)]
		public string? ImgURl { get; set; }
    }
}
