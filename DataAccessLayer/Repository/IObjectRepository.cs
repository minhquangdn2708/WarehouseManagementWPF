using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public interface IObjectRepository
	{
		IEnumerable<Objectss> GetAllObject();
		Objectss GetObjectById(int objecId);
		void AddObject(Objectss bbject);
		void UpdateObject(Objectss Object);
		void DeleteObject(int ObjectId);
	}
}
