using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carserv_Domain.ViewModels
{
	public class LoginVM
	{
        public int ID { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Required]
        public string UsernameorEmail { get; set; }
    }
}
