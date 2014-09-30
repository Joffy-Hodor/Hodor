using HodorTutor.Infrastructure.UnitOfWork;
using HodorTutor.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Repository.NHibernate.Repositories
{
    public class UserProfileRepository : Repository<UserProfile, int>, IUserProfileRepository
    {
        public UserProfileRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
