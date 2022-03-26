using System.Globalization;
using Application.UseCases.IntegrateSupplyChain.Protocols;
using CsvHelper;

namespace Infra.Services;

public class ERPMapperCSV : IERPMapper
{
  private readonly string pathFileCategory;
  private readonly string pathFileFruit;
  public ERPMapperCSV( string pathFruit, string pathCategory) {
    //arg #0 => csv file for mapping fruit
    //arg #1 =>  csv file for category
    pathFileFruit = pathFruit;
    pathFileCategory = pathCategory;
  }
  
  public (List<FruitMappingDTO> fruitMapping, 
          List<CategoryMappingDTO> categoryMapping) 
          getMappers()
  {
    //fruits..
    var listFruitMapping = new List<FruitMappingDTO>();
    using (var reader = new StreamReader(pathFileFruit))
      using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
      {
          csv.Read();
          csv.ReadHeader();
          while (csv.Read()) {
            /*var record = new FruitMappingDTO(csv.GetField<string>("legacyid"),
                                             csv.GetField("targetid"));
            
            listFruitMapping.Add(record);*/
            Console.WriteLine(csv.GetField<string>("targetid"));
          }
      }
    
    //categories
    var listCategoryMapping = new List<CategoryMappingDTO>();
    using (var reader = new StreamReader(pathFileFruit))
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
    return (listFruitMapping,listCategoryMapping);
  }
}