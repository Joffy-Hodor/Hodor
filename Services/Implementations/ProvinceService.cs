using HodorTutor.Infrastructure.UnitOfWork;
using HodorTutor.Model.Provinces;
using HodorTutor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Services.Implementations
{
    public class ProvinceService : IProvinceService
    {
        public ProvinceService(
            IUnitOfWork uow,
            IProvinceRepository provinceRepository)
        {
            _uow = uow;
            _provinceRepository = provinceRepository;
        }

        private IUnitOfWork _uow;
        private IProvinceRepository _provinceRepository;

        public IEnumerable<Province> GetListProvince()
        {
            return _provinceRepository.FindAll().ToList();
        }

        public void Add(Province request)
        {
            using (var transaction = _uow.BeginTransaction())
            {
                _provinceRepository.Create(request);
                transaction.Commit();
            }
        }
    }
}
