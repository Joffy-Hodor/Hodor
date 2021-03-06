﻿using HodorTutor.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Model.Announces
{
    public interface IAnnounceRepository : IRepository<Announce, Guid>
    {
    }
}
