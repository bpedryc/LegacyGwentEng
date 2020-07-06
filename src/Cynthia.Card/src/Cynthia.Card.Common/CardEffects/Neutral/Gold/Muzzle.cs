using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("12036")]//嘴套
    public class Muzzle : CardEffect
    {//魅惑1个战力不高于8点的敌军铜色/银色单位。
        public Muzzle(GameCard card) : base(card) { }
        public override async Task<int> CardUseEffect()
        {
            var selectCards = await Game.GetSelectPlaceCards(Card,
                filter: x => x.IsAnyGroup(Group.Copper, Group.Silver) &&
                x.CardPoint() <= 8,
                selectMode: SelectModeType.EnemyRow);

            if (!selectCards.TrySingle(out var targetCard))
            {
                return 0;
            }
            await targetCard.Effect.Charm(Card);
            return 0;
        }
    }
}