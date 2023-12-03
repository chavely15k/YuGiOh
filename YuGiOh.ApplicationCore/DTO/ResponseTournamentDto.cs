using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YuGiOh.ApplicationCore.DTO
{
    public class ResponseTournamentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string StartDate { get; set; }

        public int AdminId {get;set;}

        public int SignedPlayers {get; set;}
        
    }
}