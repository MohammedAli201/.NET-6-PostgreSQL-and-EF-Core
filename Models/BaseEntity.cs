namespace PostgresDB.Models;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateModified { get; set; }
    public int Status { get; set; }
}
