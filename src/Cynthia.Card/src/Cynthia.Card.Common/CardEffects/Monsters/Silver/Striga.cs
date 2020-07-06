using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("23013")]//吸血妖鸟
    public class Striga : CardEffect
    {//对1个非“怪兽”单位造成8点伤害。
        public Striga(GameCard card) : base(card) { }
        public override async Task<int> CardPlayEffect(bool isSpying, bool isReveal)
        {
            var targetList = await Game.GetSelectPlaceCards(Card, 1, filter: x => x.Status.Faction != Faction.Monsters, selectMode: SelectModeType.AllRow);
            if (!targetList.TrySingle(out var target))
            {
                return 0;
            }
            await target.Effect.Damage(8, Card);
            return 0;
        }
    }
}