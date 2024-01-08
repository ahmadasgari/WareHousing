using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Contract;

namespace WareHousingApi.DataModel.Entities
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public PackingType? PackingType { get; set; }
        public int CountInPacking { get; set; }
        public int ProductWeight { get; set; }
        public string? ProductImage { get; set; }
        public byte IsRefregerator { get; set; }
        public int SuplierId { get; set; }
        public int CountryId { get; set; }

        #region Relation
        [ForeignKey("SuplierId")]
        public virtual Supplier? Supplier { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }
        #endregion
    }
}
