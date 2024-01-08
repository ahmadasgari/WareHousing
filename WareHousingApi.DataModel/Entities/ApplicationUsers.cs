using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHousingApi.DataModel.Entities
{
    public class ApplicationUsers: IdentityUser<string>
    {
        public string? FirstName { get; set; }
        public string? Family { get; set; }
        public string? UserImage { get; set; }
        public string? MeliCode { get; set; }
        public string? PersonalCode { get; set; }
        public DateTime BirthDayDate { get; set; }
        public bool Gender { get; set; }
        public byte UserType { get; set; }
    }
}
