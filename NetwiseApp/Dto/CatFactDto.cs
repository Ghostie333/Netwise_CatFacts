namespace NetwiseApp.Dto
{
    public record CatFactDto
    {
        public string Fact { get; set; } = string.Empty;
        public int Length { get; set; }
    }
}
