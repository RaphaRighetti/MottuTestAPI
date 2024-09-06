using System.ComponentModel.DataAnnotations.Schema;

[Table("consertoDeMotos")]
public class ConsertoDeMotos
{
  public int MotoId { get; set; }
  public int ComplexidadeDoConserto { get; set; }
  public int TipoConsertoId { get; set; }
  public int? TempoReal { get; set; }
  public DateTime DataEntrada { get; set; }
  public int? MecanicoId { get; set; }
  public Mecanico? Mecanico { get; set; }
  public TipoConserto? TipoConserto { get; set; }
}
