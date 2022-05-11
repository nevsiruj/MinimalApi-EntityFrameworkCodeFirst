namespace ApiC03
{
    public class Obra
    {
        public int Id { get; set; }
        public byte[]? Imagen { get; set; }
        public string? Titulo { get; set; }
        public DateOnly FechaDeCreacion { get; set; }
        public int Califacion { get; set; }
        public Personaje? Personaje { get; set; } 
    }
}
