using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YuGiOh.ApplicationCore.DTO;

public class RoleAssignDto
{
    public int Id { get; set; }
    public List<int> Roles { get; set; }
    public string Code { get; set;} = String.Empty;

}
