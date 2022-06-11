namespace GameShop.Models.Entity.RequestEntity
{
    public abstract class BaseRequestEntity<T>
    {
        public T Id { get; init; }
        public bool IsChecked { get; set; } = true;

        protected BaseRequestEntity(T id, bool isChecked)
        {
            Id = id;
            IsChecked = isChecked;
        }

        protected BaseRequestEntity()
        {
        }
    }
}
