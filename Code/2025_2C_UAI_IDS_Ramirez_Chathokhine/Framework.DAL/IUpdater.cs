namespace Framework.DAL
{
    public interface IUpdater<T>
    {
        void Update(T data);
    }
}