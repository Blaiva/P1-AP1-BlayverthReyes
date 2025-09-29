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

    public async Task<bool> Insertar(EntradasHuacales entradaHuacal)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(entradaHuacal);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(EntradasHuacales entradaHuacal)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Update(entradaHuacal);
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
        return await contexto.EntradasHuacales.Where(e => e.IdEntrada == idEntrada).AsNoTracking().ExecuteDeleteAsync() > 0;
    }

    public async Task<EntradasHuacales?> Buscar(int idEntrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.FirstOrDefaultAsync(e => e.IdEntrada == idEntrada);
    }

    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Where(criterio).AsNoTracking().ToListAsync();
    }
}
