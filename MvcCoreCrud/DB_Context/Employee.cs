using System;
using System.Collections.Generic;

#nullable disable

namespace MvcCoreCrud.DB_Context
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}
