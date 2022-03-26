using System.Globalization;
using Application.UseCases.IntegrateSupplyChain.Protocols;
using CsvHelper;

namespace Infra.Services;

public class ERPMapperCSV : IERPMapper
{
  private readonly string pathFileCategory;
  private readonly string pathFileProduct;
  public ERPMapperCSV( string pathProduct, string pathCategory) {
    //arg #0 => csv file for mapping fruit
    //arg #1 =>  csv file for category
    pathFileProduct = pathProduct;
    pathFileCategory = pathCategory;
  }
  
  public (List<ProductMappingDTO> productMapping, 
          List<CategoryMappingDTO> categoryMapping) 
          getMappers()
  {
    Console.WriteLine("getting mappers...");
    //fruits..
    var listProductMapping = new List<ProductMappingDTO>();
    using (var reader = new StreamReader(pathFileProduct))
      using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
      {
          csv.Read();
          csv.ReadHeader();
          while (csv.Read()) {
            var record = new ProductMappingDTO(csv.GetField<string>("legacyid"),
                                             csv.GetField<string>("targetid"));
            
            listProductMapping.Add(record);
          }
      }
    
    //categories
    var listCategoryMapping = new List<CategoryMappingDTO>();
    using (var reader = new StreamReader(pathFileProduct))
      using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
      {
          csv.Read();
          csv.ReadHeader();
          while (csv.Read()) {
            var record = new CategoryMappingDTO(csv.GetField<string>("legacyid"),
                                              csv.GetField("targetid"));
            
            listCategoryMapping.Add(record);
          }
      }
    return (listProductMapping,listCategoryMapping);
  }
}