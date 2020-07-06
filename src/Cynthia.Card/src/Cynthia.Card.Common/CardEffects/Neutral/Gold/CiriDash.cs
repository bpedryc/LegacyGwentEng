using System;
using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("12005")]//希里：冲刺
    public class CiriDash : CardEffect, IHandlesEvent<AfterCardToCemetery>
    {//被置入墓场时返回牌组，并获得3点强化。
        public CiriDash(GameCard card) : base(card) { }

        public async Task HandleEvent(AfterCardToCemetery @event)
        {
            if (@event.Target != Card) return;
            var range = RNG.Next(0, Game.PlayersHandCard[PlayerIndex].Count() + 1);
            await Card.Effect.Resurrect(new CardLocation(RowPosition.MyDeck, range), Card);
            await Card.Effect.Strengthen(3, Card);
        }
    }
}