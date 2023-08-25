using BDTramiteDocumentarioModel;
using IRepository;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Repository
{
    /*
     : ==> hace referencia P.O.O ==> herencia
     */

    public class CargoRepository : ICargoRepository
    {

        /*INYECCIÓN DE DEPENDENCIAS*/
        _dbTramiteDocumentarioContext dbContext;
        public CargoRepository()
        {
            dbContext = new _dbTramiteDocumentarioContext();
        }

        /// <summary>
        /// SIRVE PARA INSERTAR UN REGISTRO EN LA TABLA Cargo
        /// </summary>
        /// <param name="entity">Objeto de tipo cargo</param>
        /// <returns>un nuevo objeto "Cargo"</returns>
        public Cargo Create(Cargo entity)
        {
            //CREA EL SCRIPT DEL INSERT INTO
            dbContext.Cargos.Add(entity);
            //EJECUTA EL SCRIPT GENERADO EN LA LINEA ANTERIOR
            dbContext.SaveChanges();

            return entity;

        }

        public Cargo Update(Cargo entity)
        {
            //CREA EL SCRIPT DEL UPDATE
            dbContext.Cargos.Update(entity);
            //EJECUTA EL SCRIPT GENERADO EN LA LINEA ANTERIOR
            dbContext.SaveChanges();

            return entity;
        }

        public List<Cargo> GetAll()
        {
            //que es lst ==> es una variable de tipo lista del objeto cargo
            //crea y ejecuta el script del select * from cargo
            List<Cargo> lst = dbContext.Cargos.ToList();

            return lst;
        }

        public Cargo GetById(int id)
        {
            //.Find(id); where PK == id
            Cargo cargo = dbContext.Cargos.Find(id);
            
            Cargo cargo2 = dbContext.Cargos.Where(x => x.Id == id).FirstOrDefault();
            return cargo;
        }



        public int Delete(int id)
        {
            Cargo cargo = dbContext.Cargos.Find(id);
            dbContext.Cargos.Remove(cargo);
            return dbContext.SaveChanges();
        }

        public int DeleteMultipleItems(List<Cargo> lista)
        {
            dbContext.Cargos.RemoveRange(lista);
            return dbContext.SaveChanges();
        }

        public List<Cargo> CreateMultiple(List<Cargo> lista)
        {
            dbContext.Cargos.AddRange(lista);
            dbContext.SaveChanges();
            return lista;
        }

        public List<Cargo> UpdateMultiple(List<Cargo> lista)
        {
            dbContext.Cargos.UpdateRange(lista);
            dbContext.SaveChanges();
            return lista;
        }
    }
}