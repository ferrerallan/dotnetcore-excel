using Application.UseCases.IntegrateSupplyChain.Protocols;
using Domain;
using ClosedXML.Excel;

namespace Infra.Services;
public class SupplyChainDataSenderExcel : ISupplyChainDataSender
{
  private readonly string pathFolder;

  public SupplyChainDataSenderExcel()
  {
  }

  public SupplyChainDataSenderExcel(string pathFolder) {
    this.pathFolder = pathFolder;
  }
  public string send(List<Product> productList)
  {
    Console.WriteLine("exporting excel...");
    //productList.ForEach(p=>Console.WriteLine($"{p.Name} | {p.Category.Name}"));
    
    using var wbook = new XLWorkbook();

    var ws = wbook.Worksheets.Add("Products");
    
    //setting headers..
    ws.Row(1).Cell(1).SetValue("Product Name");
    ws.Row(1).Cell(2).SetValue("Category Name");
    
    int count = 2;
    productList.ForEach(p=>{
      ws.Row(count).Cell(1).SetValue(p.Name);
      ws.Row(count).Cell(2).SetValue(p.Category.Name);
      count++;
    });

    wbook.SaveAs(Path.Combine(pathFolder,"integration.xlsx"));

    return string.Empty;
    
  }
}