using Anderson_Nunez_AP1_P2.DAL;
using Anderson_Nunez_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Anderson_Nunez_AP1_P2.Services;

public class EntradasService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public EntradasService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<bool> Guardar(Entradas entrada)
    {
        if (entrada.EntradaId == 0)
            return await Insertar(entrada);
        else
            return await Modificar(entrada);
    }

    public async Task<bool> Existe(int entradaId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Entradas
            .AnyAsync(e => e.EntradaId == entradaId);
    }

    private async Task<bool> Insertar(Entradas entrada)
    {
        if (!ValidarEntrada(entrada))
            return false;

        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Entradas.Add(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Entradas entrada)
    {
        if (!ValidarEntrada(entrada))
            return false;

        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Entradas.Update(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }

    private bool ValidarEntrada(Entradas entrada)
    {
        if (entrada.PesoTotal <= 0)
            throw new Exception("El peso total debe ser mayor que cero");

        if (entrada.CantidadProducida <= 0)
            throw new Exception("La cantidad producida debe ser mayor que cero");

        return true;
    }

    public async Task<Entradas?> Buscar(int entradaId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Entradas
            .Include(e => e.Detalles)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EntradaId == entradaId);
    }

    public async Task<bool> Eliminar(int entradaId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Entradas
            .Where(e => e.EntradaId == entradaId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Entradas>> Listar(Expression<Func<Entradas, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Entradas
            .Include(e => e.Detalles)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> ExisteEntrada(int entradaId, string concepto)
    {
        if (string.IsNullOrWhiteSpace(concepto))
            return false;

        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Entradas
            .AnyAsync(e => e.EntradaId != entradaId &&
                          e.Concepto.ToLower() == concepto.ToLower());
    }
}