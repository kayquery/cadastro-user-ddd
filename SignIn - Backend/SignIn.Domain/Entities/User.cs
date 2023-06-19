using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using SignIn.Domain.Base;
using SignIn.Domain.DTO;
using SignIn.Domain.Validations;

namespace SignIn.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(UserDTO userDTO, string? id = null)
        {
            Name = userDTO.Name;
            Document = userDTO.Document;
            Email = userDTO.Email;
            BirthDate = userDTO.BirthDate;
            ZipCode = userDTO.ZipCode;

            if (id != null)
                Id = id;
        }


        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("document")]
        public string Document { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("birthDate")]
        [LegalAge]
        public DateTime BirthDate { get; set; }

        [BsonElement("zipCode")]
        public string ZipCode { get; set; }

        public void Update(UserDTO userDTO)
        {
            Name = userDTO.Name;
            BirthDate = userDTO.BirthDate;
            ZipCode = userDTO.ZipCode;
            BirthDate = userDTO.BirthDate;
            UpdatedAt = DateTime.UtcNow;
            Email = userDTO.Email;
        }

    }
}