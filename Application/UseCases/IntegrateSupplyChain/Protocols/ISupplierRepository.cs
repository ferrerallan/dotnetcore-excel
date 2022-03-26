using System.Data;
namespace Application.UseCases.IntegrateSupplyChain.Protocols;

public interface ISupplierRepository {
  public (DataTable fruits, DataTable categories) getAllData ();
}