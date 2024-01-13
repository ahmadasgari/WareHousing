using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Entities;
using WareHousingApi.DataModel.Services.Interface;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class UnitOfWork : IDisposable , IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
                _context = context;
        }
        private GenericCRUDClass<ApplicationUsers> _userManager;  
        private GenericCRUDClass<ApplicationRoles> _roleManager;
        private GenericCRUDClass<Products> _product;
        private GenericCRUDClass<Supplier> _supplier;
        private GenericCRUDClass<Country> _country;

        public GenericCRUDClass<ApplicationUsers> userManagerUW
        {
            get {
                if (_userManager == null)
                {
                    _userManager = new GenericCRUDClass<ApplicationUsers>(_context);
                }
                return _userManager;
            }
        }
        public GenericCRUDClass<ApplicationRoles> roleManagerUW
        {
            get
            {
                if (_roleManager == null)
                {
                    _roleManager = new GenericCRUDClass<ApplicationRoles>(_context);
                }
                return _roleManager;
            }
        }
        public GenericCRUDClass<Country> countryUW
        {
            get
            {
                if (_country == null)
                {
                    _country = new GenericCRUDClass<Country>(_context);
                }
                return _country;
            }
        }
        public GenericCRUDClass<Products> productUW
        {
            get
            {
                if (_product == null)
                {
                    _product = new GenericCRUDClass<Products>(_context);
                }
                return _product;
            }
        }
        public GenericCRUDClass<Supplier> supplierUW
        {
            get
            {
                if (_supplier == null)
                {
                    _supplier = new GenericCRUDClass<Supplier>(_context);
                }
                return _supplier;
            }
        }
        public IEntityTransaction BeginTransaction()
        {
            return new EntityTransaction(_context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
