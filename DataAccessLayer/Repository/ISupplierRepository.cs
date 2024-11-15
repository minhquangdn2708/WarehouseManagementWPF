using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public interface ISupplierRepository
	{
		IEnumerable<Supplier> GetAllSuppliers();
		Supplier GetSupplierById(int supplierId);
		void AddSupplier(Supplier supplier);
		void UpdateSupplier(Supplier supplier);
		void DeleteSupplier(int supplierId);
	}
}
