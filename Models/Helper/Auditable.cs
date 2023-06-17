using System.ComponentModel.DataAnnotations.Schema;

namespace CarSun.Models.Helper;

public abstract class Auditable
{
    [NotMapped]
    public string? UserNameAudit { get; set; }
}
