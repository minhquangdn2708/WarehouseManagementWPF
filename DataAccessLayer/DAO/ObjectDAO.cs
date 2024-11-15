using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
	public class ObjectDAO
	{
		private static ObjectDAO _instance;
		private static readonly object _lock = new object();
		private readonly QuanLiKhoContext _context = new QuanLiKhoContext();

		public static ObjectDAO Instance
		{
			get
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = new ObjectDAO();
					}
					return _instance;
				}
			}
		}

		public IEnumerable<Objectss> GetAll()
		{
			return _context.Objectsses.Include(g => g.Unit).Include(g => g.Supplier).ToList();
		}

		public Objectss GetById(int id)
		{
			
				return _context.Objectsses.Include(g => g.Unit).Include(g => g.Supplier).FirstOrDefault(s => s.UnitId == id);
			
		}

		public void Add(Objectss item)
		{
			_context.Objectsses.Add(item);
			_context.SaveChanges();
		}

		public void Update(Objectss item)
		{
			_context.Objectsses.Update(item);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = _context.Objectsses.Find(id);
			if (item != null)
			{
				_context.Objectsses.Remove(item);
				_context.SaveChanges();
			}
		}
	}
}
