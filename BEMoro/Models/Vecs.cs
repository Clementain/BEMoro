using System.ComponentModel.DataAnnotations;

namespace BEMoro.Models
{
	public class Vecs
	{
		public int Id { get; set; }
		[Required]
		public string Titulo { get; set; }
		[Required]
		public string Informacion { get; set; }
		[Required]
		public byte[] ArchivoPdf { get; set; }
	}
}
