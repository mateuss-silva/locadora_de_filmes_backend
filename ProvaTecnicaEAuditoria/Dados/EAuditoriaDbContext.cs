﻿using Microsoft.EntityFrameworkCore;
using ProvaTecnicaEAuditoria.Dados.Mapeamentos;
using ProvaTecnicaEAuditoria.Modelos;

namespace ProvaTecnicaEAuditoria.Dados
{
    public class EAuditoriaDbContext : DbContext
    {
        public EAuditoriaDbContext(DbContextOptions<EAuditoriaDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));

            options.UseMySql(connectionString, serverVersion);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeamentoDoCliente());
            modelBuilder.ApplyConfiguration(new MapeamentoDoFilme());
            modelBuilder.ApplyConfiguration(new MapeamentoDaLocacao());
        }
    }
}