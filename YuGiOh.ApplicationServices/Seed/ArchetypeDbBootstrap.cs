using Newtonsoft.Json.Linq;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.Domain.Models;


namespace YuGiOh.ApplicationServices.Seed;

public class ArchetypeDbBootstrap
{
    public readonly IEntityRepository _repository;

    public ArchetypeDbBootstrap(IEntityRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> insertArchetypes()
    {
        var url = "https://db.ygoprodeck.com/api/v7/archetypes.php";
        var archetypes = await _repository.GetAllAsync<Archetype>();
        var count = archetypes.Count();
        if (count < 500)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var data = JArray.Parse(response);


                foreach (var archetype in data)
                {
                    // Acceder a la propiedad "archetype_name" de cada objeto en el array JSON
                    string archetypeName = archetype["archetype_name"].ToString();
                    // Imprimir el valor de "archetype_name"
                    Console.WriteLine($"Archetype Name: {archetypeName}");

                    await _repository.CreateAsync<Archetype>(new Archetype
                    {
                        Name = archetypeName

                    });
                    // Ahora puedes utilizar el valor de "archetype_name" para la inserción en la base de datos
                    // o realizar cualquier otra operación que desees.
                }

            }
        }
        return true;
    }
}
