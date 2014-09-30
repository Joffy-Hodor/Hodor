using HodorTutor.Infrastructure.UnitOfWork;
using HodorTutor.Model.Tutors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace HodorTutor.Repository.NHibernate.Repositories
{
    public class TutorRepository : Repository<Tutor, Guid>, ITutorRepository
    {
        public TutorRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Tutor> FindAll()
        {
            return Session.Query<Tutor>().ToList();
        }

        public Tutor FindByUserId(int userId)
        {
            return Session.Query<Tutor>().Where(e => e.UserId == userId).FirstOrDefault();
        }
    }
}
