using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.DTO.BacklogsEvent
{
    public class BacklogsEventDTO
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public int EventType { get; set; }

        public string Json { get; set; }
    }
}
