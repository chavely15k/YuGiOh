using YuGiOh.ApplicationCore.Repository;

public abstract class AbstractDataRepository
{
   protected readonly IEntityRepository _dataRepository;

   public AbstractDataRepository(IEntityRepository dataRepository)
   {
       _dataRepository = dataRepository;
   }
}

