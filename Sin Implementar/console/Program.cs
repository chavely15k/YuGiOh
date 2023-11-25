using System;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Guid x = Guid.NewGuid();
Console.WriteLine(x);
public class DtoObject
{
    public string Property1 { get; set; }
    public string Property2 { get; set; }
    // Otras propiedades del DTO
}

public class OtherObject
{
    public string PropertyA { get; set; }
    public string PropertyB { get; set; }
    // Otras propiedades del nuevo objeto
}

// Configurar AutoMapper
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<DtoObject, OtherObject>()
        .ForMember(dest => dest.PropertyA, opt => opt.MapFrom(src => src.Property1))
        .ForMember(dest => dest.PropertyB, opt => opt.MapFrom(src => src.Property2));
    // Configurar otros mapeos si es necesario
});

// Crear un mapper
var mapper = config.CreateMapper();

// Convertir parte de la información del DTO al nuevo objeto usando AutoMapper
DtoObject dto = new DtoObject();
// Asignar valores a las propiedades del DTO...
dto.Property1 = "sef";
dto.Property2 = "df";

OtherObject otherObject = mapper.Map<OtherObject>(dto);

// Utilizar el nuevo objeto...

Console.WriteLine(otherObject.PropertyA);
Console.WriteLine(otherObject.PropertyB);
