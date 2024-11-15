using BusinessObject;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class ObjectRepository : IObjectRepository
	{
		public IEnumerable<Objectss> GetAllObject()
		{
			return ObjectDAO.Instance.GetAll();
		}

		public Objectss GetObjectById(int ObjectssId)
		{
			return ObjectDAO.Instance.GetById(ObjectssId);
		}

		public void AddObject(Objectss Objectss)
		{
			ObjectDAO.Instance.Add(Objectss);
		}

		public void UpdateObject(Objectss Objectss)
		{
			ObjectDAO.Instance.Update(Objectss);
		}

		public void DeleteObject(int ObjectssId)
		{
			ObjectDAO.Instance.Delete(ObjectssId);
		}
	}
}
