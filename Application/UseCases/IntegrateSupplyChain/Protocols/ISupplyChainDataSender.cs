using Domain;

namespace Application.UseCases.IntegrateSupplyChain.Protocols;
public interface ISupplyChainDataSender {
  public string send(List<Product> productList);
}