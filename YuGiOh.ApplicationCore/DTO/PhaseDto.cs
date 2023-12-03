using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;


namespace YuGiOh.ApplicationCore.DTO
{
    public class PhaseDto
    {
        public int TournamentId { get; set; }
        public int Round {get;set;}
        public int Group { get; set; }
        public int Base { get; set; }
    }
}