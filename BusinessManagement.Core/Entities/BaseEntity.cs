namespace BusinessManagement.Core.Entities
{
    public class BaseEntity
    {
        public virtual string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
