
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Interfaces;


namespace YuGiOh.ApplicationServices.Service
{
    public interface IStatServices
    {
        // Método para obtener la frecuencia del arquetipo campeón en un intervalo de tiempo
        public Task<IEnumerable<(string ArchetypeName, int Frequency)>> GetChampionArchetypeFrequency(IRangeTime rangeTime);
        // Método para obtener todos los campeones en un intervalo de tiempo
        public Task<IEnumerable<UserDto>> GetAllChampionsInTimeRange(IRangeTime rangeTime);
        // Método para obtener la ubicación con más campeones en un intervalo de tiempo
        public Task<string> GetLocationWithMostChampions(IRangeTime rangeTime);
        // Método para obtener los arquetipos más populares entre los jugadores
        public Task<IEnumerable<string>> GetMostPopularArchetypes(int n);
        // Método para obtener la provincia/municipio donde es más popular un arquetipo dado
        public Task<string> GetMostPopularLocationForArchetype(int ArchetypeId);
        // Método para obtener el arquetipo más utilizado en un torneo específico
        public Task<string?> GetMostUsedArchetypeInTournament(int tournamentId);
        // Método para obtener los arquetipos más utilizados en una ronda específica de un torneo
        public Task<IEnumerable<string>> GetMostUsedArchetypesInRound(int TournamentId, int Round);

        // Método para obtener los jugadores con más decks en su poder (ordenados de mayor a menor)
        public Task<IEnumerable<UserDto>> GetPlayersWithMostDecks(int n);

        // Método para obtener el jugador con más victorias en un intervalo de tiempo
        public Task<IEnumerable<UserDto>> GetPlayersWithMostVictories(int n, IRangeTime rangeTime);
        // Método para obtener los arquetipos más utilizados por al menos un jugador en los torneos
        public Task<IEnumerable<string>> GetTopArchetypesUsedByAtLeastOnePlay(int n);

        // Método para obtener al campeón de un torneo específico
        public Task<UserDto?> GetTournamentChampion(int idTournament);

    }
}