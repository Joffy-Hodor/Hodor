using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Infrastructure.Mapping.Mappers
{
    public interface IMapper
    {       
        Distination Map<Source, Distination>(Source source);
    }
}
