using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.Core.Entities
{
    public class BaseEntity
    {
        public virtual string Id { get; set; } = string.Empty;
    }
}
