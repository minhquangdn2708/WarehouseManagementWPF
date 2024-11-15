using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.DAO
{
	public class OutputDAO
	{
		private static OutputDAO _instance;
		private static readonly object _lock = new object();
		private readonly QuanLiKhoContext _context = new QuanLiKhoContext();

		public static OutputDAO Instance
		{
			get
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = new OutputDAO();
					}
					return _instance;
				}
			}
		}

		public IEnumerable<OutputInfo> GetAll()
		{
			return _context.OutputInfos
				.Include(o => o.Customer)
				.Include(o => o.InputInfo)
				.Include(o => o.Object)
				.ToList();
		}

		public OutputInfo GetById(int id)
		{
			return _context.OutputInfos
				.Include(o => o.Customer)
				.Include(o => o.InputInfo)
				.Include(o => o.Object)
				.FirstOrDefault(o => o.OutputInfoId == id);
		}

		public void Add(OutputInfo item)
		{
			_context.OutputInfos.Add(item);
			_context.SaveChanges();
		}

		public void Update(OutputInfo item)
		{
			_context.OutputInfos.Update(item);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = _context.OutputInfos.Find(id);
			if (item != null)
			{
				_context.OutputInfos.Remove(item);
				_context.SaveChanges();
			}
		}
	}
}
