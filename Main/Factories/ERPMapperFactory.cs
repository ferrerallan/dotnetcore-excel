using Application.UseCases.IntegrateSupplyChain.Protocols;
using Infra.Services;

namespace Main.Factories;
public static class ERPMapperFactory {
  public static IERPMapper makeERPMapper() {
    return new ERPMapperCSV(Path.Combine("files","mapping","mapping-fruit.csv"),
                            Path.Combine("files","mapping","mapping-category.csv"));
  }
}