namespace AzilEdu.Shared.Models;

public class Species
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Breed> Breeds { get; set; } = new List<Breed>();
    public ICollection<Animal> Animals { get; set; } = new List<Animal>();
}