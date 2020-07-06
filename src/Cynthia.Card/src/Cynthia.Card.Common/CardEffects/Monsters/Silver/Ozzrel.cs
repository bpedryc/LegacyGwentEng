using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("23015")]//欧兹瑞尔
    public class Ozzrel : CardEffect
    {//吞噬双方墓场中1个铜色/银色单位，获得其战力作为增益。
        public Ozzrel(GameCard card) : base(card) { }
        public override async Task<int> CardPlayEffect(bool isSpying, bool isReveal)
        {
            var selectList = Game.PlayersCemetery[PlayerIndex].Concat(Game.PlayersCemetery[AnotherPlayer]).Where(x => x.IsAnyGroup(Group.Copper, Group.Silver) && x.Status.Type == CardType.Unit).ToList();

            var target = await Game.GetSelectMenuCards(PlayerIndex, selectList);

            if (!target.ToList().TrySingle(out var targetCard))
            {
                return 0;
            }

            await Consume(targetCard);

            return 0;
        }
    }
}