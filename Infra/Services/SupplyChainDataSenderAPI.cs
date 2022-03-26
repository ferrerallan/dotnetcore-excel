using Application.UseCases.IntegrateSupplyChain.Protocols;
using Domain;

namespace Infra.Services;
public class SupplyChainDataSenderAPI : ISupplyChainDataSender
{
  public string send(List<Product> productList)
  {
    Console.WriteLine("Sending by API");
    return string.Empty;
  }
}