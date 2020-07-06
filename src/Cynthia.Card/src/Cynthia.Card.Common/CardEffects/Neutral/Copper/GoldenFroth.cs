using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("14026")]//黄金酒沫
    public class GoldenFroth : CardEffect
    {//在己方单排洒下恩泽。回合开始时，使2个随机单位获得1点增益。
        public GoldenFroth(GameCard card) : base(card) { }
        public override async Task<int> CardUseEffect()
        {
            var result = await Game.GetSelectRow(Card.PlayerIndex, Card, new List<RowPosition>() { RowPosition.MyRow1, RowPosition.MyRow2, RowPosition.MyRow3 });
            // await Game.ApplyWeather(Card.PlayerIndex,result,RowStatus.GoldenFroth);
            await Game.GameRowEffect[PlayerIndex][result.MyRowToIndex()]
                .SetStatus<GoldenFrothStatus>();
            return 0;
        }
    }
}