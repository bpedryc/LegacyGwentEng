using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("13019")]//爱丽丝·伊佛瑞克
    public class IrisVonEverec : CardEffect, IHandlesEvent<AfterCardDeath>
    {//间谍。 遗愿：使对面半场5个随机单位获得5点增益。
        public IrisVonEverec(GameCard card) : base(card) { }

        public async Task HandleEvent(AfterCardDeath @event)
        {
            if (@event.Target != Card) return;
            var cards = Game.GetAllCard(Card.PlayerIndex).Where(x => x.Status.CardRow.IsOnPlace() && x.PlayerIndex == AnotherPlayer).Mess(RNG).Take(5).ToList();
            foreach (var card in cards)
            {
                if (card.Status.CardRow.IsOnPlace())
                    await card.Effect.Boost(5, Card);
            }
            return;
        }
    }
}