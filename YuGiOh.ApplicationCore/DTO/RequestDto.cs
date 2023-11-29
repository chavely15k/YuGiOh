using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class RequestDto
{
    public int PlayerId { get; set; }
    public int TournamentId { get; set; }
    public int DeckId { get; set; }
    public DateTimeOffset Date { get; set; }
    public string Status { get; set; }

}