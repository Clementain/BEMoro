using System.ComponentModel.DataAnnotations;

namespace BEMoro.Models
{
	public class Documento
	{
		public int Id { get; set; }
		[Required]
		public int EncargadoId { get; set; }
		[Required]
		public string Nombre { get; set; }
		[Required]
		public byte[] ArchivoPdf { get; set; }
		[Required]
		public Encargado Encargado { get; set; }
	}
}
