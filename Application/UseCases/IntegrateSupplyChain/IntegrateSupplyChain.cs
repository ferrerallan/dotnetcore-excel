using System.Data;
using Application.UseCases.IntegrateSupplyChain.Protocols;
using Domain;

namespace Application.UseCases.IntegrateSupplyChain;

public class IntegrateSupplyChain {
  private readonly IERPMapper erpMapper;
  private readonly ISupplierRepository supplierRepository;
  private readonly ISupplyChainDataSender supplyChainDataSender;
  public IntegrateSupplyChain(IERPMapper ERPMapper, 
                              ISupplierRepository SupplierRepository,
                              ISupplyChainDataSender supplyChainDataSender) {
    this.erpMapper = ERPMapper;
    this.supplierRepository = SupplierRepository;
    this.supplyChainDataSender = supplyChainDataSender;
  }

  public string Integrate() {
    try {
      var (listFruitMapper, listCategoryMapping) = this.erpMapper.getMappers();

      //datatables from supplier..
      var (dtProducts, dtCategories) = this.supplierRepository.getAllData();
      
      var productList = (from products in dtProducts.AsEnumerable()
                  join categories in dtCategories.AsEnumerable() on 
                  (string)products["categoryID"] equals (string)categories["categoryID"]
                  select new Product
                  {
                    Name = (string)products["product"],
                    Category = new Category { 
                      Name=(string)categories["name"]
                      }
                  }).ToList<Product>();
      
      var pendingValidations = productList.Where(p=>!p.isValid());
      if (pendingValidations.Count() > 0) {
        var errors = string.Empty;
        var invalidProducts = pendingValidations.ToList<Product>();
        invalidProducts.ForEach(p=>errors+= 
                                  $"\nproduct {p.Name} has errors:{string.Join(",",p.getErrors())}");
        return errors;
      }

      this.supplyChainDataSender.send(productList);

      return string.Empty;
    }
    catch (Exception exc) {
      var error = exc.Message;
      Console.WriteLine(error);
      return error;
    }
  }
}