using Microsoft.EntityFrameworkCore;

public class CiudadService
{
    private readonly AppContext _context;
    
    public CiudadService(AppContext context) => _context = context;

    public async Task<List<Ciudad>> GetCiudadesConDetalles()
    {
        return await _context.Ciudades
            .Include(c => c.Detalles)
            .Include(c => c.Proyectos)
            .ToListAsync();
    }

    public async Task<Ciudad> GetCiudadConDetalles(int id)
    {
        return await _context.Ciudades
            .Include(c => c.Detalles)
            .Include(c => c.Proyectos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task GuardarCiudadConDetalles(Ciudad ciudad)
    {
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            if (ciudad.Id == 0)
                _context.Ciudades.Add(ciudad);
            else
                _context.Ciudades.Update(ciudad);
            
            await ActualizarProyecto(ciudad);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private async Task ActualizarProyecto(Ciudad ciudad)
    {
        var proyecto = await _context.Proyectos
            .FirstOrDefaultAsync(p => p.CiudadId == ciudad.Id);
        
        if (proyecto == null)
        {
            proyecto = new Proyecto { CiudadId = ciudad.Id };
            _context.Proyectos.Add(proyecto);
        }
        
        proyecto.Presupuesto = ciudad.Detalles.Sum(d => d.Monto);
    }

    public async Task EliminarCiudad(int id)
    {
        var ciudad = await _context.Ciudades
            .Include(c => c.Detalles)
            .Include(c => c.Proyectos)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (ciudad != null)
        {
            _context.Detalles.RemoveRange(ciudad.Detalles);
            _context.Proyectos.RemoveRange(ciudad.Proyectos);
            _context.Ciudades.Remove(ciudad);
            await _context.SaveChangesAsync();
        }
    }
}