using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YuGiOh.Domain.Models;

public interface IEntity
{
    public object GetById();
}
