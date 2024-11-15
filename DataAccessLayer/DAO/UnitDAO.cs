using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
	public class UnitDAO
	{
		private static UnitDAO _instance;
		private static readonly object _lock = new object();
		private readonly QuanLiKhoContext _context = new QuanLiKhoContext();

		public static UnitDAO Instance
		{
			get
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = new UnitDAO();
					}
					return _instance;
				}
			}
		}

		public IEnumerable<Unit> GetAll()
		{
			return _context.Units.ToList();
		}

		public Unit GetById(int id)
		{
			if (_context.Units.FirstOrDefault(s => s.UnitId == id) == null)
			{
				return _context.Units.First();
			}
			else { return _context.Units.FirstOrDefault(s => s.UnitId == id); 
			}
		}

		public void Add(Unit item)
		{
			_context.Units.Add(item);
			_context.SaveChanges();
		}

		public void Update(Unit item)
		{
			_context.Units.Update(item);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = _context.Units.Find(id);
			if (item != null && item.UnitName.Equals("(no unit)")) {
				return;
			}
			if (item != null)
			{
				item.UnitName = "(no unit)";
				_context.Units.Update(item);
				_context.SaveChanges();
			}
		}
	}
}
