using HodorTutor.Infrastructure.UnitOfWork;
using HodorTutor.Model.Announces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Repository.NHibernate.Repositories
{
    public class AnnounceRepository : Repository<Announce, Guid>, IAnnounceRepository
    {
        public AnnounceRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
