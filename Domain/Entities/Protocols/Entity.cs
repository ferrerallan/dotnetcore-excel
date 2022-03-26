namespace Domain.Entity.Protocols;

public interface IEntity {
  public bool isValid();
  public List<string> getErrors();
}