using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Entities;
using WareHousingApi.DataModel.Services.Repository;

namespace WareHousingApi.DataModel.Services.Interface
{
    public interface IUnitOfWork
    {
        GenericCRUDClass<ApplicationUsers> userManagerUW {  get; }
        public GenericCRUDClass<ApplicationRoles> roleManagerUW { get; }
        public GenericCRUDClass<Country> countryUW { get; }
        public GenericCRUDClass<Products> productUW  { get; }
        public GenericCRUDClass<Supplier> supplierUW { get; }

        void Save();
        void SaveAsync();

    }
}
