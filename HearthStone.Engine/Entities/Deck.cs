using System.Collections.Generic;

namespace HearthStone.Engine
{
    public class Deck
    {
        public Deck()
        {
            Cards = new List<Card>();
        }

        public List<Card> Cards { get; set; }
    }
}
