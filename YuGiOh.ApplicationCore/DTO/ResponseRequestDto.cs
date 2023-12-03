using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YuGiOh.ApplicationCore.DTO
{
    public class ResponseRequestDto
    {
        public int PlayerId { get; set; }
        public int TournamentId { get; set; }
        public int DeckId { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string PlayerName {get; set;}
        public string TournamentName {get; set;}      
    }
}