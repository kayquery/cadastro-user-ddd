using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SignIn.Domain.Validations;

namespace SignIn.Domain.DTO
{
    public class UserDTO
    {
        public string Name { get; set;}
        public string Document { get; set; }
        public string Email { get; set;}
        [LegalAge]
        public DateTime BirthDate { get; set; }
        [StringLength(8, MinimumLength = 8)]
        public string ZipCode { get; set;}
    }
}