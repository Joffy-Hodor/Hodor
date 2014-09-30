using HodorTutor.Model.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Services.Interfaces
{
    public interface IProvinceService
    {
        IEnumerable<Province> GetListProvince();

        void Add(Province request);
    }
}
