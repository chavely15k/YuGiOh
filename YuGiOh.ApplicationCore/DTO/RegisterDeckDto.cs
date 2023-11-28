namespace YuGiOh.ApplicationCore.DTO;

public class RegisterDeckDto
{
    public string Name { get; set; }
    public string Archetype { get; set; }
    public int MainDeckSize { get; set; }
    public int SideDeckSize { get; set; }
    public int ExtraDeckSize { get; set; }
    public int PalyerId { get; set; }

    public string Nick{get;set;}
}
