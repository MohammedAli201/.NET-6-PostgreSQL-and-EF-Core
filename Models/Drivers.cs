namespace PostgresDB.Models;

public class Drivers : BaseEntity

{
    public int TeamId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int RacingNumber { get; set; }
    public virtual Team Team { get; set; }
    public virtual Media Media { get; set; }
}
