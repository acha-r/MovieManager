namespace MovieManager.Services.ServiceFactory
{
    public interface IServiceFactory
    {
        T GetService<T>() where T : class;
    }
}
