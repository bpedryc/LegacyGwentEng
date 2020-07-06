using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("12040")]//青草试炼
    public class TrialOfTheGrasses : CardEffect
    {//使1个“猎魔人”单位增益至25点战力；或对1个非“猎魔人”单位造成10点伤害，若目标存活，则使其增益至25点战力。
        public TrialOfTheGrasses(GameCard card) : base(card) { }
        public override async Task<int> CardUseEffect()
        {
            if (!(await Card.GetSelectPlanceCards()).TrySingle(out var target))
            {
                return 0;
            }
            if (!target.HasAllCategorie(Categorie.Witcher))
            {
                await target.Effect.Damage(10, Card, BulletType.RedLight);
            }
            var point = 25 - target.CardPoint();
            if (!(target.IsAliveOnPlance() && point > 0))
            {
                return 0;
            }
            await target.Effect.Boost(point, Card);
            return 0;
        }
    }
}