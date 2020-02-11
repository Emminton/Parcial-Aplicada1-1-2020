using Microsoft.EntityFrameworkCore;
using Parcial_Aplicada1_1_2020.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parcial_Aplicada1_1_2020.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Producto { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optiondBilder)
        {
            optiondBilder.UseSqlServer(@"Server =.\SqlExpress; Database = ProductoDb;Trusted_Connection = True; ");
        }

    }
}
