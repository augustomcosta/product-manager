using System.ComponentModel.DataAnnotations;
using CrudProductManager.API.Domain.Validation;

namespace CrudProductManager.API.Domain.Models.Base;

public abstract class ModelBase<T>
{
    
    public ModelBase(int id)
    {
        DomainValidationException.When(id < 0,"Invalid Id. Id cannot be negative");
        Id = id;
    }
    
    [Key]
    public int Id { get; set; }
    
    public virtual void UpdateFrom(T type){}
   
}