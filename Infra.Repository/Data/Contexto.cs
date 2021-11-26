using Domain.Entitidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository.Data
{
    public class Contexto :DbContext
    {
        public Contexto(DbContextOptions<Contexto>options):base(options) { }
        public Contexto(){}

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfigurationsFromAssembly(typeof(Contexto).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var Builder = new ConfigurationBuilder();
            Builder.AddJsonFile("appsettings.json", optional: false);
            var configuration=Builder.Build();
        }
    }
}
