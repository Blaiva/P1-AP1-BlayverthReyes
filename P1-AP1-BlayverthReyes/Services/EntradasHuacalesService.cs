using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using P1_AP1_BlayverthReyes.DAL;
using P1_AP1_BlayverthReyes.Models;

namespace P1_AP1_BlayverthReyes.Services;

public class EntradasHuacalesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AnyAsync(e => e.IdEntrada == idEntrada);
    }

    public async Task AfectarExistencia(EntradasHuacalesDetalle[] detalle, TipoOperacion tipoOperacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        foreach(var item  in detalle)
        {
            var tipoHuacal = await contexto.TiposHuacales.SingleAsync(t => t.TipoId == item.TipoId);
            if (tipoOperacion == TipoOperacion.Suma)
                tipoHuacal.Existencia += item.Cantidad;
            else
                tipoHuacal.Existencia -= item.Cantidad;
        }
    }

    public async Task<bool> Insertar(EntradasHuacales entradaHuacal)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(entradaHuacal);
        await AfectarExistencia(entradaHuacal.EntradasHuacalesDetalle.ToArray(), TipoOperacion.Suma);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(EntradasHuacales entradaHuacal)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var entradaOriginal = await Buscar(entradaHuacal.IdEntrada);
        await AfectarExistencia(entradaOriginal.EntradasHuacalesDetalle.ToArray(), TipoOperacion.Resta);

        contexto.EntradasHuacales.Update(entradaHuacal);
        await AfectarExistencia(entradaHuacal.EntradasHuacalesDetalle.ToArray(), TipoOperacion.Suma);

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(EntradasHuacales entradaHuacal)
    {
        if(!await Existe(entradaHuacal.IdEntrada))
            return await Insertar(entradaHuacal);
        else
            return await Modificar(entradaHuacal);
    }

    public async Task<bool> Eliminar(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var entrada = await Buscar(idEntrada);

        await AfectarExistencia(entrada.EntradasHuacalesDetalle.ToArray(), TipoOperacion.Resta);
        contexto.EntradasHuacalesDetalles.RemoveRange(entrada.EntradasHuacalesDetalle);
        contexto.EntradasHuacales.Remove(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<EntradasHuacales?> Buscar(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Include(e => e.EntradasHuacalesDetalle).FirstOrDefaultAsync(e => e.IdEntrada == idEntrada);
    }

    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Include(e => e.EntradasHuacalesDetalle).Where(criterio).AsNoTracking().ToListAsync();
    }
}
public enum TipoOperacion
{
    Suma = 1,
    Resta = 2
}