using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth;

public class JWTHandler : IJWTHandler
{
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
    private readonly JWTOptions _Options;
    private readonly SecurityKey _issuerSigningKey;
    private readonly SigningCredentials _signingCredentials;
    private readonly JwtHeader _jwtHeader;
    private readonly TokenValidationParameters _tokenValidationParameters;
    public JWTHandler(IOptions<JWTOptions> options)
    {
        _Options = options.Value;
        _issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Options.SecretKey));
        _signingCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256);
        _jwtHeader = new JwtHeader(_signingCredentials);
        _tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidIssuer = _Options.Issuer,
            IssuerSigningKey = _issuerSigningKey,
        };
    }
    public JsonWebToken Create(Guid UserId)
    {
        var utcNow = DateTime.UtcNow;
        var expire = utcNow.AddMinutes(_Options.ExpireMinute);
        var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
        var iat = (long)new TimeSpan(utcNow.Ticks - centuryBegin.Ticks).TotalMilliseconds;
        var exp = (long)new TimeSpan(expire.Ticks - centuryBegin.Ticks).TotalMilliseconds;
        var payLoad = new JwtPayload
        {
            {"sub", UserId },
            {"exp", exp },
            {"iat", iat },
            {"iss", _Options.Issuer },
            {"unique_code", UserId},
        };
        var jwt = new JwtSecurityToken(_jwtHeader, payLoad);
        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new JsonWebToken
        {
            Expire = exp,
            Token = token,
        };
    }
}
