using BDTramiteDocumentarioModel;
using RequestResponseModel;

namespace IBussnies
{
    public interface ICargoBussnies
    {
        List<CargoResponse> GetAll();
        CargoResponse GetById(int id);
        CargoResponse Create(CargoRequest entity);
        CargoResponse Update(CargoRequest entity);
        int Delete(int id);
        int DeleteMultipleItems(List<CargoRequest> lista);
        List<CargoResponse> InsertMultiple(List<CargoRequest> lista);
        List<CargoResponse> UpdateMultiple(List<CargoRequest> lista);
    }
}