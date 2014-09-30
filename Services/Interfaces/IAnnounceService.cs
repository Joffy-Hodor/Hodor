using HodorTutor.Model.Announces;
using HodorTutor.Services.Messaging.AnnounceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Services.Interfaces
{
    public interface IAnnounceService
    {
        IEnumerable<Announce> GetAllAnnounce();

        void CreateAnnounce(CreateAnnounceRequest request);

    }
}
