using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using YuGiOh.ApplicationCore.Repository;

namespace YuGiOh.ApplicationServices.Service.AbstractClass;
public abstract class AbstractDataServices
{
    protected readonly IMapper _mapper;
    protected readonly IEntityRepository _dataRepository;
    public AbstractDataServices(IEntityRepository dataRepository, IMapper mapper)
    {
        _mapper = mapper;
        _dataRepository = dataRepository;
    }
}
