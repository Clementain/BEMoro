using System.ComponentModel.DataAnnotations;

namespace BEMoro.Models
{
	public class Directorio
	{
		public int Id { get; set; }
		[Required]
		public string Tipo { get; set; }
		[Required]
		public byte[]  Imagen { get; set; }
		[Required]
		public string Descripcion { get; set; }
	}
}
