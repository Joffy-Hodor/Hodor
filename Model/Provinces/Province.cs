using HodorTutor.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Model.Provinces
{
    public class Province : Entity<int>
    {
        public virtual int Id { get; set; }        

        public virtual string Name { get; set; }

        public virtual int AreaId { get; set; }
    }
}
