using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignIn.Domain.Entities;
using SignIn.Domain.Models;
using SignIn.Infra.Base;
using SignIn.Infra.Interfaces;

namespace SignIn.Infra.Repository
{
    public class UserRepository : MongoRepository<User>, IUserRepository
    {
        public UserRepository(MongoSettings settings) : base(settings) { }
    }
}