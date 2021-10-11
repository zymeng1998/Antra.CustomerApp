using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.CustomerApp.Data.Model
{
    /* For customer table in the database. */
    public class Cust
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Mobile { get; set; }
        public String EmailId { get; set; }
        public String City { get; set; }
        public String State { get; set; }

    }
}
