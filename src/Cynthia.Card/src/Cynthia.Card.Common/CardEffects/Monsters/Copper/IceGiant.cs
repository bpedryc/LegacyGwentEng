using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
	[CardEffectId("24021")]//寒冰巨人
	public class IceGiant : CardEffect
	{//若场上任意位置有“刺骨冰霜”，则获得6点增益。
		public IceGiant(GameCard card) : base(card){}
		public override async Task<int> CardPlayEffect(bool isSpying,bool isReveal)
		{
            var flag = Game.GameRowEffect.SelectMany(x => x.Select(x => x.RowStatus)).Any(x => x == RowStatus.BitingFrost);
            if(flag)
            {
                await Boost(6, Card);
            }
			return 0;
		}
	}
}