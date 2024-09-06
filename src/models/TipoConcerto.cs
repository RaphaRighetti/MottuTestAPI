using System.ComponentModel.DataAnnotations.Schema;

[Table("tipoConserto")]
public class TipoConserto
{
  public int Id { get; set; }
  public int TempoEstimado { get; set; }
}
