namespace YuGiOh.ApplicationCore.DTO;

public class DeckDto
{
    public int Id{get;set;}
    public string Name { get; set; }
    public int ArchetypeId { get; set; }
    public int MainDeckSize { get; set; }
    public int SideDeckSize { get; set; }
    public int ExtraDeckSize { get; set; }
    public int PlayerId { get; set; }
    
}
