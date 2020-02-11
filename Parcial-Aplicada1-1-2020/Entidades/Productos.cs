using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Parcial_Aplicada1_1_2020.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Existencia { get; set; }
        public decimal Costo { get; set; }
        public decimal ValorInventario { get; set; }

        public Productos()
        {

        }
        public Productos(int productoId, string descripcion, decimal existencia, decimal costo, decimal valorInventario)
        {
            ProductoId = productoId;
            Descripcion = descripcion;
            Existencia = existencia;
            Costo = costo;
            ValorInventario = valorInventario;
        }
    }
}
