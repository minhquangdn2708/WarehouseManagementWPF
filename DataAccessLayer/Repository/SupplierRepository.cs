using BusinessObject;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class SupplierRepository : ISupplierRepository
	{
		public IEnumerable<Supplier> GetAllSuppliers()
		{
			return SupplierDAO.Instance.GetAll();
		}

		public Supplier GetSupplierById(int SupplierId)
		{
			return SupplierDAO.Instance.GetById(SupplierId);
		}

		public void AddSupplier(Supplier Supplier)
		{
			SupplierDAO.Instance.Add(Supplier);
		}

		public void UpdateSupplier(Supplier Supplier)
		{
			SupplierDAO.Instance.Update(Supplier);
		}

		public void DeleteSupplier(int SupplierId)
		{
			SupplierDAO.Instance.Delete(SupplierId);
		}
	}
}
