using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("25008")]//血月
    public class BloodMoon : CardEffect
    {//在对方单排降下灾厄，对该排上所有单位造成2点伤害。
        public BloodMoon(GameCard card) : base(card) { }
        public override async Task<int> CardUseEffect()
        {
            var result = await Game.GetSelectRow(Card.PlayerIndex, Card, TurnType.Enemy.GetRow());
            await Game.GameRowEffect[AnotherPlayer][result.Mirror().MyRowToIndex()]
                .SetStatus<BloodMoonStatus>();
            return 0;

        }
    }
}