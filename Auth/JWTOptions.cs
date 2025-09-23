using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth;

public class JWTOptions
{
    public string? SecretKey { get; set; }
    public string? Issuer { get; set; }
    public int ExpireMinute { get; set; }
}
