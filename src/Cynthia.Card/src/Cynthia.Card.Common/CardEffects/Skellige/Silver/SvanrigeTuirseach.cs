using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("63006")]//斯凡瑞吉·图尔赛克
    public class SvanrigeTuirseach : CardEffect
    {//抽1张牌，随后丢弃1张牌。
        public SvanrigeTuirseach(GameCard card) : base(card) { }
        public override async Task<int> CardPlayEffect(bool isSpying, bool isReveal)
        {

            if (Game.PlayersDeck[Card.PlayerIndex].Count() >= 1)
            {
                await Game.PlayerDrawCard(Card.PlayerIndex);
            }
            //从手牌中选择一张弃牌,必须选
            var cards = await Game.GetSelectMenuCards(Card.PlayerIndex, Game.PlayersHandCard[Card.PlayerIndex], isCanOver: false);
            if (!cards.TrySingle(out var target))
            {
                return 0;
            }
            await target.Effect.Discard(Card);
            return 0;


        }
    }
}