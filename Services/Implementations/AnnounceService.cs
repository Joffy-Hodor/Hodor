using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HodorTutor.Services.Interfaces;
using HodorTutor.Infrastructure.UnitOfWork;
using HodorTutor.Model.Announces;
using HodorTutor.Services.Messaging.AnnounceService;
using HodorTutor.Model.Tutors;
using HodorTutor.Model.Users;

namespace HodorTutor.Services.Implementations
{
    public class AnnounceService : IAnnounceService
    {
        public AnnounceService(
            IUnitOfWork uow,
            IAnnounceRepository annonceRepository,
            ITutorRepository tutorRepository,
            IUserProfileRepository userProfileRepository)
        {
            _uow = uow;
            _annonceRepository = annonceRepository;
            _tutorRepository = tutorRepository;
            _userProfileRepository = userProfileRepository;
        }

        private IUnitOfWork _uow;
        private IAnnounceRepository _annonceRepository;
        private ITutorRepository _tutorRepository;
        private IUserProfileRepository _userProfileRepository;

        public IEnumerable<Announce> GetAllAnnounce()
        {
            return _annonceRepository.FindAll();
        }

        public void CreateAnnounce(CreateAnnounceRequest announce)
        {
            Announce newAnnounce = new Announce();
            newAnnounce.TagsId = announce.TagsId;
            newAnnounce.Title = announce.Title;
            newAnnounce.UserProfile = _userProfileRepository.FindById(announce.UserId);
            newAnnounce.Detail = announce.Detail;
            newAnnounce.CreateDate = announce.CreateDate;
            newAnnounce.Tutor = _tutorRepository.FindByUserId(announce.UserId);
            using (var transaction = _uow.BeginTransaction())
            {
                _annonceRepository.Create(newAnnounce);
                transaction.Commit();
            }
        }

    }
}
