using HodorTutor.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Model.Provinces
{
    public interface IProvinceRepository : IRepository<Province, int>
    {
        IEnumerable<Province> FindByAreaId(int areaId);
    }
}
