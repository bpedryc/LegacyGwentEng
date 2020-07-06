using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("62011")]//珊瑚
    public class Coral : CardEffect
    {//将1个铜色/银色单位变为“翡翠人偶”。
        public Coral(GameCard card) : base(card) { }
        public override async Task<int> CardPlayEffect(bool isSpying, bool isReveal)
        {
            var result = await Game.GetSelectPlaceCards(Card, filter: x => x.Status.Group == Group.Copper || x.Status.Group == Group.Silver);
            if (result.Count <= 0)
            {
                return 0;
            }
            await result.Single().Effect.Transform(CardId.JadeFigurine, Card);
            return 0;
        }
    }
}