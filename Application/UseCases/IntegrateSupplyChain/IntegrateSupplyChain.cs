using System.Data;
using Application.UseCases.IntegrateSupplyChain.Protocols;

namespace Application.UseCases.IntegrateSupplyChain;

public class IntegrateSupplyChain {
  private readonly IERPMapper erpMapper;
  private readonly ISupplierRepository supplierRepository;
  public IntegrateSupplyChain(IERPMapper ERPMapper, ISupplierRepository SupplierRepository) {
    this.erpMapper = ERPMapper;
    this.supplierRepository = SupplierRepository;
  }

  public string Integrate() {
    try {
      var (listFruitMapper, listCategoryMapping) = this.erpMapper.getMappers();
      listFruitMapper.ForEach(f=>Console.WriteLine(f.codeTo));

      //datatables from supplier..
      var (dtProducts, dtCategories) = this.supplierRepository.getAllData();
      
      foreach (DataRow row in dtProducts.Rows) {
        Console.WriteLine(row["quantity"].ToString());
      }

      foreach (DataRow row in dtCategories.Rows) {
        Console.WriteLine(row["name"].ToString());
      }

      var results = from products in dtProducts.AsEnumerable()
                 join categories in dtCategories.AsEnumerable() on 
                 (string)products["categoryID"] equals (string)categories["categoryID"]
                 select new
                 {
                     product = (string)products["product"],
                     categoryName = (string)categories["name"]
                 };
      
      foreach (var item in results) {
        Console.WriteLine(String.Format("product = {0}, category = {1}", 
                          item.product, 
                          item.categoryName));
      }

      return string.Empty;
    }
    catch (Exception exc) {
      var error = exc.Message;
      Console.WriteLine(error);
      return error;
    }
  }
}