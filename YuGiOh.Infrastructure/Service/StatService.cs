using AutoMapper;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
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

        public async Task<byte[]> GenerateStatisticsPdf(IRangeTime rangeTime, int topNPlayers = 10, int topNArchetypes = 10)
        {
            // Obtener estadísticas
            var champions = await GetAllChampionsInTimeRange(rangeTime);
            var championArchetypes = await GetChampionArchetypeFrequency(rangeTime);
            var playersWithMostDecks = await GetPlayersWithMostDecks(topNPlayers);
            var mostPopularLocation = await GetLocationWithMostChampions(rangeTime);
            var mostPopularArchetypes = await GetMostPopularArchetypes(topNArchetypes);
            var mostPopularLocationForArchetype = await GetMostPopularLocationForArchetype(1); // Reemplaza con el ID real del arquetipo
            var mostUsedArchetypeInTournament = await GetMostUsedArchetypeInTournament(1); // Reemplaza con el ID real del torneo
            var mostUsedArchetypesInRound = await GetMostUsedArchetypesInRound(1, 2); // Reemplaza con los valores reales
            var playersWithMostVictories = await GetPlayersWithMostVictories(topNPlayers, rangeTime);
            var topArchetypesUsedByAtLeastOnePlay = await GetTopArchetypesUsedByAtLeastOnePlay(topNArchetypes);
            var tournamentChampion = await GetTournamentChampion(1); // Reemplaza con el ID real del torneo

            // Crear el documento PDF
            using (var stream = new MemoryStream())
            {
                var writer = new PdfWriter(stream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Agregar estadísticas al PDF
                document.Add(new Paragraph("Estadísticas de Yu-Gi-Oh"));

                document.Add(new Paragraph("Champions en el rango de tiempo:"));
                foreach (var champion in champions)
                {
                    document.Add(new Paragraph(champion.ToString()));
                }

                document.Add(new Paragraph("Frecuencia de arquetipos de campeones:"));
                foreach (var archetype in championArchetypes)
                {
                    document.Add(new Paragraph($"{archetype.ArchetypeName}: {archetype.Frequency}"));
                }

                document.Add(new Paragraph("Jugadores con más decks:"));
                foreach (var player in playersWithMostDecks)
                {
                    document.Add(new Paragraph(player.ToString()));
                }

                document.Add(new Paragraph($"Ubicación con más campeones: {mostPopularLocation}"));

                document.Add(new Paragraph("Arquetipos más populares:"));
                foreach (var archetype in mostPopularArchetypes)
                {
                    document.Add(new Paragraph(archetype));
                }

                document.Add(new Paragraph("Ubicación más popular para un arquetipo:"));
                document.Add(new Paragraph(mostPopularLocationForArchetype));

                document.Add(new Paragraph("Arquetipo más utilizado en un torneo:"));
                document.Add(new Paragraph(mostUsedArchetypeInTournament?.ToString() ?? "No hay arquetipo registrado"));

                document.Add(new Paragraph("Arquetipos más utilizados en una ronda de un torneo:"));
                foreach (var archetype in mostUsedArchetypesInRound)
                {
                    document.Add(new Paragraph(archetype));
                }

                document.Add(new Paragraph("Jugadores con más victorias:"));
                foreach (var player in playersWithMostVictories)
                {
                    document.Add(new Paragraph($"{player.Name}: victorias"));
                }

                document.Add(new Paragraph("Arquetipos principales utilizados por al menos un jugador:"));
                foreach (var archetype in topArchetypesUsedByAtLeastOnePlay)
                {
                    document.Add(new Paragraph(archetype));
                }

                document.Add(new Paragraph("Campeón del torneo:"));
                document.Add(new Paragraph(tournamentChampion?.ToString() ?? "No hay campeón registrado"));

                // Cerrar el documento
                document.Close();

                // Devolver el contenido del PDF como un array de bytes
                return stream.ToArray();
            }
        }
    }
}