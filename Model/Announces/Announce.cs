using HodorTutor.Infrastructure.Domain;
using HodorTutor.Model.Tutors;
using HodorTutor.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Model.Announces
{
    public class Announce : Entity<Guid>
    {
        public Announce()
            : base()
        {
            Id = Guid.NewGuid();
        }

        public virtual Tutor Tutor { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual string Title { get; set; }

        public virtual string Detail { get; set; }

        public virtual int TagsId { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual bool IsLocked { get; set; }
    }
}
