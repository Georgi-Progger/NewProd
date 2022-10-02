namespace ASPProd.Models
{
    public class PlaceViewModel
    {
        public string Name { get; set; } = null!;
        public string Language { get; set; } = null!;
        public string? Information { get; set; }
        public IFormFile Image { get; set; } = null!;
    }
}
