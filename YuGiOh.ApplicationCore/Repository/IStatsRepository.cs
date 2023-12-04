
using YuGiOh.Domain.Interfaces;
using YuGiOh.Domain.Models;


namespace YuGiOh.ApplicationCore.Repository
{
    public interface IStatsRepository
    {
        // Método para obtener la frecuencia del arquetipo campeón en un intervalo de tiempo
        public Task<IEnumerable<(Archetype Archetype, int Frequency)>> GetChampionArchetypeFrequency(IRangeTime rangeTime);
        // Método para obtener todos los campeones en un intervalo de tiempo
        public Task<IEnumerable<User>> GetAllChampionsInTimeRange(IRangeTime rangeTime);
        // Método para obtener la ubicación con más campeones en un intervalo de tiempo
        public Task<string> GetLocationWithMostChampions(IRangeTime rangeTime);
        // Método para obtener los arquetipos más populares entre los jugadores
        public Task<IEnumerable<Archetype>> GetMostPopularArchetypes(int n);
        // Método para obtener la provincia/municipio donde es más popular un arquetipo dado
        public Task<string> GetMostPopularLocationForArchetype(int ArchetypeId);
        // Método para obtener el arquetipo más utilizado en un torneo específico
        public Task<Archetype?> GetMostUsedArchetypeInTournament(int tournamentId);
        // Método para obtener los arquetipos más utilizados en una ronda específica de un torneo
        public Task<IEnumerable<Archetype>> GetMostUsedArchetypesInRound(int TournamentId, int Round);

        // Método para obtener los jugadores con más decks en su poder (ordenados de mayor a menor)
        public Task<IEnumerable<User>> GetPlayersWithMostDecks(int n);

        // Método para obtener el jugador con más victorias en un intervalo de tiempo
        public Task<IEnumerable<User>> GetPlayersWithMostVictories(int n, IRangeTime rangeTime);
        // Método para obtener los arquetipos más utilizados por al menos un jugador en los torneos
        public Task<IEnumerable<Archetype>> GetTopArchetypesUsedByAtLeastOnePlay(int n);

        // Método para obtener al campeón de un torneo específico
        public Task<User?> GetTournamentChampion(int idTournament);
    }

   
}