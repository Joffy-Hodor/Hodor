using HodorTutor.Model.Tutors;
using HodorTutor.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Services.Interfaces
{
    public interface ITutorService
    {
        Tutor GetTutorByUserId(int UserId);

        IEnumerable<Tutor> GetAllTutors();

        void Register(TutorRequest request);
    }
}
