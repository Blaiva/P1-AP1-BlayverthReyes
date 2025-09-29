using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using P1_AP1_BlayverthReyes.DAL;
using P1_AP1_BlayverthReyes.Models;

namespace P1_AP1_BlayverthReyes.Services;

public class RegistrosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Registros.Where(criterio).AsNoTracking().ToListAsync();
    }
}
