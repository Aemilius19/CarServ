using Carserv_Domain;
using Carserv_Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carserv_Application
{
	public interface IExpertService
	{
		List<ExpertSlider> GetAll();

		ExpertSlider Get(int id);

		void Create(ExpertSliderVM slider);

		void Delete(int id);

		void Update(ExpertSliderVM slider);
	}
}
