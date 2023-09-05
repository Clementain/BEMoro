using System.ComponentModel.DataAnnotations;

namespace BEMoro.Models
{
	public class Encargado
	{
		public int Id { get; set; }
		[Required]
		public string TramiteServicio { get; set; }
		[Required]
		public string Nombre { get; set; }
		[Required]
		public string Mail { get; set; }
		[Required]
		public string Direccion { get; set; }
		[Required]
		public string telefono { get; set; }
	}
}
