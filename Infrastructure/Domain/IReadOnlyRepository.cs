using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, TId>
    {
        T FindById(TId id);

        IEnumerable<T> FindAll();
    }
}
