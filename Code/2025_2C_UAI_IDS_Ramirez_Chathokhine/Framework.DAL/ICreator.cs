namespace Framework.DAL
{
    public interface ICreator<in T>
    {
        void Create(T data);
    }
}