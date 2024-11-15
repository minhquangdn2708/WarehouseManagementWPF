using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public interface IUnitRepository
	{
		IEnumerable<Unit> GetAllUnits();
		Unit GetUnitById(int unitId);
		void AddUnit(Unit unit);
		void UpdateUnit(Unit unit);
		void DeleteUnit(int unitId);
	}
}
