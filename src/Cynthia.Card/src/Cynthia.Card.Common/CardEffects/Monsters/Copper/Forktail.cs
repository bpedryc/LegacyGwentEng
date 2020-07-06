using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
	[CardEffectId("24012")]//叉尾龙
	public class Forktail : CardEffect
	{//吞噬2个友军单位，并获得其战力的增益。
		public Forktail(GameCard card) : base(card){}
		public override async Task<int> CardPlayEffect(bool isSpying,bool isReveal)
		{
            for (var i = 0; i < 2; i++)
            {
                var card = (await Game.GetSelectPlaceCards(Card, selectMode: SelectModeType.MyRow)).SingleOrDefault();
                if (card != default)
                {
                    await Card.Effect.Consume(card);
                }
            }
            return 0;
        }
	}
}