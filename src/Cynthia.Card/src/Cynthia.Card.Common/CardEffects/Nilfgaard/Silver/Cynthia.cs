using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("33013")]//辛西亚
    public class MsCynthia : CardEffect
    {//揭示对方手牌中最强的单位牌，并获得等同于其战力的增益。
        public MsCynthia(GameCard card) : base(card) { }
        public override async Task<int> CardPlayEffect(bool isSpying, bool isReveal)
        {
            var enemyhand = Game.RowToList(PlayerIndex, RowPosition.EnemyHand);
            var cards = enemyhand.Where(x => !x.Status.IsReveal && x.CardInfo().CardType == CardType.Unit).OrderByDescending(x => x.ToHealth().health);
            if (cards.Count() == 0) return 0;
            var card = cards.First();
            var point = card.ToHealth().health;
            await card.Effect.Reveal(Card);
            await Card.Effect.Boost(point, card);
            return 0;
        }
    }
}