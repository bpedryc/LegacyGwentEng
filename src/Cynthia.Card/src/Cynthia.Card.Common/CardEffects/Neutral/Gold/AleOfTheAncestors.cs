using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("12009")]//先祖麦酒
    public class AleOfTheAncestors : CardEffect
    {//在所在排洒下“黄金酒沫”。
        public AleOfTheAncestors(GameCard card) : base(card) { }
        public override async Task<int> CardPlayEffect(bool isSpying, bool isReveal)
        {
            // await Game.ApplyWeather(PlayerIndex,Card.Status.CardRow,RowStatus.GoldenFroth);
            await Game.GameRowEffect[PlayerIndex][Card.Status.CardRow.MyRowToIndex()]
                .SetStatus<GoldenFrothStatus>();
            return 0;
        }
    }
}