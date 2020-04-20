using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Models
{
    public class Deck
    {
        public DeckData Data { get; set; }
        public DeckHand Hand { get; set; }
    }

    public class DeckData
    {
        public string Success { get; set; }
        public string Deck_Id { get; set; }
        public string Shuffled { get; set; }
        public string Remaining { get; set; }
    }
    public class DeckHand 
    {
        public string Image { get; set; }
        public string Success { get; set; }
        public string Value { get; set; }
        public string Suit { get; set; }
        
    }

}
