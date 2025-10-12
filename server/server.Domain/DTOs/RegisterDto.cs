using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.DTOs;

public class RegisterDto
{
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
