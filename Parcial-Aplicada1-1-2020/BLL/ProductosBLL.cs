using Parcial_Aplicada1_1_2020.DAL;
using Parcial_Aplicada1_1_2020.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Parcial_Aplicada1_1_2020.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos productos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Producto.Add(productos) != null)
                paso = (db.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Productos productos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(productos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                paso = (db.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Producto.Find(id);
                db.Entry(eliminar).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Productos Buscar(int id)
        {
            Productos productos = new Productos();
            Contexto db = new Contexto();
            try
            {
                productos = db.Producto.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return productos;
        }

        public static List<Productos>GeLis(Expression<Func<Productos, bool>> productos)
        {
            List<Productos> lista = new List<Productos>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Producto.Where(productos).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
