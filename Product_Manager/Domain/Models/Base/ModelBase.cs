using Product_Manager.Domain.Validation;

namespace Product_Manager.Domain.Models.Base;

public abstract class ModelBase<T>
{
    public ModelBase(int id)
    {
        DomainValidationException.When(id < 0,"Invalid Id. Id cannot be negative");
        Id = id;
    }
    public int Id { get; set; }
    
    public virtual void UpdateFrom(T type){}
   
}