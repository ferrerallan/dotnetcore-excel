using System.Data;
using Application.UseCases.IntegrateSupplyChain.Protocols;
using ClosedXML.Excel;
using ExcelDataReader;

namespace Infra.Services;
public class SupplierRepositoryExcel : ISupplierRepository
{
  private readonly string pathFile;
  public SupplierRepositoryExcel(string pathFile) {
    this.pathFile=pathFile;
  }
  public (DataTable fruits, DataTable categories) getAllData() { 
    const int _TAB_PRODUCTS= 1;
    const int _TAB_CATEGORIES= 2;
    
    var dtProducts = new DataTable();
    var dtCategories = new DataTable();
    
    using (XLWorkbook workBook = new XLWorkbook(this.pathFile)) {
      
      //products..
      IXLWorksheet workSheetProducts = workBook.Worksheet(_TAB_PRODUCTS);
      bool firstRow = true;
      foreach (IXLRow row in workSheetProducts.Rows()) {
        //using the first row to add columns to DataTable.
        if (firstRow) {
          foreach (IXLCell cell in row.Cells())
          {
              dtProducts.Columns.Add(cell.Value.ToString());
          }
          firstRow = false;
        }
        else {
          //Add rows to DataTable.
          dtProducts.Rows.Add();
          int i = 0;
          foreach (IXLCell cell in row.Cells())
          {
            dtProducts.Rows[dtProducts.Rows.Count - 1][i] = cell.Value.ToString();
            i++;
          }
        }
      }

      IXLWorksheet workSheetCategories = workBook.Worksheet(_TAB_CATEGORIES);
      firstRow = true;
      foreach (IXLRow row in workSheetCategories.Rows()) {
        //using the first row to add columns to DataTable.
        if (firstRow) {
          foreach (IXLCell cell in row.Cells())
          {
              dtCategories.Columns.Add(cell.Value.ToString());
          }
          firstRow = false;
        }
        else {
          //Add rows to DataTable.
          dtCategories.Rows.Add();
          int i = 0;
          foreach (IXLCell cell in row.Cells())
          {
            dtCategories.Rows[dtCategories.Rows.Count - 1][i] = cell.Value.ToString();
            i++;
          }
        }
      }

    }

    return (dtProducts, dtCategories);
  }
}