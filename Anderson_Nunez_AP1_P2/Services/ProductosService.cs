using Anderson_Nunez_AP1_P2.DAL;
using Anderson_Nunez_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Anderson_Nunez_AP1_P2.Services;

public class ProductosService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public ProductosService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<bool> Guardar(Productos producto)
    {
        if (producto.ProductoId == 0)
            return await Insertar(producto);
        else
            return await Modificar(producto);
    }

    public async Task<bool> Existe(int productoId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Productos
            .AnyAsync(p => p.ProductoId == productoId);
    }

    private async Task<bool> Insertar(Productos producto)
    {
        if (!ValidarProducto(producto))
            return false;

        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Productos.Add(producto);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Productos producto)
    {
        if (!ValidarProducto(producto))
            return false;

        await using var contexto = await _dbFactory.CreateDbContextAsync();
        contexto.Productos.Update(producto);
        return await contexto.SaveChangesAsync() > 0;
    }

    private bool ValidarProducto(Productos producto)
    {
        if (producto.EsCompuesto && producto.Existencia > 0)
            throw new Exception("Productos compuestos no pueden tener existencia inicial");
        return true;
    }

    public async Task<Productos?> Buscar(int productoId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Productos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ProductoId == productoId);
    }

    public async Task<bool> Eliminar(int productoId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Productos
            .Where(p => p.ProductoId == productoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Productos>> Listar(Expression<Func<Productos, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Productos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> ExisteProducto(int productoId, string descripcion)
    {
        if (string.IsNullOrWhiteSpace(descripcion))
            return false;

        await using var contexto = await _dbFactory.CreateDbContextAsync();
        return await contexto.Productos
            .AnyAsync(p => p.ProductoId != productoId &&
                          p.Descripcion.ToLower() == descripcion.ToLower());
    }
}