using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace YuGiOh.ApplicationCore.DTO
{
    public class CreateTournamentDto
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public DateTime StartDate { get; set; }

        public int AdminId {get;set;}
        
    }

}