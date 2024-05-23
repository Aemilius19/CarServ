using Carserv_Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carserv_Persistence.DAL
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
		public DbSet<ExpertSlider> ExpertSliders { get; set; }
	}
}
