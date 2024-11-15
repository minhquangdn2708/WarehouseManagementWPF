using BusinessObject;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class UnitRepository : IUnitRepository
	{
		public IEnumerable<Unit> GetAllUnits()
		{
			return UnitDAO.Instance.GetAll();
		}

		public Unit GetUnitById(int UnitId)
		{
			return UnitDAO.Instance.GetById(UnitId);
		}

		public void AddUnit(Unit Unit)
		{
			UnitDAO.Instance.Add(Unit);
		}

		public void UpdateUnit(Unit Unit)
		{
			UnitDAO.Instance.Update(Unit);
		}

		public void DeleteUnit(int UnitId)
		{
			UnitDAO.Instance.Delete(UnitId);
		}
	}
}
