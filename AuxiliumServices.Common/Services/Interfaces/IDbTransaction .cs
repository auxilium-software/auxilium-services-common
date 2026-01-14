namespace AuxiliumSoftware.AuxiliumServices.Common.Services.Interfaces
{
    public interface IDbTransaction : IAsyncDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
