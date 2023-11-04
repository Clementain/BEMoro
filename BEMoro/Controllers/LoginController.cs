using BEMoro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BEMoro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private IConfiguration _config;
		public LoginController(IConfiguration config)
		{
			_config = config;
		}

		[HttpPost]
		public IActionResult Post([FromBody] Usuario u)
		{
			if (u.User== ",6rt'^GEA!9_FC7jiC9K3}R>fK7G8gWZCJYqGc-P:vy<)£F9;v" && u.Contrasenia== "sD0%Sg9M].12p^>mU>VA,v`pX>P;?FFuL#fJ%r|<`r/i^BPT^e")
			{
				var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
				var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

				var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
				  _config["Jwt:Issuer"],
				  null,
				  expires: DateTime.Now.AddMinutes(120),
				  signingCredentials: credentials);

				var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

				return Ok(token);
			}
			else
			{
				return BadRequest();
			}

			
		}
	}
}
