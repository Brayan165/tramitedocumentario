using BDTramiteDocumentarioModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    /*
     PROGRAMACION ORIENTADA A OBJETOS
        public, internal, private   ==> ENCAPSULAMIENTO
     */

    public interface ICargoRepository
    {
        List<Cargo> GetAll();
        Cargo GetById(int id);
        Cargo Create(Cargo entity);
        Cargo Update(Cargo entity);
        int Delete(int id);
        int DeleteMultipleItems(List<Cargo> lista);
        List<Cargo> CreateMultiple(List<Cargo> lista);
        List<Cargo> UpdateMultiple(List<Cargo> lista);
    }
}