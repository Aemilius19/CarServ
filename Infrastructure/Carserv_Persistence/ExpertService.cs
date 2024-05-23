using Carserv_Application;
using Carserv_Domain;
using Carserv_Domain.ViewModels;
using Carserv_Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carserv_Persistence
{
	public class ExpertService : IExpertService
	{
		AppDbContext _db;

		public ExpertService(AppDbContext db)
		{
			_db = db;
		}

		public void Create(ExpertSliderVM slider)
		{
			ExpertSlider sliderr= new ExpertSlider()
			{
				Desgination=slider.Designation,
				FullName=slider.FullName,
				ImgURl=slider.ImgFIle.FileName,
			};
			_db.ExpertSliders.Add(sliderr);
			_db.SaveChanges();
		}

		public void Delete(int id)
		{
			var delete=_db.ExpertSliders.FirstOrDefault(x=>x.ID==id);
			_db.ExpertSliders.Remove(delete);
			_db.SaveChanges();
		}

		public ExpertSlider Get(int id)
		{
			return _db.ExpertSliders.FirstOrDefault(x => x.ID == id);
		}

		public List<ExpertSlider> GetAll()
		{
			return _db.ExpertSliders.ToList();
		}

		public void Update(ExpertSliderVM slider)
		{
			var update=_db.ExpertSliders.FirstOrDefault(x=>x.ID== slider.ID);
			update.FullName=slider.FullName;
			update.Desgination=slider.Designation;
			update.ImgURl=slider.ImgFIle.FileName;
			_db.SaveChanges();
		}
	}
}
