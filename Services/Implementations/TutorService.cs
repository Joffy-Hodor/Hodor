using HodorTutor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HodorTutor.Services.Messaging;
using HodorTutor.Infrastructure.UnitOfWork;
using HodorTutor.Model.Tutors;
using HodorTutor.Model.Provinces;

namespace HodorTutor.Services.Implementations
{
    public class TutorService : ITutorService
    {
        public TutorService(
            IUnitOfWork uow,
            ITutorRepository tutorRepository,
            IProvinceRepository provinceRepository)
        {
            _uow = uow;
            _tutorRepository = tutorRepository;
            _provinceRepository = provinceRepository;
        }

        private IUnitOfWork _uow;
        private ITutorRepository _tutorRepository;
        private IProvinceRepository _provinceRepository;

        public Tutor GetTutorByUserId(int UserId)
        {
            return _tutorRepository.FindByUserId(UserId);
        }


        public IEnumerable<Tutor> GetAllTutors()
        {
            return _tutorRepository.FindAll();
        }

        public void Register(TutorRequest request)
        {
            Tutor tutor = new Tutor();
            var existTutor = _tutorRepository.FindByUserId(request.UserId);

            if (existTutor == null) //create new
            {
                tutor.UserId = request.UserId;
                tutor.FirstName = request.FirstName;
                tutor.LastName = request.LastName;
                tutor.Address = request.Address;
                tutor.City = request.City;
                tutor.TelephoneNumber = request.TelephoneNumber;
            }
            else //modify
            {
                existTutor.FirstName = request.FirstName;
                existTutor.LastName = request.LastName;
                existTutor.Address = request.Address;
                existTutor.City = request.City;
                existTutor.TelephoneNumber = request.TelephoneNumber;
            }
            using (var transaction = _uow.BeginTransaction())
            {
                if (existTutor == null)
                    _tutorRepository.Create(tutor);
                else
                    _tutorRepository.Modify(existTutor);
                transaction.Commit();
            }
        }
    }
}
