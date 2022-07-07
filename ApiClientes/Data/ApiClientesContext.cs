using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiClientes.Models;

namespace ApiClientes.Data
{
    public class ApiClientesContext : DbContext
    {
        public ApiClientesContext (DbContextOptions<ApiClientesContext> options)
            : base(options)
        {
        }

        public DbSet<ApiClientes.Models.DadosClientes>? DadosClientes { get; set; }
    }
}
