using Domain.Entity.Protocols;

namespace Domain;
public class Category:IEntity {
  public int Id { get; set; }
  public string Name { get; set; }

  public List<string> getErrors()
  {
    throw new NotImplementedException();
  }

  public bool isValid()
  {
    throw new NotImplementedException();
  }
}