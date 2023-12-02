using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YuGiOh.ApplicationCore.DTO
{
    public class ResponseDeckDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ArchetypeName { get; set; }
        public int? ArchetypeId { get; set; }
        public string? PlayerName { get; set; }
        public int? PlayerId { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}