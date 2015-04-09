using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AttributeRouting.Web.Http;
using HearthStone.Engine.Services;
using HearthStone.Engine.Static;

namespace HearthStone.ApiControllers
{
    public class GameController : ApiController
    {
        [POST("loaddeck")]
        public void Post([FromBody]string value)
        {
            var deck = DeckService.LoadDeck(value);
            deck = DeckService.ShuffleDeckCards(deck);
            Game.Deck1 = deck;
        }

        [GET("drawcard")]
        public IEnumerable<string> Get()
        {
            var card = DeckService.DrawCard(Game.Deck1);
            return new List<string> { card.Url };
        }
    }
}
