using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.DAO
{
	public class InputDAO
	{
		private static InputDAO _instance;
		private static readonly object _lock = new object();
		private readonly QuanLiKhoContext _context = new QuanLiKhoContext();

		public static InputDAO Instance
		{
			get
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = new InputDAO();
					}
					return _instance;
				}
			}
		}

		public IEnumerable<InputInfo> GetAll()
		{
			return _context.InputInfos
				.Include(i => i.Object)
				.ToList();
		}

		public InputInfo GetById(int id)
		{
			return _context.InputInfos
				.Include(i => i.Object)
				.FirstOrDefault(i => i.InputInfoId == id);
		}

		public void Add(InputInfo item)
		{
			_context.InputInfos.Add(item);
			_context.SaveChanges();
		}

		public void Update(InputInfo item)
		{
			_context.InputInfos.Update(item);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = _context.InputInfos.Find(id);
			if (item != null)
			{
				_context.InputInfos.Remove(item);
				_context.SaveChanges();
			}
		}
        public InputInfo GetByObjectId(int objectId)
        {
            return _context.InputInfos.FirstOrDefault(i => i.ObjectId == objectId);
        }
    }
}
