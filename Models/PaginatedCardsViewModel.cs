namespace PruebaQAP2.Models
{
    public class PaginatedCardsViewModel
    {
        public List<Card> Cards { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
