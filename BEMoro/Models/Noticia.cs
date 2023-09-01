using System.ComponentModel.DataAnnotations;

namespace BEMoro.Models
{
	public class Noticia
	{
		public int Id { get; set; }
		[Required]
		public string Titulo { get; set; }
		[Required]
		public DateTime Fecha { get; set; }
		[Required]
		public string Subtitulo { get; set; }
		[Required]
		public string Nota { get; set; }
		[Required]
		public string Contenido { get; set; }
        public byte[] Imagen1 { get; set; }
        public string NotaI1 { get; set; }
        public byte[] Imagen2 { get; set; }
        public string NotaI2 { get; set; }

    }
}
