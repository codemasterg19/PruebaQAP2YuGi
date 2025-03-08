namespace PruebaQAP2.Models
{
    public class CardResponse
    {
        public List<Card> data { get; set; }
    }

    public class Card
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int level { get; set; }
        public string race { get; set; }
        public string attribute { get; set; }
        public List<CardImage> card_images { get; set; }

        public List<CardPrice> card_prices { get; set; }
    }

    public class CardImage
    {
        public int id { get; set; }
        public string image_url { get; set; }
        public string image_url_small { get; set; }
    }

    public class CardPrice
    {
        public string cardmarket_price { get; set; }
        public string tcgplayer_price { get; set; }
        public string ebay_price { get; set; }
        public string amazon_price { get; set; }
        public string coolstuffinc_price { get; set; }
    }
}