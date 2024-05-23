using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carserv_Domain.ViewModels
{
	public class RegisterVM
	{
        [Required]
        public int ID { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Surname { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RepeatPassword { get; set; }


    }
}
