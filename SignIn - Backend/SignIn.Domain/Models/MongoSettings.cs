using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignIn.Domain.Models
{
    public class MongoSettings 
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}