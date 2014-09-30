using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HodorTutor.Services.Messaging.AnnounceService
{
    public class CreateAnnounceRequest
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Detail { get; set; }

        public int TagsId { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsLocked { get; set; }

    }
}
