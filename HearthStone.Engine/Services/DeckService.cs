using System;
using System.Collections.Generic;
using System.Linq;

namespace HearthStone.Engine.Services
{
    public static class DeckService
    {
        public static Deck LoadDeck(string content)
        {
            var deck = new Deck();

            foreach (var line in content.Split(new [] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                var card = new Card(line);

                deck.Cards.Add(card);
            }

            GameLogService.AddLog(deck.Cards.Count + " cards loaded from the deck");

            return deck;
        }

        public static Deck ShuffleDeckCards(Deck deck)
        {
            var rnd = new Random();
            deck.Cards = deck.Cards.OrderBy(x => rnd.Next()).ToList();
            return deck;
        }

        public static Card DrawCard(Deck deck)
        {
            if (deck.Cards.Count > 0)
            {
                var card = deck.Cards[0];
                deck.Cards.RemoveAt(0);
                return card;
            }

            return null;
        }

        public static List<Card> DrawCards(int numberOfCard, Deck deck)
        {
            var result = new List<Card>();

            for (int i = 0; i < numberOfCard; i++)
            {
                result.Add(DrawCard(deck));
            }

            return result;
        }
    }
}
