using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;


namespace YuGiOh.ApplicationCore.DTO
{
    public class TournamentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public int AdminId {get;set;}
        
    }

}