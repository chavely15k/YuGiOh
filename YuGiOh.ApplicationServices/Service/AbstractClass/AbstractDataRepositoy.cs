using YuGiOh.ApplicationCore.Repository;

public abstract class AbstractDataRepository
{
   protected readonly IDataRepository _dataRepository;

   public AbstractDataRepository(IDataRepository dataRepository)
   {
       _dataRepository = dataRepository;
   }
}

