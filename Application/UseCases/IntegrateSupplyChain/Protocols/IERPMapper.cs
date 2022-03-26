namespace Application.UseCases.IntegrateSupplyChain.Protocols;

public interface IERPMapper {
  public (List<FruitMappingDTO> fruitMapping, 
          List<CategoryMappingDTO> categoryMapping) getMappers();
}