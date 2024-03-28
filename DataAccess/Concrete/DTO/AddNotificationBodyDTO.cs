using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.DTO
{
    public class AddNotificationBodyDTO
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public User Owner { get; set; }
    }
}
