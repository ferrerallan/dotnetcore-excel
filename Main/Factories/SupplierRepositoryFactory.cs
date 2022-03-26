using Application.UseCases.IntegrateSupplyChain.Protocols;
using Infra.Services;

namespace Main.Factories;
public static class SupplierRepositoryFactory {
  public static ISupplierRepository makeSupplierRepository() {
    return new SupplierRepositoryExcel(Path.Combine("files","inputs","suplierABS.xlsx"));
  }
}