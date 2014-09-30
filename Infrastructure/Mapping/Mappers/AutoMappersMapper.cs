using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HodorTutor.Infrastructure.Mapping.Mappers
{
    public class AutoMappersMapper : IMapper
    {
        public Distination Map<Source, Distination>(Source source)
        {
            return Mapper.Map<Source, Distination>(source);
        }
    }
}
