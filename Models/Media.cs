namespace PostgresDB.Models;

public class Media : BaseEntity
{

    public int DriverId { get; set; }
    public string MediaType { get; set; } = string.Empty;
    public virtual Drivers Driver { get; set; }

}
