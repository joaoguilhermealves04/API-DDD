using Application;
using Application.Interface;
using Application.ViewModels;
using Domain.Interfacer;
using Infra.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectAPI.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static void RegistreServeces(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaApplication, EmpresaApplication>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IFornecedorApplication, FornecedorApplication>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        }
    }
}
