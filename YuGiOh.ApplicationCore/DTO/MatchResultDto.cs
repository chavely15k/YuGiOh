using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YuGiOh.ApplicationCore.DTO
{
    public class MatchResultDto
    {
        public int PlayerOneId { get; set; }
        public int PlayerTwoId { get; set; }
        public string PlayerOneNick { get; set; }
        public string PlayerTwoNick { get; set; }
        public DateTime Date { get; set; }
        public int TournamentId { get; set; }
        public int PlayerOneResult { get; set; }
        public int PlayerTwoResult { get; set; }
        public int Round { get; set; }
        public int Group { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}