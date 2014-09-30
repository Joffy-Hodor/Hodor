using HodorTutor.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Model.Users
{
    public class UserProfile : Entity<int>
    {  
        public virtual int UserId { get; set; }
        public virtual string UserName { get; set; }
    }
}
