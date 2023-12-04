using AutoMapper;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Interfaces;

namespace YuGiOh.Infrastructure.Service
{
    public class StatService : AbstractStatServices, IStatServices
    {
        public StatService(IStatsRepository statsRepository, IMapper mapper) : base(statsRepository, mapper)
        {
        }

        public async Task<IEnumerable<UserDto>> GetAllChampionsInTimeRange(IRangeTime rangeTime)
        {
            var champions = await _statsRepository.GetAllChampionsInTimeRange(rangeTime);
            return _mapper.Map<IEnumerable<UserDto>>(champions);
        }

        public async Task<IEnumerable<(string ArchetypeName, int Frequency)>> GetChampionArchetypeFrequency(IRangeTime rangeTime)
        {
            var championArchetypes = await _statsRepository.GetChampionArchetypeFrequency(rangeTime);
            return championArchetypes.Select(t => (t.Archetype.Name, t.Frequency));
        }

        public async Task<IEnumerable<UserDto>> GetPlayersWithMostDecks(int n)
        {
            var playersWithMostDecks = await _statsRepository.GetPlayersWithMostDecks(n);
            return _mapper.Map<IEnumerable<UserDto>>(playersWithMostDecks);
        }

        public async Task<string> GetLocationWithMostChampions(IRangeTime rangeTime)
        {
            return await _statsRepository.GetLocationWithMostChampions(rangeTime);
        }

        public async Task<IEnumerable<string>> GetMostPopularArchetypes(int n)
        {
            var archetypes = await _statsRepository.GetMostPopularArchetypes(n);
            return archetypes.Select(archetype => archetype.Name);
        }


        public async Task<string> GetMostPopularLocationForArchetype(int ArchetypeId)
        {
            return await _statsRepository.GetMostPopularLocationForArchetype(ArchetypeId);
        }

        public async Task<string?> GetMostUsedArchetypeInTournament(int tournamentId)
        {
            var mostUsedArchetype = await _statsRepository.GetMostUsedArchetypeInTournament(tournamentId);

            // Si mostUsedArchetype es null, devuelve null; de lo contrario, devuelve el nombre del arquetipo.
            return mostUsedArchetype?.Name;
        }


        public async Task<IEnumerable<string>> GetMostUsedArchetypesInRound(int TournamentId, int Round)
        {
            var archetypes = await _statsRepository.GetMostUsedArchetypesInRound(TournamentId, Round);
            return archetypes.Select(archetype => archetype.Name);
        }


        public async Task<IEnumerable<UserDto>> GetPlayersWithMostVictories(int n, IRangeTime rangeTime)
        {
            var playersWithMostVictories = await _statsRepository.GetPlayersWithMostVictories(n, rangeTime);
            return _mapper.Map<IEnumerable<UserDto>>(playersWithMostVictories);
        }

        public async Task<IEnumerable<string>> GetTopArchetypesUsedByAtLeastOnePlay(int n)
        {
            var archetypes = await _statsRepository.GetTopArchetypesUsedByAtLeastOnePlay(n);
            return archetypes.Select(archetype => archetype.Name);
        }


        public async Task<UserDto?> GetTournamentChampion(int idTournament)
        {
            var champion = await _statsRepository.GetTournamentChampion(idTournament);
            return _mapper.Map<UserDto>(champion);
        }
    }

}