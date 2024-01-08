using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.DataModel.Entities
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set;}

        public string? SupplierName { get; set;} 

        public string? SupplierTell { get; set;}
        public string? WebSite { get; set;}
    }
}
