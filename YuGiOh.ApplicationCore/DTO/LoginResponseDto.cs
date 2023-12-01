using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YuGiOh.ApplicationCore.DTO;

public class LoginResponseDto
{
    public string Name { get; set; }
    public int? Id { get; set; }
    public string Nick { get; set; }
    public List<int> Roles { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
}
