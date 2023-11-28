using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace YuGiOh.ApplicationCore.DTO
{
    public class TournamentDto
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public Guid AdminId {get;set;}
        
    }

}