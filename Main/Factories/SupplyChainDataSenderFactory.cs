using Application.UseCases.IntegrateSupplyChain.Protocols;
using Infra.Services;

namespace Main.Factories;
public static class SupplyChainDataSenderFactory {
  public static ISupplyChainDataSender makeSupplierChainDataSender() {
    return new SupplyChainDataSenderExcel(Path.Combine("files","outputs"));
    //return new SupplyChainDataSenderAPI();
  }
}