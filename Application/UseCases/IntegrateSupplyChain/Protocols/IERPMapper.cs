namespace Application.UseCases.IntegrateSupplyChain.Protocols;

public interface IERPMapper {
  public (List<ProductMappingDTO> productMapping, 
          List<CategoryMappingDTO> categoryMapping) getMappers();
}