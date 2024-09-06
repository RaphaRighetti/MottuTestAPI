using System.ComponentModel.DataAnnotations.Schema;

[Table("mecanicos")]
public class Mecanico
{
  public int MecanicoId { get; set; }
  public string Nome { get; set; }
  public int Idade { get; set; }
  public int TempoPorDia { get; set; }
  public int NivelComplexidade { get; set; }
}
