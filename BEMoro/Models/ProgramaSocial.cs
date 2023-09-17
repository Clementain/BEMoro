using System.ComponentModel.DataAnnotations;

namespace BEMoro.Models
{
	public class ProgramaSocial
	{
        public int Id { get; set; }
		[Required]
		public byte[] Documento { get; set; }
		[Required]
		public string Nombre { get; set; }

	}
}
