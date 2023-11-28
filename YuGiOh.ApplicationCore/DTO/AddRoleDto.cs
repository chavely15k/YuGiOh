using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YuGiOh.ApplicationCore.DTO;

public class AddRoleDto
{
    public string Nick { get; set; }
    public List<int> Roles { get; set; }

    //TODO: Creo que deberia haber algo aqui que me permita chequear que el que anade el rol sea alguien con el poder;
}
