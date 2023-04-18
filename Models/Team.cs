namespace PostgresDB.Models;

public class Team : BaseEntity
{
    public Team()
    {
        Drivers = new HashSet<Drivers>();

    }
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; } = 2020;
    public virtual ICollection<Drivers> Drivers { get; set; }
}
