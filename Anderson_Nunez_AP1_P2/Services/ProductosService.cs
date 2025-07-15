using Anderson_Nunez_AP1_P2.DAL;
using Anderson_Nunez_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Anderson_Nunez_AP1_P2.Services;

public class ProductosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int productoid)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Productos.AnyAsync(c => c.ProductoId == productoid);

    }
    public async Task<bool> Insertar(Productos producto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Productos.Add(producto);
        return await contexto.SaveChangesAsync() > 0;

    }

    public async Task<bool> Modificar(Productos producto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Productos.Update(producto);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Productos producto)
    {
        if (!await Existe(producto.ProductoId))
            return await Insertar(producto);
        else
            return await Modificar(producto);
    }
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminando = await contexto.Productos
            .Where(p => p.ProductoId == id)
            .ExecuteDeleteAsync();
        return eliminando > 0;

    }

    public async Task<Productos?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Productos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ProductoId == id);

    }

    public async Task<List<Productos>> Listar(Expression<Func<Productos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Productos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
    public async Task RestaurarCantidad(int productoId, int existencia)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var articulo = await contexto.Productos
        .FirstOrDefaultAsync(a => a.ProductoId == productoId);

        // Si el artículo existe
        if (articulo != null)
        {
            articulo.Peso += existencia;

            contexto.Productos.Update(articulo);
            await contexto.SaveChangesAsync();
        }
    }
}