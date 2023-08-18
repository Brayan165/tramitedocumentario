using BDTramiteDocumentarioModel;
using IRepository;

namespace Repository
{
    /*
     : ==> hace referencia P.O.O ==> herencia
     */

    /// <summary>
    /// 
    /// </summary>
    public class CargoRepositoryCopy01 : ICargoRepository
    {

        /*
         lo que normalmente se hace
         */

        /*
            _dbTramiteDocumentarioContext ==> clase o un tipo de dato 
            dbContext   ==> variable
            int numero;
            string miNombre;

            toda esta linea se conoce como ==> INSTANCIAR UN OBJETO
            _dbTramiteDocumentarioContext dbContext = new _dbTramiteDocumentarioContext();


         */

        _dbTramiteDocumentarioContext dbContext = new _dbTramiteDocumentarioContext();




        public Cargo Create(Cargo entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteMultipleItems(List<Cargo> lista)
        {
            throw new NotImplementedException();
        }

        public List<Cargo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cargo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cargo> InsertMultiple(List<Cargo> lista)
        {
            throw new NotImplementedException();
        }

        public Cargo Update(Cargo entity)
        {
            throw new NotImplementedException();
        }

        public List<Cargo> UpdateMultiple(List<Cargo> lista)
        {
            throw new NotImplementedException();
        }
    }
}