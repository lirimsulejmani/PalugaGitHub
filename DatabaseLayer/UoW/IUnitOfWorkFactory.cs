namespace DatabaseLayer.UoW
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
