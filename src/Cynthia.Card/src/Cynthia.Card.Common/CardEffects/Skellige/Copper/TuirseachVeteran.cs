using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("64016")]//图尔赛克家族老兵
    public class TuirseachVeteran : CardEffect
    {//使位于手牌、牌组和己方半场除自身外的所有“图尔赛克家族”单位获得1点强化。
        public TuirseachVeteran(GameCard card) : base(card) { }
        public override async Task<int> CardPlayEffect(bool isSpying, bool isReveal)
        {
            var cards = Game.PlayersHandCard[PlayerIndex].Concat(Game.GetPlaceCards(PlayerIndex)).Concat(Game.PlayersDeck[PlayerIndex]).FilterCards(filter: x => x.HasAllCategorie(Categorie.ClanTuirseach) && x != Card);

            foreach (var card in cards)
            {
                await card.Effect.Strengthen(1, Card);
            }
            return 0;
        }
    }
}