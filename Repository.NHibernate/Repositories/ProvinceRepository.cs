using HodorTutor.Infrastructure.UnitOfWork;
using HodorTutor.Model.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace HodorTutor.Repository.NHibernate.Repositories
{
    public class ProvinceRepository : Repository<Province, int>, IProvinceRepository
    {
        public ProvinceRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Province> FindByAreaId(int areaId)
        {
            return Session.Query<Province>()
                .Where(b => b.AreaId == areaId)
                .ToList();
        }
    }
}
