using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace MottuTechAPI.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class ConsertoDeMotosController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public ConsertoDeMotosController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> PostConsertoDeMoto([FromBody] ConsertoDeMotos conserto)
    {
      if (conserto.MotoId == 0 || conserto.ComplexidadeDoConserto == 0 || conserto.DataEntrada == DateTime.MinValue)
      {
        return BadRequest("Faltam informações necessárias para inserir a nova moto para conserto. Certifique-se de que 'motoId', 'complexidadeDoConserto' e 'dataEntrada' foram fornecidos.");
      }
      var tipoConserto = await _context.TipoConserto.FindAsync(conserto.TipoConsertoId);
      if (tipoConserto == null)
      {
          return NotFound("Tipo de conserto não encontrado");
      }

      conserto.MecanicoId = null;
      conserto.TempoReal = null;

      _context.ConsertoDeMotos.Add(conserto);
      await _context.SaveChangesAsync();

      return Ok(conserto);
    }

    [HttpPut("{motoId}/{dataEntrada}/{tipoConsertoId}")]
    public async Task<IActionResult> PutConsertoDeMoto(int motoId, DateTime dataEntrada, int tipoConsertoId, [FromBody] ConsertoDeMotos conserto)
    {
      var moto = await _context.ConsertoDeMotos
        .FirstOrDefaultAsync(c => c.MotoId == motoId && c.DataEntrada == dataEntrada && c.TipoConsertoId == tipoConsertoId);

      if (moto == null)
      {
        return NotFound("Moto não encontrada");
      }

      if (conserto.TempoReal <= 0 || !await _context.Mecanicos.AnyAsync(m => m.MecanicoId == conserto.MecanicoId))
      {
        return BadRequest("Tempo real deve ser maior que 0 e mecânico deve existir");
      }

      moto.TempoReal = conserto.TempoReal;
      moto.MecanicoId = conserto.MecanicoId;

      _context.Entry(moto).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return Ok(moto);
    }

    [HttpGet]
    public async Task<IActionResult> GetConsertoDeMotos()
    {
      var consertos = await _context.ConsertoDeMotos
        .Include(cm => cm.Mecanico)
        .Include(cm => cm.TipoConserto)
        .ToListAsync();

      return Ok(consertos);
    }

    [HttpDelete("{motoId}/{dataEntrada}/{tipoConsertoId}")]
    public async Task<IActionResult> DeleteConsertoDeMoto(int motoId, DateTime dataEntrada, int tipoConsertoId)
    {
      var moto = await _context.ConsertoDeMotos
          .FirstOrDefaultAsync(c => c.MotoId == motoId && c.DataEntrada == dataEntrada && c.TipoConsertoId == tipoConsertoId);

      if (moto == null)
      {
          return NotFound("Moto não encontrada");
      }

      _context.ConsertoDeMotos.Remove(moto);
      await _context.SaveChangesAsync();

      return Ok("Moto deletada com sucesso");
    }
  }
}