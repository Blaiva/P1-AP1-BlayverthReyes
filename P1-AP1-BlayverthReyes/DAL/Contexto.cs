using Microsoft.EntityFrameworkCore;
using P1_AP1_BlayverthReyes.Models;

namespace P1_AP1_BlayverthReyes.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Registros> Registros { get; set; }
}