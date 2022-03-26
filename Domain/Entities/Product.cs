using Domain.Entity.Protocols;

namespace Domain;
public class Product:IEntity {
  private List<string> errors;
  public int Id { get; set; }
  public string Name { get; set; }
  public Category Category { get; set; }

  public List<string> getErrors()
  {
    return errors;
  }

  public bool isValid()
  {
    this.errors = new List<string>();
    /*if (this.Name.Contains("b"))
      this.errors.Add(" contains b letter");
    if (this.Name.Contains("n"))
      this.errors.Add(" contains n letter");*/

    return this.errors.Count ==0;
  }
}