using AutoMapper;
using BDTramiteDocumentarioModel;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Vml.Office;
using IBussnies;
using IRepository;
using Repository;
using RequestResponseModel;
using System.Collections.Generic;

namespace Bussnies
{
    // 
    // la clase CargoBussnies hereda los metodos de ==> ICargoBussnies
    //
    public class CargoBussnies : ICargoBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly ICargoRepository _cargoRepository;
        private readonly IMapper _mapper;
        public CargoBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _cargoRepository = new CargoRepository();
        }
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        public List<CargoResponse> GetAll()
        {
            //declarando la lista de cargo response como resultado
            List<CargoResponse> lstResponse = new List<CargoResponse>();
            List<Cargo> cargos = _cargoRepository.GetAll();
            //FORMA 01 ==> SIN AUTOMAPPER
            //foreach (Cargo item in cargos)
            //{
            //    //declarar un objeto temporal de cargo response
            //    CargoResponse tmp = new CargoResponse();
            //    tmp.IdEstado = item.IdEstado;
            //    tmp.Codigo = item.Codigo;
            //    tmp.Id = item.Id;
            //    tmp.Nombre = item.Nombre;
            //    //con el add vamos agregando elementos a la lista lstResponse
            //    lstResponse.Add(tmp);
            //}
            //FORMA 02 ==> SIN AUTOMAPPER
            //cargos.ForEach(item => {
            //    CargoResponse tmp = new CargoResponse();
            //    tmp.IdEstado = item.IdEstado;
            //    tmp.Codigo = item.Codigo;
            //    tmp.Id = item.Id;
            //    tmp.Nombre = item.Nombre;
            //    lstResponse.Add(tmp);
            //});
            //FORMA 03 ==> CON AUTOMAPPER
            lstResponse = _mapper.Map<List<CargoResponse>>(cargos);
            return lstResponse;
        }

        public CargoResponse GetById(int id)
        {

            Cargo cargo = _cargoRepository.GetById(id);
            CargoResponse resul = _mapper.Map<CargoResponse>(cargo);
            //CargoResponse resultado = _mapper.Map<CargoResponse>(_cargoRepository.GetById(id));
            return resul;
        }

        public CargoResponse Create(CargoRequest entity)
        {
            /*SIN AUTOMAPPER*/
            //CargoResponse result = new CargoResponse();
            //Cargo cargo = new Cargo();
            //cargo.IdEstado = entity.IdEstado;
            //cargo.Codigo = entity.Codigo;
            //cargo.Id = entity.Id;
            //cargo.Nombre = entity.Nombre;
            //cargo = _cargoRepository.Create(cargo);
            //result.IdEstado = cargo.IdEstado;
            //result.Codigo = cargo.Codigo;
            //result.Id = cargo.Id;
            //result.Nombre = cargo.Nombre;

            /*CON AUTOMAPPER*/


            Cargo cargo = _mapper.Map<Cargo>(entity);
            cargo = _cargoRepository.Create(cargo);
            CargoResponse result = _mapper.Map<CargoResponse>(cargo);
            return result;
        }
        public List<CargoResponse> InsertMultiple(List<CargoRequest> lista)
        {
            List<Cargo> cargos = _mapper.Map<List<Cargo>>(lista);
            cargos = _cargoRepository.CreateMultiple(cargos);
            List<CargoResponse> result = _mapper.Map<List<CargoResponse>>(cargos);
            return result;
        }

        public CargoResponse Update(CargoRequest entity)
        {
            Cargo cargo = _mapper.Map<Cargo>(entity);
            cargo = _cargoRepository.Update(cargo);
            CargoResponse result = _mapper.Map<CargoResponse>(cargo);
            return result;
        }

        public List<CargoResponse> UpdateMultiple(List<CargoRequest> lista)
        {
            List<Cargo> cargos = _mapper.Map<List<Cargo>>(lista);
            cargos = _cargoRepository.UpdateMultiple(cargos);
            List<CargoResponse> result = _mapper.Map<List<CargoResponse>>(cargos);
            return result;
        }

        public int Delete(int id)
        {
            int cantidad = _cargoRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultipleItems(List<CargoRequest> lista)
        {
            List<Cargo> cargos = _mapper.Map<List<Cargo>>(lista);
            int cantidad = _cargoRepository.DeleteMultipleItems(cargos);
            return cantidad;
        }
    }
}