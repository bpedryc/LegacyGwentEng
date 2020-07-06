using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("22004")]//卡兰希尔
    public class CaranthirArFeiniel : CardEffect
    {//将1个敌军单位移至对方同排，并在此排降下“刺骨冰霜”。
        public CaranthirArFeiniel(GameCard card) : base(card) { }
        public override async Task<int> CardPlayEffect(bool isSpying, bool isReveal)
        {
            if (!(await Game.GetSelectPlaceCards(Card, selectMode: SelectModeType.EnemyRow, filter: x => x.Status.CardRow != Card.Status.CardRow)).TrySingle(out var target))
            {
                await Game.GameRowEffect[AnotherPlayer][Card.Status.CardRow.MyRowToIndex()].SetStatus<BitingFrostStatus>();
                return 0;
            }
            await target.Effect.Move(new CardLocation(Card.Status.CardRow, int.MaxValue), Card);
            await Game.GameRowEffect[AnotherPlayer][Card.Status.CardRow.MyRowToIndex()].SetStatus<BitingFrostStatus>();

            return 0;
        }
    }
}