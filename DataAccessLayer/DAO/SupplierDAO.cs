using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
	public class SupplierDAO
	{
		private static SupplierDAO _instance;
		private static readonly object _lock = new object();
		private readonly QuanLiKhoContext _context = new QuanLiKhoContext();

		public static SupplierDAO Instance
		{
			get
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = new SupplierDAO();
					}
					return _instance;
				}
			}
		}

		public IEnumerable<Supplier> GetAll()
		{
			return _context.Suppliers.ToList();
		}

		public Supplier GetById(int id)
		{
			if (_context.Suppliers.FirstOrDefault(s => s.SupplierId == id) == null)
			{
				return _context.Suppliers.First();
			}
			else
			{
				return _context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
			}
		}

		public void Add(Supplier item)
		{
			_context.Suppliers.Add(item);
			_context.SaveChanges();
		}

		public void Update(Supplier item)
		{
			_context.Suppliers.Update(item);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = _context.Suppliers.Find(id);
			if (item != null && item.SupplierName.Equals("(no supplier)"))
			{
				return;
			}
			if (item != null)
			{
				item.SupplierName = "(no supplier)";
				_context.Suppliers.Update(item);
				_context.SaveChanges();
			}
		}
	}
}
