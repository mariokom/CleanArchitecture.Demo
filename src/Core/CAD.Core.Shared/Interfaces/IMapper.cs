namespace CAD.Core.Shared.Interfaces
{
    public interface IMapper<TEntity, TModel> 
        where TEntity : class
        where TModel : class
    {
        TModel ToModel(TEntity entity);

        TEntity ToEntity(TModel model);
    }
}
