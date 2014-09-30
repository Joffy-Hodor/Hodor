using HodorTutor.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Model.Tutors
{
    public interface ITutorRepository : IRepository<Tutor, Guid>
    {
        Tutor FindByUserId(int userId);
    }
}
