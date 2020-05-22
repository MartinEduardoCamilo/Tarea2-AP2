using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RegistroPersona.DAL;
using RegistroPersona.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPersona.BLL
{
    public class PersonasBLL
    {

        public static bool Guardar(Persona persona)
        {
            if (!Existe(persona.PersonaId))// si no existe se inserta
                return Insertar(persona);
            else
                return Modificar(persona);
        }

        private static bool Insertar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Personas.Add(persona);
                paso = db.SaveChanges() > 0;
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

        public static bool Modificar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(persona).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
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
                var aux = db.Personas.Find(id);
                if (aux != null)
                {
                    db.Personas.Remove(aux);//remueve la informacion de la entidad relacionada
                    paso = db.SaveChanges() > 0;
                }
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

        public static Persona Buscar(int id)
        {
            Contexto db = new Contexto();
            Persona persona;

            try
            {
                persona = db.Personas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return persona;
        }

        public static bool Existe(int id)
        {
            Contexto db = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = db.Personas.Any(p => p.PersonaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
    }
}
