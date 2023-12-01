using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.Domain.Models;

namespace YuGiOh.ApplicationServices.Service
{
    public interface ITournamentMatchService
    {
        public Task<bool> InitGroupPhase(int Id);
        
    }
}
