using System;
using System.Collections.Generic;
using System.Linq;

namespace Cynthia.Card
{
    public static class GwentMap
    {
        public static IEnumerable<CardStatus> GetCards(bool isHasDerive = false, bool isHasAgent = false)
        {
            return CardMap
            .Where(x => isHasDerive ? true : !x.Value.IsDerive)
            .Where(x => isHasAgent ? true : !x.Value.HasAnyCategorie(Categorie.Agent))
            .OrderByDescending(x => x.Value.Group)
            .ThenBy(x => x.Value.Faction)
            .ThenBy(x => x.Value.Strength)
            .Select(x => new CardStatus(x.Key));
        }
        public static IEnumerable<string> GetCreateCardsId(Func<CardStatus, bool> filter, Random rng, int count = 3, bool isHasDerive = false, bool isHasAgent = false)
        {
            return GetCards(isHasDerive, isHasAgent)
                .Where(filter)
                .Mess(rng).Take(count).Select(x => x.CardId)
                .ToList();
        }
        public static IEnumerable<string> GetCardsId(bool isHasDerive = false)
        {
            return CardMap
            .Where(x => !x.Value.IsDerive)
            .OrderByDescending(x => x.Value.Group)
            .ThenBy(x => x.Value.Faction)
            .ThenBy(x => x.Value.Strength)
            .Select(x => x.Key);
        }

        public static IDictionary<Categorie, string> CategorieInfoMap { get; } = new Dictionary<Categorie, string>()
        {
            { Categorie.DoubleAgent, "Double Agent" },
            { Categorie.WildHunt, "Wild Hunt" },
            { Categorie.Tactic, "Tactic" },
            { Categorie.Beast, "Beast" },
            { Categorie.Leader, "Leader" },
            { Categorie.Mage, "Mage" },
            { Categorie.Boss, "???" },
            { Categorie.Vampire, "Vampire" },
            { Categorie.Cintra, "Cintra" },
            { Categorie.Insectoid, "Insectoid" },
            { Categorie.Stray, "Stray" },
            { Categorie.Construct, "Construct" },
            { Categorie.Spell, "Spell" },
            { Categorie.Redania, "Redania" },
            { Categorie.SiegeSupport, "Siege Support" },
            { Categorie.ClanDrummond, "Clan Drummond" },
            { Categorie.Specter, "Specter" },
            { Categorie.Cursed, "Cursed" },
            { Categorie.Soldier, "Soldier" },
            { Categorie.Kaedwen, "Kaedwen" },
            { Categorie.Vodyanoi, "Vodyanoi" },
            { Categorie.ClanTuirseach, "Clan Tuirseach" },
            { Categorie.ClanTordarroch, "Clan Tordarroch" },
            { Categorie.ClanDimun, "Clan Dimun" },
            { Categorie.Witcher, "Witcher" },
            { Categorie.Cultist, "Cultist" },
            { Categorie.Alchemy, "Alchemy" },
            { Categorie.Reckless, "Reckless" },
            { Categorie.ClanHeymaey, "Clan Heymaey" },
            { Categorie.Blitz, "Blitz" },
            { Categorie.Dryad, "Dryad" },
            { Categorie.Special, "Special" },
            { Categorie.Elf, "Elf" },
            { Categorie.Lyria, "Lyria" },
            { Categorie.Necrophage, "Necrophage" },
            { Categorie.Machine, "Machine" },
            { Categorie.Aedirn, "Aedirn" },
            { Categorie.Support, "Support" },
            { Categorie.ClanAnCraite, "Clan An Craite" },
            { Categorie.Dwarf, "Dwarf" },
            { Categorie.Draconid, "Draconid" },
            { Categorie.SiegeEngine, "Siege Engine" },
            { Categorie.Temeria, "Temeria" },
            { Categorie.Officer, "Officer" },
            { Categorie.Weather, "Weather" },
            { Categorie.Organic, "Organic" },
            { Categorie.Item, "Item" },
            { Categorie.Hazard, "Hazard" },
            { Categorie.Boon, "Boon" },
            { Categorie.Ambush, "Ambush" },
            { Categorie.Doomed, "Doomed" },
            { Categorie.Bear, "Bear" },
            { Categorie.Ogroid, "Ogroid" },
            { Categorie.BlueStripes, "Blue Stripes" },
            { Categorie.Breedable, "Breedable" },
            { Categorie.Devourer, "Devourer" },
            { Categorie.Dragon, "Dragon" },
            { Categorie.Harpy, "Harpy" },
            { Categorie.Medic, "Medic" },
            { Categorie.Stubborn, "Stubborn" },
            { Categorie.Permadeath, "Permadeath" },
            { Categorie.Peasant, "Peasant" },
            { Categorie.Potion, "Potion" },
            { Categorie.Relict, "Relict" },
            { Categorie.Regressing, "Regressing" },
            { Categorie.Shapeshifter, "Shapeshifter" },
            { Categorie.Token, "Token" },
            { Categorie.Agent, "Agent" },
            { Categorie.ClanBrokvar, "Clan Brokvar" },
            { Categorie.Test, "Test" },
        };
        public static RowEffect CreateRowEffect(RowStatus rowTag)
        {
            switch (rowTag)
            {
                case RowStatus.BitingFrost:
                    return new BitingFrostStatus();
                case RowStatus.BloodMoon:
                    return new BloodMoonStatus();
                case RowStatus.DragonDream:
                    return new DragonDreamStatus();
                case RowStatus.ImpenetrableFog:
                    return new ImpenetrableFogStatus();
                case RowStatus.KorathiHeatwave:
                    return new KorathiHeatwaveStatus();
                case RowStatus.PitTrap:
                    return new PitTrapStatus();
                case RowStatus.RaghNarRoog:
                    return new RaghNarRoogStatus();
                case RowStatus.SkelligeStorm:
                    return new SkelligeStormStatus();
                case RowStatus.TorrentialRain:
                    return new TorrentialRainStatus();
                default:
                    return new NoneStatus();
            }
        }
        public static IDictionary<string, GwentCard> CardMap { get; } = new Dictionary<string, GwentCard>
        {
            //=========================================================================================================================================================================
            //以下是自动导入的代码
            //=========================================================================================================================================================================
            {
                "12004",//利维亚的杰洛特
                new GwentCard()
                {
                    CardId ="12004",
                    Name="Geralt of Rivia",
                    Strength=15,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    HideTags = new HideTag[]{HideTag.Geralt},
                    Flavor = "If that's what it takes to save the world, it's better to let that world die.",
                    Info = "No effects",
                    CardArtsId = "11210300",
                }
            },
            {
                "12005",//希里：冲刺
                new GwentCard()
                {
                    CardId ="12005",
                    Name="Ciri: Dash",
                    Strength=11,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cintra,Categorie.Witcher},
                    Flavor = "Know when fairy tales cease to be tales? When people start believing them. ",
                    Info = "Whenever this unit enters the graveyard, return it to your deck and Strengthen it by 3.",
                    CardArtsId = "11211000",
                }
            },
            {
                "12006",//萨琪亚萨司：龙焰
                new GwentCard()
                {
                    CardId ="12006",
                    Name="Saesenthessis: Blaze",
                    Strength=11,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Aedirn,Categorie.Draconid},
                    Flavor = "I inherited my father's ability to assume other forms - well, one other form, in my case. ",
                    Info = "Banish your hand and draw that many cards.",
                    CardArtsId = "20005700",
                }
            },
            {
                "12007",//特莉丝·梅莉葛德
                new GwentCard()
                {
                    CardId ="12007",
                    Name="Triss Merigold",
                    Strength=10,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Temeria},
                    HideTags = new HideTag[]{HideTag.Triss},
                    Flavor = "I can take care of myself. Trust me.",
                    Info = "Deal 5 damage.",
                    CardArtsId = "11210600",
                }
            },
            {
                "12008",//维伦特瑞坦梅斯
                new GwentCard()
                {
                    CardId ="12008",
                    Name="Villentretenmerth",
                    Strength=10,
                    Countdown = 3,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = true,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Draconid},
                    Flavor = "Also calls himself Borkh Three Jackdaws… he's not the best at names. ",
                    Info = "After 3 turns, destroy the Highest units. 3 Armor.",
                    CardArtsId = "11210700",
                }
            },
            {
                "12009",//先祖麦酒
                new GwentCard()
                {
                    CardId ="12009",
                    Name="Ale of the Ancestors",
                    Strength=10,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{},
                    Flavor = "Boros, the legendary founder of Clan Fuchs, died after overindulging in this beverage - he passed out while reaching for his golden ring, which had fallen into a brook.",
                    Info = "Apply Golden Froth to the row",
                    CardArtsId = "20024400",
                }
            },
            {
                "12010",//叶奈法：咒术师
                new GwentCard()
                {
                    CardId ="12010",
                    Name="Yennefer: Conjurer",
                    Strength=10,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Aedirn},
                    HideTags = new HideTag[]{HideTag.Yennefer},
                    Flavor = "A good sorceress must know when to conjure ice... and when to conjure fire. ",
                    Info = "Deal 1 damage to the Highest enemies on turn end.",
                    CardArtsId = "11211300",
                }
            },
            {
                "12011",//丹德里恩：虚妄荣光
                new GwentCard()
                {
                    CardId ="12011",
                    Name="Dandelion: Vainglory",
                    Strength=9,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support},
                    Flavor = "Dandelion told me all about your adventures. How'd he ready you for battle with his songs, how he tamed the kayran by playin' his lute...",
                    Info = "For every Geralt, Yennefer, Ciri or Zoltan card in your own starting deck gain 3 points",
                    CardArtsId = "20177400",
                }
            },
            {
                "12012",//阿瓦拉克
                new GwentCard()
                {
                    CardId ="12012",
                    Name="Avallac'h",
                    Strength=8,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Elf},
                    Flavor = "You humans have... unusual tastes.",
                    Info = "Truce: Each player draws 2 cards",
                    CardArtsId = "13210500",
                }
            },
            {
                "12013",//兰伯特：剑术大师
                new GwentCard()
                {
                    CardId ="12013",
                    Name="Lambert: Swordmaster",
                    Strength=8,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    Flavor = "Go teach your grandma to suck eggs.",
                    Info = "Deal 4 damage to all copies of an enemy unit.",
                    CardArtsId = "20023500",
                }
            },
            {
                "12014",//特莉丝：蝴蝶咒语
                new GwentCard()
                {
                    CardId ="12014",
                    Name="Triss: Butterfly Spell",
                    Strength=8,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Temeria},
                    HideTags = new HideTag[]{HideTag.Triss},
                    Flavor = "Cap'n... our arrows, they've... they've got wings!",
                    Info = "Boost the Lowest allies by 1 on turn end.",
                    CardArtsId = "12210700",
                }
            },
            {
                "12015",//卓尔坦：流氓
                new GwentCard()
                {
                    CardId ="12015",
                    Name="Zoltan: Scoundrel",
                    Strength=8,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Dwarf},
                    HideTags = new HideTag[]{HideTag.Zoltan},
                    Flavor = "Apologies. My exotic pet's a clever birdie, but a wee bit lewd. Paid ten thalers for the beaute.",
                    Info = "Choose One: Spawn a Companion that boosts 2 adjacent units by 2; or Spawn an Agitator that deals 2 damage to 2 adjacent units.",
                    CardArtsId = "11210900",
                }
            },
            {
                "12016",//艾斯卡尔：寻路者
                new GwentCard()
                {
                    CardId ="12016",
                    Name="Eskel: Pathfinder",
                    Strength=7,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    Flavor = "Heard you panting from three miles away. Just didn't wanna give up that vantage point. ",
                    Info = "Destroy a Bronze or Silver enemy that is not boosted",
                    CardArtsId = "20023600",
                }
            },
            {
                "12017",//杰洛特：猎魔大师
                new GwentCard()
                {
                    CardId ="12017",
                    Name="Geralt: Professional",
                    Strength=7,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    HideTags = new HideTag[]{HideTag.Geralt},
                    Flavor = "I accepted a job once, did it. Asked to choose my reward, I invoked the Law of Surprise. ",
                    Info = "Deal 4 damage to an enemy unit. If it's a monster unint, destroy it instead.",
                    CardArtsId = "20175900",
                }
            },
            {
                "12018",//伊瓦拉夸克斯
                new GwentCard()
                {
                    CardId ="12018",
                    Name="Ihuarraquax",
                    Strength=7,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = true,
                    Countdown = 1,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    Flavor = "\"Inconceivable. Impossible\", Ciri thought, returning to her senses. \"Unicorns don't exist, not any more, not in this world. Unicorns are extinct.\" ",
                    Info = "Deal 5 damage to self. When the current power is equalt to the base power, deal 7 damage to 3 random enemy units at the end of the turn.",
                    CardArtsId = "20005100",
                }
            },
            {
                "12019",//希里
                new GwentCard()
                {
                    CardId ="12019",
                    Name="Ciri",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cintra,Categorie.Witcher},
                    Flavor = "I go wherever I please, whenever I please",
                    Info = "Whenever you lose a round, return this unit to your hand. 2 ",
                    CardArtsId = "11210100",
                }
            },
            {
                "12020",//刚特·欧迪姆
                new GwentCard()
                {
                    CardId ="12020",
                    Name="Gaunter O'Dimm",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Relict},
                    Flavor = "He always grants exactly what you wish for. That's the problem. ",
                    Info = "Gamble with Gaunter: Guess whether the power of the card he's picked has power lesser, equalt or greater than 6.",
                    CardArtsId = "13221500",
                }
            },
            {
                "12021",//杰洛特：阿尔德法印
                new GwentCard()
                {
                    CardId ="12021",
                    Name="Geralt: Aard",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    HideTags = new HideTag[]{HideTag.Geralt},
                    Flavor = "A blast of concentrated energy that pummels everything in its path. Great for when you forget your keys. ",
                    Info = "Deal 3 damage to 3 enemies and move them to the row above.",
                    CardArtsId = "11211100",
                }
            },
            {
                "12022",//雷吉斯：高等吸血鬼
                new GwentCard()
                {
                    CardId ="12022",
                    Name="Regis: Higher Vampire",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Vampire},
                    Flavor = "He becomes invisible at will. His glance hypnotizes into a deep sleep. He then drinks his fill, turns into a bat and flies off. Altogether uncouth. ",
                    Info = "Look at 3 Bronze units from your opponent's deck. Consume 1, then boost self by its base power.",
                    CardArtsId = "11210500",
                }
            },
            {
                "12023",//维瑟米尔：导师
                new GwentCard()
                {
                    CardId ="12023",
                    Name="Vesemir: Mentor",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    Flavor = "Killing monsters is not something to be taken lightly. Ciri must understand that if she's to become one of us. ",
                    Info = "Play a Bronze or Silver Alchemy card from your deck.",
                    CardArtsId = "20023700",
                }
            },
            {
                "12024",//叶奈法
                new GwentCard()
                {
                    CardId ="12024",
                    Name="Yennefer",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Aedirn},
                    HideTags = new HideTag[]{HideTag.Yennefer},
                    Flavor = "Magic is Chaos, Art and Science. It is a curse, a blessing and a progression. ",
                    Info = "Choose One: Spawn a Unicorn that boosts all units by 2; or Spawn a Chironex that deals 2 damage to all units.",
                    CardArtsId = "11210800",
                }
            },
            {
                "12025",//杰洛特：亚登法印
                new GwentCard()
                {
                    CardId ="12025",
                    Name="Geralt: Yrden",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    HideTags = new HideTag[]{HideTag.Geralt},
                    Flavor = "He lay down next to Adda's mummified remains, drawing the Yrden Sign on the inner side of her sarcophagus' lid. ",
                    Info = "Reset all units on a row and remove thair tokens.",
                    CardArtsId = "20152300",
                }
            },
            {
                "12026",//特莉丝：心灵传动
                new GwentCard()
                {
                    CardId ="12026",
                    Name="Triss: Telekinesis",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Temeria},
                    HideTags = new HideTag[]{HideTag.Triss},
                    Flavor = "Bindings won't suffice. Nor will a gag render her any less dangerous. No, dimeritium is the only solution.",
                    Info = "Create and play a bronze special card from either player's current deck.",
                    CardArtsId = "20177300",
                }
            },
            {
                "12002",//杰洛特：伊格尼法印
                new GwentCard()
                {
                    CardId ="12002",
                    Name="Geralt: Igni",
                    Strength=5,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    HideTags = new HideTag[]{HideTag.Geralt},
                    Flavor = "A twist of a witcher's fingers can light a lamp… or incinerate a foe. ",
                    Info = "Destroy the Highest units on an enemy row if that row has a total of 25 or more.",
                    CardArtsId = "11210200",
                }
            },
            {
                "12027",//狐妖
                new GwentCard()
                {
                    CardId ="12027",
                    Name="Aguara",
                    Strength=5,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Relict},
                    Flavor = "Smarten up right now, or it's off to an aguara with you! ",
                    Info = "Choose Two: Boost the Lowest ally by 5; Boost a random unit in your hand by 5; Deal 5 damage to the Highest enemy; Charm an enemy Elf with 5 power or less.",
                    CardArtsId = "20006200",
                }
            },
            {
                "12028",//凤凰
                new GwentCard()
                {
                    CardId ="12028",
                    Name="Phoenix",
                    Strength=5,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Draconid,Categorie.Doomed},
                    Flavor = "What came first, the chicken or the egg? Compared to the conundrum that is the phoenix, the question seems downright trivial. ",
                    Info = "Resurrect a Bronze or Silver Draconid.",
                    CardArtsId = "20157900",
                }
            },
            {
                "12003",//丹德里恩：传奇诗人
                new GwentCard()
                {
                    CardId ="12003",
                    Name="Dandelion: Poet",
                    Strength=5,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support},
                    Flavor = "The quill is mightier than the sword.",
                    Info = "Draw 1 card and then play 1 card.",
                    CardArtsId = "20177600",
                }
            },
            {
                "12029",//阿瓦拉克：贤者
                new GwentCard()
                {
                    CardId ="12029",
                    Name="Avallac'h: Sage",
                    Strength=3,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Elf},
                    Flavor = "Amongst the free elves were a handful of Aen Saevherne, or Sages. They were an enigma, bordering on a legend. ",
                    Info = "Spawn a copy of a random Gold or Silver unit from your opponent's starting deck.",
                    CardArtsId = "11211200",
                }
            },
            {
                "12030",//狐妖：真身
                new GwentCard()
                {
                    CardId ="12030",
                    Name="Aguara: True Form",
                    Strength=2,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Relict},
                    Flavor = "Ever heard of an \"anterion\"? Think of it as the opposite of a lycanthrope: a beast which can take on a human form. ",
                    Info = "Create a Bronze or Silver Spell",
                    CardArtsId = "20005600",
                }
            },
            {
                "12031",//雷吉斯
                new GwentCard()
                {
                    CardId ="12031",
                    Name="Regis",
                    Strength=1,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Vampire},
                    Flavor = "Men, the polite ones, at least, would call me a monster. A blood–drinking freak.",
                    Info = "Drain all boosts from a unit.",
                    CardArtsId = "11210400",
                }
            },
            {
                "12032",//希里：新星
                new GwentCard()
                {
                    CardId ="12032",
                    Name="Ciri: Nova",
                    Strength=1,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cintra,Categorie.Witcher,Categorie.Doomed},
                    Flavor = "Zireael possesses a great power she cannot control. She is a danger - to herself, to others. Until she learns to control it, she should remain isolated.",
                    Info = "If you have exactly 2 copies of each bronze in your deck, the base power of this card becomes 22 points.",
                    CardArtsId = "20162600",
                }
            },
            {
                "12033",//科拉兹热浪
                new GwentCard()
                {
                    CardId ="12033",
                    Name="Korathi Heatwave",
                    Strength=0,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Hazard},
                    Flavor = "Vicovaro scholars have determined that, in the absence of imperial aid, drought-stricken provinces lose half their population, two-thirds of their livestock and all their will to rebel.",
                    Info = "Apply a Hazard to each enemy row that deals 2 damage to the Lowest unit on turn start.",
                    CardArtsId = "20001800",
                }
            },
            {
                "12034",//终末之战
                new GwentCard()
                {
                    CardId ="12034",
                    Name="Ragh Nar Roog",
                    Strength=0,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special,Categorie.Hazard},
                    Flavor = "In the Final Age, Hemdall will come forth to face the evil issuing from the land of Morhogg – the legions of wraiths, demons and specters of Chaos",
                    Info = "Apply a Hazard to each enemy row that deals 2 damage to the Highest unit on turn start.",
                    CardArtsId = "11310100",
                }
            },
            {
                "12035",//复原
                new GwentCard()
                {
                    CardId ="12035",
                    Name="Renew",
                    Strength=0,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "Medicus curat, magicae sanat.",
                    Info = "Resurrect a Gold unit.",
                    CardArtsId = "11331600",
                }
            },
            {
                "12001",//皇家谕令
                new GwentCard()
                {
                    CardId ="12001",
                    Name="Royal Decree",
                    Strength=0,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "We, Foltest, by divine right King of Temeria, Prince of Sodden, Senior Protector of Brugge, etcetera, etcetera, do hereby decree the following..",
                    Info = "Play a Gold unit from your deck and boost it by 2.",
                    CardArtsId = "20015400",
                }
            },
            {
                "12036",//嘴套
                new GwentCard()
                {
                    CardId ="12036",
                    Name="Vigo's Muzzle",
                    Strength=0,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Item},
                    Flavor = "Not every beast can be tamed. But all can be muzzled. ",
                    Info = "Move a Bronze or Silver enemy with 8 power or less to the opposite row.",
                    CardArtsId = "20022500",
                }
            },
            {
                "12037",//附子草
                new GwentCard()
                {
                    CardId ="12037",
                    Name="Wolfsbane",
                    Strength=0,
                    Group=Group.Gold,
                    Countdown = 3,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = true,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Organic},
                    Flavor = "Also known as 'the queen of poisons,' wolfsbane is used in many witcher Potions and alchemic brews",
                    Info = "After 3 turns in the graveyard, deal 6 damage to the Highest enemy and boost the Lowest ally by 6.",
                    CardArtsId = "20022600",
                }
            },
            {
                "12038",//哈马维的梦境
                new GwentCard()
                {
                    CardId ="12038",
                    Name="Hanmarvyn's Blue Dream",
                    Strength=0,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special},
                    Flavor = "This spell lets you see the last moment's of a dead man's life... if you can survive its casting. ",
                    Info = "Spawn a copy of a Gold unit from your opponent's graveyard and boost it by 2.",
                    CardArtsId = "20007900",
                }
            },
            {
                "12039",//乌马的诅咒
                new GwentCard()
                {
                    CardId ="12039",
                    Name="Uma's Curse",
                    Strength=0,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "I give you three solid leads, trails as fresh as morning dew, the aid of my spies and my court sorceress. Yet in my daughter's stead, you bring me this... monstrosity? ",
                    Info = "Create a Gold unit",
                    CardArtsId = "20005800",
                }
            },
            {
                "12040",//青草试炼
                new GwentCard()
                {
                    CardId ="12040",
                    Name="Trial of the Grasses",
                    Strength=0,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special},
                    Flavor = "Imagine a lump of clay. In order to shape it, you must first moisten it or it will crumble. The Trial's initial part does just that. It opens the body to change, so to speak. Only then can the mutagens produce a witcher. ",
                    Info = "Deal 10 damage to a unit, unless it's a Witcher. If it survives, boost it to 25 power.",
                    CardArtsId = "20007800",
                }
            },
            {
                "12041",//店店的大冒险
                new GwentCard()
                {
                    CardId ="12041",
                    Name="Shupe's Bizzarre Adventure",
                    Strength=0,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Organic},
                    Flavor = "Other trolls always considered him a bit odd - after all, who in their right mind would prefer colorful scraps of paper to rocks?",
                    Info = "If your starting deck has no duplicates, send Shupe on an adventure.",
                    CardArtsId = "20027500",
                }
            },
            {
                "12042",//矮人符文剑
                new GwentCard()
                {
                    CardId ="12042",
                    Name="Sihil",
                    Strength=0,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Item},
                    Flavor = "\"What's written on this blade? That a curse?\" \"No. An insult.\" ",
                    Info = "Choose One: Deal 3 damage to all enemies with odd power; or Deal 3 damage to all enemies with even power; or Play a random Bronze or Silver unit from your deck.",
                    CardArtsId = "20163200",
                }
            },
            {
                "13003",//莎拉
                new GwentCard()
                {
                    CardId ="13003",
                    Name="Sarah",
                    Strength=11,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Relict},
                    Flavor = "来陪小莎拉玩游戏吧！",
                    Info = "交换1张颜色相同的牌。",
                    CardArtsId = "11221200",
                }
            },
            {
                "13004",//爱丽丝的同伴
                new GwentCard()
                {
                    CardId ="13004",
                    Name="Iris' Companions",
                    Strength=11,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Relict},
                    Flavor = "我们的名字还是不说为好。就当我们是……主人家的朋友吧。",
                    Info = "将1张牌从牌组移至手牌，然后随机丢弃1张牌。",
                    CardArtsId = "20008300",
                }
            },
            {
                "13005",//吉尔曼
                new GwentCard()
                {
                    CardId ="13005",
                    Name="Germain Piquant",
                    Strength=10,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "陶森特需要这位英雄，但它不配。",
                    Info = "Spawn 2 Cows on each side of this unit. ",
                    CardArtsId = "20129000",
                }
            },
            {
                "13006",//纳威伦
                new GwentCard()
                {
                    CardId ="13006",
                    Name="Nivellen",
                    Strength=10,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed},
                    Flavor = "迷路了？要迷路到其它地方去，只要别在我这儿瞎逛就行。把你的左耳对准太阳，一直往前，没多久就能走上大路。怎么？你还在等什么？",
                    Info = "Move all units on a row to random rows",
                    CardArtsId = "20008900",
                }
            },
            {
                "13007",//斯崔葛布
                new GwentCard()
                {
                    CardId ="13007",
                    Name="Stregobor",
                    Strength=10,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "猎魔人见过看上去像议员的贼，见过看上去像乞丐的议员，也见过看上去像贼的国王。不过斯崔葛布的样子，就和大众心目中法师的形象没什么两样。",
                    Info = "Truce: Each player draws a unit and sets its power to 1.",
                    CardArtsId = "20009100",
                }
            },
            {
                "13008",//乔尼
                new GwentCard()
                {
                    CardId ="13008",
                    Name="Johnny",
                    Strength=9,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Relict},
                    Flavor = "要是再也没办法亲口说出“狮子头上长虱子”，生活就真的太无趣啦。",
                    Info = "Discard a card. Then make a copy of a card of the same color from your opponent's starting deck in your hand. ",
                    CardArtsId = "11221100",
                }
            },
            {
                "13009",//赛浦利安·威利
                new GwentCard()
                {
                    CardId ="13009",
                    Name="Cyprian Wiley",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Redania},
                    Flavor = "诺维格瑞的黑帮四巨头之一——另外三个是西吉·卢文、卡罗·“砍刀”·凡瑞西和乞丐王。",
                    Info = "Weaken a unit by 4",
                    CardArtsId = "11221400",
                }
            },
            {
                "13010",//奥克维斯塔
                new GwentCard()
                {
                    CardId ="13010",
                    Name="Ocvist",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    Countdown = 4,
                    IsDoomed = false,
                    IsCountdown = true,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Draconid},
                    Flavor = "他是石英山之主，毁灭者，图拉真的屠夫。但在闲暇时间里，他喜欢远足和烛光晚餐。",
                    Info = "Single-Use. After 4 turns, deal 1 damage to all enemies, then return to your hand on turn start. ",
                    CardArtsId = "11220600",
                }
            },
            {
                "13011",//卡罗“砍刀”凡瑞西
                new GwentCard()
                {
                    CardId ="13011",
                    Name="Carlo Varese",
                    Strength=7,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Dwarf},
                    Flavor = "每个想要在诺维格瑞做生意的都很清楚——要么同意卡罗的条件，要么就夹着尾巴滚出去。",
                    Info = "Deal 1 damage for each card in your hand. ",
                    CardArtsId = "12221600",
                }
            },
            {
                "13012",//米尔加塔布雷克
                new GwentCard()
                {
                    CardId ="13012",
                    Name="Myrgtabrakke",
                    Strength=7,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Draconid},
                    Flavor = "永远别想分开母龙和她的孩子。",
                    Info = "Deal 2 damage 2 times. ",
                    CardArtsId = "11220500",
                }
            },
            {
                "13013",//维瑟米尔
                new GwentCard()
                {
                    CardId ="13013",
                    Name="Vesemir",
                    Strength=7,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    Flavor = "就算上了绞架也别放弃——让他们给你拿点水，毕竟没人知道水拿来前会发生什么。",
                    Info = "Summon Eskel and Lambert. ",
                    CardArtsId = "11220300",
                }
            },
            {
                "13014",//艾斯卡尔
                new GwentCard()
                {
                    CardId ="13014",
                    Name="Eskel",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    Flavor = "白狼，我只是个普通猎魔人。我不猎龙，不跟国王称兄道弟，也不和女术士纠缠……",
                    Info = "Summon Vesemir and Lambert. ",
                    CardArtsId = "11220200",
                }
            },
            {
                "13015",//欧吉尔德·伊佛瑞克
                new GwentCard()
                {
                    CardId ="13015",
                    Name="Olgierd von Everec",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Redania,Categorie.Cursed},
                    Flavor = "至少你知道我的头不好砍了。",
                    Info = "Deathwish: Resurrect this unit on a random row",
                    CardArtsId = "11220700",
                }
            },
            {
                "13002",//乞丐王
                new GwentCard()
                {
                    CardId ="13002",
                    Name="Francis Bedlam",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support},
                    Flavor = "要是我缺鼻子或者断手了，那显然，乞丐王接受这两种付款方式。",
                    Info = "If losing, Strengthen self up to a maximum of 15 until scores are tied",
                    CardArtsId = "11221300",
                }
            },
            {
                "13016",//操作者
                new GwentCard()
                {
                    CardId ="13016",
                    Name="Operator",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "时空在我们面前瓦解，也在我们身后膨胀，这就是穿越。",
                    Info = "Single-Use. Truce: Make a default copy of a Bronze unit in your hand for both players.",
                    CardArtsId = "11220800",
                }
            },
            {
                "13017",//兰伯特
                new GwentCard()
                {
                    CardId ="13017",
                    Name="Lambert",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    Flavor = "这样的沟通方式才对路嘛！",
                    Info = "Summon Eskel and Vesemir. ",
                    CardArtsId = "11220400",
                }
            },
            {
                "13018",//德鲁伊控天者
                new GwentCard()
                {
                    CardId ="13018",
                    Name="Vaedermakar",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "控天者德鲁伊能操控各种元素之力，让狂风暴雨化为绕指柔风，降下毁天灭地的雹暴，还能拖雷掣电让敌军灰飞烟灭……所以我给你个忠告：面对他，一定要毕恭毕敬。",
                    Info = "Spawn Biting Frost, Impenetrable Fog or Alzur's Thunder",
                    CardArtsId = "11320800",
                }
            },
            {
                "13001",//萝卜
                new GwentCard()
                {
                    CardId ="13001",
                    Name="Roach",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    Flavor = "杰洛特，我们得来场人马间的对话。恕我直言，你的骑术……真的有待提高，伙计。",
                    Info = "Whenever you play a Gold unit from your hand, Summon this unit",
                    CardArtsId = "11221000",
                }
            },
            {
                "13019",//爱丽丝·伊佛瑞克
                new GwentCard()
                {
                    CardId ="13019",
                    Name="Iris von Everec",
                    Strength=3,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Redania,Categorie.Cursed},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "我的回忆所剩无几……但每次想到我的玫瑰，记忆便会涌现。",
                    Info = "Spying. Deathwish: Boost 5 random units on the opposite side by 5.",
                    CardArtsId = "11221500",
                }
            },
            {
                "13020",//多瑞加雷
                new GwentCard()
                {
                    CardId ="13020",
                    Name="Dorregaray of Vole",
                    Strength=1,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "和猎魔人一样，多瑞加雷也热爱同怪物打交道。不过他有自己的一套分类系统。别人眼里面目可憎的食尸生物、食人魔，在他看来都特别可爱。",
                    Info = "Create any Bronze or Silver Beast or Draconid. ",
                    CardArtsId = "20008700",
                }
            },
            {
                "13021",//杜度
                new GwentCard()
                {
                    CardId ="13021",
                    Name="Dudu",
                    Strength=1,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Relict},
                    Flavor = "拟态怪有很多别名：易形怪、二重身、模仿怪……变形怪。",
                    Info = "Deploy: Choose an Enemy and copy its Power. ",
                    CardArtsId = "11220100",
                }
            },
            {
                "13022",//获奖奶牛
                new GwentCard()
                {
                    CardId ="13022",
                    Name="Prize-Winning Cow",
                    Strength=1,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "哞～～～",
                    Info = "Deathwish: Spawn a Chort",
                    CardArtsId = "11220900",
                }
            },
            {
                "13023",//黑血
                new GwentCard()
                {
                    CardId ="13023",
                    Name="Black Blood",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "吸血鬼们纷纷表示：使用这种药水有违体育精神。",
                    Info = "Choose One: Create a Bronze Necrophage or Vampire and boost it by 2; or Destroy a Bronze or Silver Necrophage or Vampire. ",
                    CardArtsId = "20169700",
                }
            },
            {
                "13024",//阿尔祖召唤术
                new GwentCard()
                {
                    CardId ="13024",
                    Name="Alzur's Double–Cross",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "阿尔祖创造的一些怪物仍在四处游荡，其中便有令人胆寒的巨蜈蚣——它杀掉了创造自己的法师，摧毁了半个马里波，然后逃进了河谷地区幽暗的森林。",
                    Info = "Boost the Highest Bronze or Silver Unit in your Deck by 2 and play it.",
                    CardArtsId = "11320900",
                }
            },
            {
                "13025",//化器封形
                new GwentCard()
                {
                    CardId ="13025",
                    Name="Artefact Compression",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "雕像瞬间爆开，颤动不已，犹如一道在地上爬行的烟雾，变换着自己的形状。道道光芒里，有东西上下纷飞，不断成形。片刻之后，魔法圈的正中间突然现出了一道人影。",
                    Info = "Transform a Bronze or Silver unit into a Jade Figurine. ",
                    CardArtsId = "20005300",
                }
            },
            {
                "13026",//贝克尔的黑暗之镜
                new GwentCard()
                {
                    CardId ="13026",
                    Name="Bekker's Dark Mirror",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "当你凝视深渊的时候，深渊也在凝视着你。",
                    Info = "Transfer up to 10 power between the Highest and Lowest unit.",
                    CardArtsId = "11331500",
                }
            },
            {
                "13027",//指挥号角
                new GwentCard()
                {
                    CardId ="13027",
                    Name="Commander's Horn",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "士气加一分，听力减三分。",
                    Info = "Boost 5 adjacent units by 3.",
                    CardArtsId = "11320700",
                }
            },
            {
                "13028",//诱饵
                new GwentCard()
                {
                    CardId ="13028",
                    Name="Decoy",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "如果拿来应急，假人也是不错的挡箭牌。",
                    Info = "Return a Bronze or Silver Ally to your Hand, Boost it by 3 and play it. ",
                    CardArtsId = "11320100",
                }
            },
            {
                "13029",//阻魔金炸弹
                new GwentCard()
                {
                    CardId ="13029",
                    Name="Dimeritium Bomb",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special},
                    Flavor = "女巫猎人必备。无声的闪光过后，最强大的法师也得乖乖就擒。",
                    Info = "Reset all boosted units on a row.",
                    CardArtsId = "11320500",
                }
            },
            {
                "13030",//蝎尾狮毒液
                new GwentCard()
                {
                    CardId ="13030",
                    Name="Manticore Venom",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Organic},
                    Flavor = "剧毒致命的速度快得让你连尼弗迦德皇帝的头衔都念不完。",
                    Info = "Damage a unit by 13. ",
                    CardArtsId = "11330600",
                }
            },
            {
                "13031",//行军令
                new GwentCard()
                {
                    CardId ="13031",
                    Name="Marching Orders",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "我们只不过是老头子们的棋子，为他们腐朽的妄想命丧沙场……",
                    Info = "Boost the Lowest Bronze or Silver Unit in your Deck by 2 and play it. ",
                    CardArtsId = "20001900",
                }
            },
            {
                "13032",//特莉丝雹暴术
                new GwentCard()
                {
                    CardId ="13032",
                    Name="Merigold's Hailstorm",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "天空突然暗了下来，云层笼罩在城镇上空。愁云惨淡之中，寒风呼啸而过。“哦，我的天哪，”叶奈法吸了口气，“看起来你成功了……”",
                    Info = "Halve the power of all Bronze and Silver units on a row.",
                    CardArtsId = "11320200",
                }
            },
            {
                "13033",//死灵术
                new GwentCard()
                {
                    CardId ="13033",
                    Name="Necromancy",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "无论怎样……我们都有办法叫你开口。",
                    Info = "Banish a Bronze or Silver unit from either graveyard, then boost an ally by its power.",
                    CardArtsId = "20002000",
                }
            },
            {
                "13034",//烧灼
                new GwentCard()
                {
                    CardId ="13034",
                    Name="Scorch",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "杰洛特退了一步。他见过不少被烧弹击中的人，更准确地说，他见过不少烧弹留下的残骸。",
                    Info = "Destroy all the Highest Units.",
                    CardArtsId = "11330900",
                }
            },
            {
                "13035",//史凯利格风暴
                new GwentCard()
                {
                    CardId ="13035",
                    Name="Skellige Storm",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Hazard},
                    Flavor = "这可不是普通风暴，这是天神之怒。",
                    Info = "Apply a Hazard to an enemy row that deals 2, 1 and 1 damage to the leftmost units on the row on turn start.",
                    CardArtsId = "11320300",
                }
            },
            {
                "13036",//召唤法阵
                new GwentCard()
                {
                    CardId ="13036",
                    Name="Summoning Circle",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "在我们所处的位面之外，还存在着许许多多的位面……只要掌握了正确的知识，就可以接触并召唤远超人类想象的生物。",
                    Info = "Spawn a default copy of the last Bronze or Silver non-Agent unit placed on the board.",
                    CardArtsId = "20002200",
                }
            },
            {
                "13037",//最后的愿望
                new GwentCard()
                {
                    CardId ="13037",
                    Name="The Last Wish",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "亲爱的先生们，一只气灵三个愿望，随后它们就会跑回自己的界域去。",
                    Info = "Draw your top 2 cards. Play 1 and shuffle the other back. ",
                    CardArtsId = "11310200",
                }
            },
            {
                "13038",//白霜
                new GwentCard()
                {
                    CardId ="13038",
                    Name="White Frost",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Hazard},
                    Flavor = "见证“泰德戴尔瑞”——终焉纪元——这被白霜摧毀的世界吧！",
                    Info = "Apply a Frost Hazard to 2 adjacent opposing rows. Frost Hazard: Every turn, at the start of your turn, Damage the Lowest Unit on the row by 2.",
                    CardArtsId = "11320600",
                }
            },
            {
                "13039",//过期的麦酒
                new GwentCard()
                {
                    CardId ="13039",
                    Name="Tainted Ale",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special},
                    Flavor = "这酒原本就是绿色的吗……？",
                    Info = "Deal 6 damage to the Highest enemy on each row.",
                    CardArtsId = "20023200",
                }
            },
            {
                "13040",//曼德拉草
                new GwentCard()
                {
                    CardId ="13040",
                    Name="Mandrake",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Organic},
                    Flavor = "衮衮诸公，瞠目环立，不肯相信这高贵的发现。有的在谈曼陀罗花，有的又说是在用黑犬。",
                    Info = "Choose One: Heal a unit and Strengthen it by 6; or Reset a unit and Weaken it by 6.",
                    CardArtsId = "20022300",
                }
            },
            {
                "13041",//贝克尔的岩崩术
                new GwentCard()
                {
                    CardId ="13041",
                    Name="Bekker's Rockslide",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "只要一块小石子，我们就完蛋了。",
                    Info = "Deal 2 damage to up to 10 random enemies. ",
                    CardArtsId = "20163400",
                }
            },
            {
                "13042",//豪猎而归
                new GwentCard()
                {
                    CardId ="13042",
                    Name="Glorious Hunt",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "以诸神的名义，猎魔人，你把这鬼东西拿来干嘛？！“我要那畜生的脑袋！”这句话不过是打个比方！",
                    Info = "If losing, Spawn an Imperial Manticore. If winning or tied, Spawn Manticore Venom.",
                    CardArtsId = "20153200",
                }
            },
            {
                "13043",//龙之梦
                new GwentCard()
                {
                    CardId ="13043",
                    Name="Dragon's Dream",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "在瑟瑞卡尼亚，龙神崇拜体现在日常生活的各个方面。因此也难怪他们会以此为武器命名了。",
                    Info = "Apply a Hazard to an enemy row that will explode and deal 4 damage to all units when a different special card is played. Added to the game.",
                    CardArtsId = "20154800",
                }
            },
            {
                "13044",//军营
                new GwentCard()
                {
                    CardId ="13044",
                    Name="Garrison",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "咚咚咚，有人在家吗？",
                    Info = "Create a Bronze or Silver unit from your opponent's starting deck and boost it by 2. ",
                    CardArtsId = "20055500",
                }
            },
            {
                "14002",//战意激升
                new GwentCard()
                {
                    CardId ="14002",
                    Name="Adrenaline Rush",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Organic},
                    Flavor = "那野兽狂暴地扑来，眼中怒火熊熊，全然不顾疼痛和抵抗者的拼命反击。挡它者，唯有一死……",
                    Info = "Toggle a unit's Resilience status.",
                    CardArtsId = "11330700",
                }
            },
            {
                "14003",//阿尔祖落雷术
                new GwentCard()
                {
                    CardId ="14003",
                    Name="Alzur's Thunder",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "我们全然无法念诵“阿尔祖落雷术”这样深奥复杂的咒语。据说，阿尔祖声如狩猎号角，言若讲演名家。",
                    Info = "Deal 9 damage. ",
                    CardArtsId = "11330100",
                }
            },
            {
                "14004",//蟹蜘蛛毒液
                new GwentCard()
                {
                    CardId ="14004",
                    Name="Arachas Venom",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Organic},
                    Flavor = "“若不慎接触眼部，请立即用冷水冲洗，然后起草遗嘱。”",
                    Info = "Damage 3 adjacent Units by 4. ",
                    CardArtsId = "6010200",
                }
            },
            {
                "14005",//刺骨冰霜
                new GwentCard()
                {
                    CardId ="14005",
                    Name="Biting Frost",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Hazard},
                    Flavor = "寒霜凛冽的好处就是尸体不会腐烂得那么快。",
                    Info = "Apply a Hazard to an enemy row that deals 2 damage to the Lowest unit on turn start. ",
                    CardArtsId = "11330200",
                }
            },
            {
                "14006",//惊悚咆哮
                new GwentCard()
                {
                    CardId ="14006",
                    Name="惊悚咆哮",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Organic},
                    Flavor = "起初我们碰上了一头熊……悲剧就从那时开始了。",
                    Info = "摧毁1个友军单位。 生成1头“熊”。",
                    CardArtsId = "15240600",
                }
            },
            {
                "14007",//阻魔金镣铐
                new GwentCard()
                {
                    CardId ="14007",
                    Name="Dimeritium Shackles",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "瑞达尼亚人将巫师的手腕拧到背后，给他戴上镣铐，并使劲晃了晃。特拉诺瓦叫喊挣扎，还弯下腰呕吐呻吟——杰洛特这才明白手铐的材质。",
                    Info = "Lock a unit. If an enemy, deal 4 damage to it.",
                    CardArtsId = "11331900",
                }
            },
            {
                "14008",//瘟疫
                new GwentCard()
                {
                    CardId ="14008",
                    Name="Epidemic",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special,Categorie.Organic},
                    Flavor = "瘟疫不仁，以万物为刍狗。",
                    Info = "Destroy all the Lowest units. ",
                    CardArtsId = "11330800",
                }
            },
            {
                "14009",//破晓
                new GwentCard()
                {
                    CardId ="14009",
                    Name="Clear Skies",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "太阳出来了，德洛米！太阳出来了！也许我们命不该绝……",
                    Info = "Choose One: Boost all damaged allies under Hazards by 2 and clear all Hazards from your side; or Play a random Bronze unit from your deck.",
                    CardArtsId = "11330300",
                }
            },
            {
                "14010",//佩特里的魔药
                new GwentCard()
                {
                    CardId ="14010",
                    Name="Petri's Philter",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "但在那一夜，月色如血。",
                    Info = "Boost up to 6 random allies by 2.",
                    CardArtsId = "11332100",
                }
            },
            {
                "14011",//蔽日浓雾
                new GwentCard()
                {
                    CardId ="14011",
                    Name="Impenetrable Fog",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Hazard},
                    Flavor = "优秀指挥官的福音……拙劣指挥官的噩梦。",
                    Info = "Apply a Hazard to an enemy row that deals 2 damage to the Highest unit on turn start. ",
                    CardArtsId = "11330500",
                }
            },
            {
                "14012",//撕裂
                new GwentCard()
                {
                    CardId ="14012",
                    Name="Lacerate",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Organic},
                    Flavor = "那绝对是你前所未见的恐怖场景——可怜的家伙……躺倒在地，任凭怪兽肆意摆布。",
                    Info = "Damage all Units on a row by 3.",
                    CardArtsId = "15330100",
                }
            },
            {
                "14013",//致幻菌菇
                new GwentCard()
                {
                    CardId ="14013",
                    Name="Spores",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Organic},
                    Flavor = "Carried by the wind across the Continent… Sowing madness and blight where they fall. ",
                    Info = "Choose one: reset a unit and strengthen it by 3; or reset a unit and weaken it by 3.",
                    CardArtsId = "11340300",
                }
            },
            {
                "14014",//复仇
                new GwentCard()
                {
                    CardId ="14014",
                    Name="Shrike",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "虽对人类致命，但药水的毒性对猎魔人来说却微乎其微。",
                    Info = "Damage up to 6 random Enemies by 2. ",
                    CardArtsId = "20000900",
                }
            },
            {
                "14015",//翼手龙鳞甲盾牌
                new GwentCard()
                {
                    CardId ="14015",
                    Name="Wyvern Scale Shield",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Item},
                    Flavor = "比一般的盾牌要坚固，而且更时髦。",
                    Info = "Boost a unit by the base power of a Bronze or Silver unit in your hand. ",
                    CardArtsId = "20154200",
                }
            },
            {
                "14016",//斯丹莫福德的山崩术
                new GwentCard()
                {
                    CardId ="14016",
                    Name="Stammelford's Tremors",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "巫师斯丹莫福德曾将一座挡住他高塔视线的大山移走。传言他有这等移山之力，全因得到了一只地灵——也就是土界灵——的服务。",
                    Info = "Deal 1 damage to all enemies.",
                    CardArtsId = "11320400",
                }
            },
            {
                "14017",//燕子
                new GwentCard()
                {
                    CardId ="14017",
                    Name="Swallow",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "这种药水能加速伤口的结痂和痊愈，而它之所以叫做“燕子”，因为雨燕是春天与希望的象征。",
                    Info = "Boost a unit by 10.",
                    CardArtsId = "11331000",
                }
            },
            {
                "14018",//雷霆
                new GwentCard()
                {
                    CardId ="14018",
                    Name="Thunderbolt",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "猎魔人脸色陡变……平日的风度荡然无存，令人毛骨悚然。",
                    Info = "Boost 3 adjacent units by 3 and give them 2 Armor.",
                    CardArtsId = "11331100",
                }
            },
            {
                "14019",//倾盆大雨
                new GwentCard()
                {
                    CardId ="14019",
                    Name="Torrential Rain",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Hazard},
                    Flavor = "这儿连雨都带股尿骚味。",
                    Info = "Apply a Hazard to an enemy row that deals 1 damage to 2 random units on turn start. ",
                    CardArtsId = "11331200",
                }
            },
            {
                "14020",//玛哈坎麦酒
                new GwentCard()
                {
                    CardId ="14020",
                    Name="Mahakam Ale",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special},
                    Flavor = "无可争议是矮人们对世界文化所作出的最杰出贡献。",
                    Info = "Deploy: Boost a random Ally on each row by 4.",
                    CardArtsId = "20044800",
                }
            },
            {
                "14021",//乌鸦眼
                new GwentCard()
                {
                    CardId ="14021",
                    Name="Crow's Eye",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Organic},
                    Flavor = "某个大名鼎鼎的海盗曾经沉迷于这种迷人的药草，进而得名“乌鸦眼”。然而对于海盗故事十分讲究的人而言，他的这一段传说实在太不像话，自然也就没能流传下来。",
                    Info = "Deal 4 damage to the Highest enemy on each row. Deal 1 extra damage for each copy of this card in your graveyard. ",
                    CardArtsId = "20022400",
                }
            },
            {
                "14022",//变形怪
                new GwentCard()
                {
                    CardId ="14022",
                    Name="Doppler",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special},
                    Flavor = "人类对变形怪深恶痛绝，觉得光是处刑还不够。因此一旦落入人类手中，他们自然就凶多吉少了……",
                    Info = "Spawn a random Bronze unit from your faction.",
                    CardArtsId = "20163100",
                }
            },
            {
                "14023",//乱石飞舞
                new GwentCard()
                {
                    CardId ="14023",
                    Name="Rock Barrage",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special},
                    Flavor = "有一天等你老了，也会难逃被石头砸中的厄运。",
                    Info = "Deal 7 damage to an enemy and move it to the row above. If the row is full, destroy the enemy instead.",
                    CardArtsId = "20164700",
                }
            },
            {
                "14024",//精良的长矛
                new GwentCard()
                {
                    CardId ="14024",
                    Name="Mastercrafted Spear",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Item},
                    Flavor = "把长矛立起来，懒虫！一匹马都不能放过去！",
                    Info = "Deal damage equal to the base power of a Bronze or Silver unit in your hand.",
                    CardArtsId = "20150200",
                }
            },
            {
                "14001",//侦察
                new GwentCard()
                {
                    CardId ="14001",
                    Name="Scout",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "如果斥候没有回来，我们就掉头。乡下的人说这些树林里全是松鼠。我指的可不是啃松果的那种。",
                    Info = "Look at 2 Bronze units in your deck, then play 1",
                    CardArtsId = "11340200",
                }
            },
            {
                "14025",//致命菌菇
                new GwentCard()
                {
                    CardId ="14025",
                    Name="Spores",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Organic},
                    Flavor = "吃够量，世界就会变个样……",
                    Info = "Deal 2 damage to all units on a row and clear a Boon from it.",
                    CardArtsId = "11340400",
                }
            },
            {
                "14026",//黄金酒沫
                new GwentCard()
                {
                    CardId ="14026",
                    Name="Golden Froth",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Boon},
                    Flavor = "闻到了吗？那是幸福的味道。",
                    Info = "Apply a Boon to an allied row that boosts 2 random units by 1 on turn start.",
                    CardArtsId = "20174900",
                }
            },
            {
                "14027",//农民民兵
                new GwentCard()
                {
                    CardId ="14027",
                    Name="Peasant Militia",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "瞧，我们是民兵。我们保卫和平",
                    Info = "Spawn 3 Peasants on a row.",
                    CardArtsId = "20167700",
                }
            },
            {
                "15001",//店店：骑士
                new GwentCard()
                {
                    CardId ="15001",
                    Name="Shupe: Knight",
                    Strength=12,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Ogroid,Categorie.Token},
                    Flavor = "其他巨魔都觉得他是个异类，毕竟在巨魔们看来，谁会喜欢彩色纸片胜过喜欢石头呢？",
                    Info = "Send Shupe to the Imperial Court Military Academy. Strengthen yourself to 25; Gain resilience; Dual a unit; Reset a unit; Destroy all enemy units with power less than 4 points.",
                    CardArtsId = "20173700",
                }
            },
            {
                "15002",//店店：猎人
                new GwentCard()
                {
                    CardId ="15002",
                    Name="Shupe: Hunter",
                    Strength=8,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Ogroid,Categorie.Token},
                    Flavor = "其他巨魔都觉得他是个异类，毕竟在巨魔们看来，谁会喜欢彩色纸片胜过喜欢石头呢？",
                    Info = "Send Shupe to the forests of Dol Blathanna. Deal 15 damage; Deal 2 damage to a random enemy 8 times; Replay a bronze or silver unit and give it 5 points; Play a bronze or silver unit from your deck; Remove hazards on your side of the board a give boost your units by 1",
                    CardArtsId = "20173100",
                }
            },
            {
                "15003",//店店：法师
                new GwentCard()
                {
                    CardId ="15003",
                    Name="Shupe: Mage",
                    Strength=4,
                    Group=Group.Gold,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Ogroid,Categorie.Token},
                    Flavor = "其他巨魔都觉得他是个异类，毕竟在巨魔们看来，谁会喜欢彩色纸片胜过喜欢石头呢？",
                    Info = "Send Shupe to the Ban Ard Academy. Draw 1 card; Charm a random enemy unit; Spawn a random hazard on all opponent's rows; Deal 10 damage to an enemy unit, than 5 damage to adjacent units; Play a special card from your deck.",
                    CardArtsId = "20172500",
                }
            },
            {
                "15004",//梦魇独角兽
                new GwentCard()
                {
                    CardId ="15004",
                    Name="Chironex",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Token},
                    Flavor = "“天呐，那根本不是独角兽！那是……”——著名奇珍收藏家崴尔玛的遗言。",
                    Info = "Remove 2 strength from all units on the battlefiel",
                    CardArtsId = "11240200",
                }
            },
            {
                "15005",//翡翠人偶
                new GwentCard()
                {
                    CardId ="15005",
                    Name="???",
                    Strength=2,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Token},
                    Flavor = "雕像瞬间爆开，颤动不已，犹如一道在地上爬行的烟雾，变换着自己的形状。道道光芒里，有东西上下纷飞，不断成形。片刻之后，魔法圈的正中间突然现出了一道人影。",
                    Info = "No Ability.",
                    CardArtsId = "20005300",
                }
            },
            {
                "15006",//话篓子：捣蛋鬼
                new GwentCard()
                {
                    CardId ="15006",
                    Name="Duda: Agitator",
                    Strength=1,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Token},
                    Flavor = "卓尔坦的鹦鹉拥有一项超凡能力：能逼疯所有与它相处的人，包括卓尔坦本人。",
                    Info = " Deal 2 damage to 2 adjacent units.",
                    CardArtsId = "11240400",
                }
            },
            {
                "15007",//话篓子：伙伴
                new GwentCard()
                {
                    CardId ="15007",
                    Name="Duda: Companion",
                    Strength=1,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Token},
                    Flavor = "它会说一百个词，其中八十个是脏话，剩下的是脏话的语气词。",
                    Info = "Boost 2 adjacent units by 2",
                    CardArtsId = "11240300",
                }
            },
            {
                "15008",//独角兽
                new GwentCard()
                {
                    CardId ="15008",
                    Name="Unicorn",
                    Strength=1,
                    Group=Group.Silver,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Token},
                    Flavor = "都说独角兽喜欢幼莲。但如今，幼莲跟独角兽一样稀缺，这理论也就难以证明了。",
                    Info = "Add 2 strength to all units on the battlefield",
                    CardArtsId = "11240100",
                }
            },
            {
                "15009",//羊角魔
                new GwentCard()
                {
                    CardId ="15009",
                    Name="Chort",
                    Strength=14,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Relict,Categorie.Token},
                    Flavor = "牛牛防卫队的一员。永远忠诚！",
                    Info = "No Ability.",
                    CardArtsId = "20032000",
                }
            },
            {
                "15010",//熊
                new GwentCard()
                {
                    CardId ="15010",
                    Name="Elder Bear",
                    Strength=11,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Cursed},
                    Flavor = "去猎熊吧！去抓上一只——这、这只也太大了吧！快跑！！",
                    Info = "No Ability.",
                    CardArtsId = "15240600",
                }
            },
            {
                "15011",//农民
                new GwentCard()
                {
                    CardId ="15011",
                    Name="Peasant",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Doomed},
                    Flavor = "瞧，我们是民兵。我们保卫和平",
                    Info = "No Ability.",
                    CardArtsId = "20167700",
                }
            },
            {
                "15012",//牛
                new GwentCard()
                {
                    CardId ="15012",
                    Name="Cow",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Token},
                    Flavor = "在鲍克兰，什么东西都比其它地方的要棒：酒更甜美，牛儿更肥，而姑娘们则更加动人。",
                    Info = "No Ability.",
                    CardArtsId = "20051700",
                }
            },
            {
                "15013",//晴空
                new GwentCard()
                {
                    CardId ="15013",
                    Name="Clear Skies",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special,Categorie.Token},
                    Flavor = "太阳出来了，德洛米！太阳出来了！也许我们命不该绝……",
                    Info = "Boost all damaged allies under Hazards by 2 and clear all Hazards from your side",
                    CardArtsId = "11330300",
                }
            },
            {
                "15014",//重整
                new GwentCard()
                {
                    CardId ="15014",
                    Name="Rally",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Neutral,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special,Categorie.Token},
                    Flavor = "太阳出来了，德洛米！太阳出来了！也许我们命不该绝……",
                    Info = "Play a random Bronze unit from your deck",
                    CardArtsId = "11330300",
                }
            },
            {
                "21001",//达冈
                new GwentCard()
                {
                    CardId ="21001",
                    Name="Dagon",
                    Strength=8,
                    Group=Group.Leader,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Vodyanoi},
                    Flavor = "永世长眠者未必永恒死亡，在奇妙的时代死亡亦将消逝。",
                    Info = "Spawn Fog or Rain",
                    CardArtsId = "13110300",
                }
            },
            {
                "21002",//蟹蜘蛛女王
                new GwentCard()
                {
                    CardId ="21002",
                    Name="Arachas Queen",
                    Strength=7,
                    Group=Group.Leader,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Insectoid},
                    Flavor = "她的孩子们完美继承了她的美貌。",
                    Info = "Consume 3 allies and boost self by their power. Immune.",
                    CardArtsId = "20174300",
                }
            },
            {
                "21003",//呢喃山丘
                new GwentCard()
                {
                    CardId ="21003",
                    Name="Whispering Hillock",
                    Strength=6,
                    Group=Group.Leader,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Relict},
                    Flavor = "它会在其它我们所无法触及的地方再次崛起。厄运会再次降临。",
                    Info = "Create a Bronze or Silver Organic card. ",
                    CardArtsId = "20158700",
                }
            },
            {
                "21004",//艾瑞汀
                new GwentCard()
                {
                    CardId ="21004",
                    Name="Eredin Bréacc Glas",
                    Strength=5,
                    Group=Group.Leader,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.WildHunt,Categorie.Leader},
                    Flavor = "留点尊严吧，你的结局已然注定。",
                    Info = "Spawn a Bronze Wild Hunt unit.",
                    CardArtsId = "13110100",
                }
            },
            {
                "21005",//暗影长者
                new GwentCard()
                {
                    CardId ="21005",
                    Name="Unseen Elder",
                    Strength=5,
                    Group=Group.Leader,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Vampire},
                    Flavor = "没有谁知道暗影长者的真实年龄，连高阶吸血鬼们也不知情。他们唯一清楚的是，无论如何也不能违背他的意愿。",
                    Info = "Drain a unit by half. ",
                    CardArtsId = "20005500",
                }
            },
            {
                "22001",//老矛头：昏睡
                new GwentCard()
                {
                    CardId ="22001",
                    Name="Old Speartip: Asleep",
                    Strength=12,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Ogroid},
                    Flavor = "别吵！",
                    Info = "Strengthen all your other Ogroids in hand, deck, and on board by 1. ",
                    CardArtsId = "13221800",
                }
            },
            {
                "22002",//战灵
                new GwentCard()
                {
                    CardId ="22002",
                    Name="Draug",
                    Strength=10,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Officer},
                    Flavor = "有些人就是不服输，死了还要继续打。",
                    Info = "Resurrect units as 1-power Draugirs until you fill this unit's row.",
                    CardArtsId = "13210100",
                }
            },
            {
                "22003",//老矛头
                new GwentCard()
                {
                    CardId ="22003",
                    Name="Old Speartip",
                    Strength=10,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Ogroid},
                    Flavor = "哦，你现在可有大麻烦了......",
                    Info = "Deal 2 damage to up to 5 enemies on the opposite row.",
                    CardArtsId = "13240800",
                }
            },
            {
                "22004",//卡兰希尔
                new GwentCard()
                {
                    CardId ="22004",
                    Name="Caranthir Ar-Feiniel",
                    Strength=9,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.WildHunt,Categorie.Mage,Categorie.Officer},
                    Flavor = "宠儿偏偏堕落成逆子。",
                    Info = "Move an enemy to the opposite row and apply Biting Frost to it. ",
                    CardArtsId = "13210400",
                }
            },
            {
                "22005",//伊勒瑞斯
                new GwentCard()
                {
                    CardId ="22005",
                    Name="Imlerith",
                    Strength=9,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.WildHunt,Categorie.Officer},
                    Flavor = "叫他们有来无回！",
                    Info = "Deploy: Damage an Enemy by 4. If the Enemy is under a Frost Hazard, Damage it by 8 instead. ",
                    CardArtsId = "13210200",
                }
            },
            {
                "22006",//呢喃婆：贡品
                new GwentCard()
                {
                    CardId ="22006",
                    Name="Whispess: Tribute",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Relict},
                    Flavor = "我将是你最美……与最后的体验。",
                    Info = "Play a Bronze or Silver Organic card from your deck. ",
                    CardArtsId = "20022000",
                }
            },
            {
                "22007",//巨章鱼怪
                new GwentCard()
                {
                    CardId ="22007",
                    Name="Kayran",
                    Strength=5,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Insectoid},
                    Flavor = "对付巨章鱼怪？简单。找出你最好的剑——卖了它，雇个猎魔人。",
                    Info = "Consume a unit with 7 power or less and boost self by its power. ",
                    CardArtsId = "13210700",
                }
            },
            {
                "22008",//林妖
                new GwentCard()
                {
                    CardId ="22008",
                    Name="Woodland Spirit",
                    Strength=5,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Relict},
                    Flavor = "即便全村人都饿肚子，我们也绝不去这片树林打猎。",
                    Info = "Spawn 3 Wolves and apply a Fog to the opposite row.",
                    CardArtsId = "13210300",
                }
            },
            {
                "22009",//伊勒瑞斯：临终之日
                new GwentCard()
                {
                    CardId ="22009",
                    Name="Imlerith: Sabbath",
                    Strength=5,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.WildHunt,Categorie.Officer},
                    Flavor = "老巫妪说过你会来。她们在水面上预见了你的到来。",
                    Info = "Every turn, Duel the Highest enemy on turn end. If this unit survives, Heal it by 2 and give it 2 Armor. 2 Armor.",
                    CardArtsId = "20178100",
                }
            },
            {
                "22010",//看门人
                new GwentCard()
                {
                    CardId ="22010",
                    Name="Caretaker",
                    Strength=4,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Doomed,Categorie.Relict},
                    Flavor = "大千世界，无奇不有，远超古圣今贤之想象。",
                    Info = "Resurrect a Bronze or Silver unit from your opponent's graveyard.",
                    CardArtsId = "13210600",
                }
            },
            {
                "22011",//米卢娜
                new GwentCard()
                {
                    CardId ="22011",
                    Name="Miruna",
                    Strength=4,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    Countdown=2,
                    IsCountdown = true,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    Flavor = "打什么仗嘛？明明有更多好办法消耗过剩的精力……",
                    Info = "After 2 turns, Charm the Highest enemy on the opposite row on turn start. ",
                    CardArtsId = "13210800",
                }
            },
            {
                "22012",//织婆：咒文
                new GwentCard()
                {
                    CardId ="22012",
                    Name="Weavess: Incantation",
                    Strength=4,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Relict},
                    Flavor = "我能感受到你的痛苦和恐惧。",
                    Info = "Choose One: Strengthen allied Relicts by 2, wherever they are; or Play a Bronze or Silver Relict from your deck and Strengthen it by 2.",
                    CardArtsId = "20022200",
                }
            },
            {
                "22013",//盖尔
                new GwentCard()
                {
                    CardId ="22013",
                    Name="Ge'els",
                    Strength=1,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.WildHunt,Categorie.Officer},
                    Flavor = "画作传情，而非言词。",
                    Info = "Deploy: Draw the top Gold card and top Silver card from your Deck. Play one and return the other to the top of your Deck. ",
                    CardArtsId = "13110200",
                }
            },
            {
                "22014",//煮婆：仪式
                new GwentCard()
                {
                    CardId ="22014",
                    Name="Brewess: Ritual",
                    Strength=1,
                    Group=Group.Gold,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Doomed,Categorie.Relict},
                    Flavor = "切烂……剁碎……然后熬出……一锅好汤。",
                    Info = "Resurrect 2 Bronze Deathwish units",
                    CardArtsId = "20022100",
                }
            },
            {
                "23001",//畏惧者
                new GwentCard()
                {
                    CardId ="23001",
                    Name="Frightener",
                    Strength=13,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Construct,Categorie.Agent},
                    Flavor = "“我到底做了什么？”法师被自己的创造物吓得大叫起来。",
                    Info = "Spying. Single-Use. Move an enemy to this unit's row and draw a card.",
                    CardArtsId = "13220400",
                }
            },
            {
                "23002",//帝国蝎尾狮
                new GwentCard()
                {
                    CardId ="23002",
                    Name="Imperial Manticore",
                    Strength=13,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    Flavor = "世界上最古老且致命的怪物之一。倘若是过去，遇到一只定会让我兴奋无比。但如今它只是我前进路上的绊脚石，而它的肉和滚烫的鲜血能帮我熬过这冰天雪地。",
                    Info = "No Ability.",
                    CardArtsId = "13220900",
                }
            },
            {
                "23003",//哥亚特
                new GwentCard()
                {
                    CardId ="23003",
                    Name="Golyat",
                    Strength=10,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Ogroid},
                    Flavor = "据说哥亚特曾经是一位闻名遐迩的骑士。只可惜，有一天他触怒了湖中仙女，被变成了一头怪物。",
                    Info = "Boost self by 7. Whenever this unit is damaged, deal 2 damage to self.",
                    CardArtsId = "20005200",
                }
            },
            {
                "23004",//煮婆
                new GwentCard()
                {
                    CardId ="23004",
                    Name="Brewess",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Relict},
                    Flavor = "切烂……剁碎……然后熬出……一锅好汤。",
                    Info = "Summon Whispess and Weavess",
                    CardArtsId = "13220700",
                }
            },
            {
                "23005",//伊夫利特
                new GwentCard()
                {
                    CardId ="23005",
                    Name="Colossal Ifrit",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Construct},
                    Flavor = "受不了热浪？那就没生路了。",
                    Info = "Spawn 3 Lesser Ifrits to the right of this unit. ",
                    CardArtsId = "13221000",
                }
            },
            {
                "23006",//卢恩
                new GwentCard()
                {
                    CardId ="23006",
                    Name="Ruehin",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Insectoid,Categorie.Cursed},
                    Flavor = "进入那片森林的人，没一个活着回来……",
                    Info = "Strengthen all your Insectoid and Cursed units by 1, wherever they are.",
                    CardArtsId = "4010200",
                }
            },
            {
                "23007",//织婆
                new GwentCard()
                {
                    CardId ="23007",
                    Name="Weavess",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Relict},
                    Flavor = "我能感受到你的痛苦和恐惧。",
                    Info = "Summon Brewess and Whispess.",
                    CardArtsId = "13220800",
                }
            },
            {
                "23008",//呢喃婆
                new GwentCard()
                {
                    CardId ="23008",
                    Name="Whispess",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Relict},
                    Flavor = "我将是你最美……与最后的体验。",
                    Info = "Summon Brewess and Weavess.",
                    CardArtsId = "13220600",
                }
            },
            {
                "23009",//约顿
                new GwentCard()
                {
                    CardId ="23009",
                    Name="Jotunn",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Ogroid},
                    Flavor = "在史凯利格的传说中，强大而恐怖的巨人之王约顿是群岛在上古时期的统治者。他最终死于汉姆多尔的剑下，但在弥留之际，他发誓要在终末之战时重返人间。",
                    Info = "Deploy: Move 3 Enemies to this row on their side and Damage them by 2. If that row is affected by Frost Hazard, Damage them by 3 instead.",
                    CardArtsId = "20021800",
                }
            },
            {
                "23010",//莫伍德
                new GwentCard()
                {
                    CardId ="23010",
                    Name="Morvudd",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Relict},
                    Flavor = "一种只在大史凯利格出没的珍稀鹿首魔品种。对食物异乎寻常的挑剔。",
                    Info = "Toggle a unit's Lock status. If it was an enemy, halve its power.",
                    CardArtsId = "13220500",
                }
            },
            {
                "23011",//尼斯里拉
                new GwentCard()
                {
                    CardId ="23011",
                    Name="Nithral",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.WildHunt,Categorie.Officer},
                    Flavor = "每个狂猎战士都要经过严格筛选，而只有最残暴、最凶狠的那些才能加入艾瑞汀的骑兵队。",
                    Info = "Deal 6 damage to an enemy. Increase damage by 1 for each Wild Hunt unit in your hand.",
                    CardArtsId = "13221400",
                }
            },
            {
                "23012",//蟾蜍王子
                new GwentCard()
                {
                    CardId ="23012",
                    Name="Toad Prince",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed},
                    Flavor = "又大又坏又丑，住在下水道里。",
                    Info = "Draw a unit, then Consume a unit in your hand and boost self by its power.",
                    CardArtsId = "13221600",
                }
            },
            {
                "23013",//吸血妖鸟
                new GwentCard()
                {
                    CardId ="23013",
                    Name="Adda: Striga",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Relict},
                    Flavor = "吸血妖鸟挺好的。当然，她会时不时地在谁的身上咬一口，但我们早就习惯了。",
                    Info = "Deal 8 damage to a non-Monster unit.",
                    CardArtsId = "20007300",
                }
            },
            {
                "23014",//吸血夜魔
                new GwentCard()
                {
                    CardId ="23014",
                    Name="Katakan",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Vampire},
                    Flavor = "天球交汇后，这些以鲜血为食的怪物便来到了我们的世界。",
                    Info = "Spawn Moonlight.",
                    CardArtsId = "13222000",
                }
            },
            {
                "23015",//欧兹瑞尔
                new GwentCard()
                {
                    CardId ="23015",
                    Name="Ozzrel",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Necrophage},
                    Flavor = "一些食腐生物袭击过人类后，便再也不满足于区区腐肉了……",
                    Info = "Consume a Bronze or Silver unit from either graveyard and boost by its power.",
                    CardArtsId = "20169800",
                }
            },
            {
                "23016",//阿巴亚
                new GwentCard()
                {
                    CardId ="23016",
                    Name="Abaya",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Necrophage},
                    Flavor = "丑东西我见得多了，海鳝、七鳃鳗、水滴鱼……但还没见过这么丑的！",
                    Info = "Spawn Rain, Clear Skies or Arachas Venom.",
                    CardArtsId = "13220300",
                }
            },
            {
                "23017",//莫恩塔特
                new GwentCard()
                {
                    CardId ="23017",
                    Name="Mourntart",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Necrophage},
                    Flavor = "大部分墓穴巫婆以墓穴中刨出来的尸体为食。但有些也会潜入小屋，偷走孩子，残害大人。因此基本上没人愿意和她们成为邻居。",
                    Info = "Consume all Bronze and Silver units in your graveyard and boost self by 1 for each.",
                    CardArtsId = "13220200",
                }
            },
            {
                "23018",//无骨者
                new GwentCard()
                {
                    CardId ="23018",
                    Name="Maerolorn",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Relict},
                    Flavor = "别怕阴影，该怕的是亮光。",
                    Info = "Play a Bronze Deathwish unit from your Deck.",
                    CardArtsId = "13240600",
                }
            },
            {
                "23019",//维尔金的女巨魔
                new GwentCard()
                {
                    CardId ="23019",
                    Name="She-Troll of Vergen",
                    Strength=1,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Ogroid},
                    Flavor = "着迷于精灵洋葱汤。",
                    Info = "Play a Bronze Deathwish unit from your deck, Consume it and boost self by its base power",
                    CardArtsId = "20048200",
                }
            },
            {
                "23020",//戴维娜符文石
                new GwentCard()
                {
                    CardId ="23020",
                    Name="Devana Runestone",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "我的剑实在是锋利，连纸都能裁开！",
                    Info = "Create a Bronze or Silver Monster card.",
                    CardArtsId = "20158400",
                }
            },
            {
                "23021",//怪物巢穴
                new GwentCard()
                {
                    CardId ="23021",
                    Name="Monster Nest",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Organic},
                    Flavor = "该死，这些怪物泛滥成灾……我们得找个猎魔人，不然大家都活不成。",
                    Info = "Spawn a Bronze Necrophage or Insectoid unit and boost it by 1.",
                    CardArtsId = "13330200",
                }
            },
            {
                "23022",//寄生虫
                new GwentCard()
                {
                    CardId ="23022",
                    Name="Parasite",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Organic},
                    Flavor = "确实引人注目。",
                    Info = "Choose One: Deal 12 damage to an enemy; or Boost an ally by 12.",
                    CardArtsId = "20153400",
                }
            },
            {
                "24001",//独眼巨人
                new GwentCard()
                {
                    CardId ="24001",
                    Name="Cyclops",
                    Strength=11,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Ogroid},
                    Flavor = "别盯着它的眼睛，他不喜欢那样……",
                    Info = "Destroy an ally and deal its power as damage.",
                    CardArtsId = "20003700",
                }
            },
            {
                "24002",//鹿首魔
                new GwentCard()
                {
                    CardId ="24002",
                    Name="Fiend",
                    Strength=11,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Relict},
                    Flavor = "鹿首魔长得有点像鹿，一只又大又邪恶的鹿。",
                    Info = "No Ability.",
                    CardArtsId = "11240500",
                }
            },
            {
                "24003",//远古小雾妖
                new GwentCard()
                {
                    CardId ="24003",
                    Name="Ancient Foglet",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Necrophage},
                    Flavor = "人类心中潜藏着许多原始的恐惧。对迷雾的恐惧更是根深蒂固……",
                    Info = "Boost by 1 if Fog is on the board on turn end. ",
                    CardArtsId = "13230200",
                }
            },
            {
                "24004",//大狮鹫
                new GwentCard()
                {
                    CardId ="24004",
                    Name="Archgriffin",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    Flavor = "大狮鹫也是狮鹫，只是更加凶悍。",
                    Info = "Clear Hazards on its row.",
                    CardArtsId = "13230700",
                }
            },
            {
                "24005",//狂猎骑士
                new GwentCard()
                {
                    CardId ="24005",
                    Name="Wild Hunt Rider",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.WildHunt,Categorie.Soldier},
                    Flavor = "首先映入眼帘的是头盔旁的两只水牛角，接着是牛角间的头冠，最后是面甲下白骨般的脸。",
                    Info = "Increase the damage dealt by Frost on the opposite row by 1. ",
                    CardArtsId = "13231010",
                }
            },
            {
                "24006",//守桥巨魔
                new GwentCard()
                {
                    CardId ="24006",
                    Name="Bridge Troll",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Ogroid},
                    Flavor = "桥桥？巨魔造，很久很久前。",
                    Info = "Move a Hazard on an enemy row to a different enemy row.",
                    CardArtsId = "20048100",
                }
            },
            {
                "24007",//狼人头领
                new GwentCard()
                {
                    CardId ="24007",
                    Name="Alpha Werewolf",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Cursed},
                    Flavor = "有人说，如果被狼人咬了，那么你就会被感染，也变成狼人。当然，猎魔人都知道这是胡说八道。只有强大的诅咒才能造成这种效果。",
                    Info = "Spawn a Wolf on either side on contact with Full Moon.",
                    CardArtsId = "20011400",
                }
            },
            {
                "24008",//狮鹫
                new GwentCard()
                {
                    CardId ="24008",
                    Name="狮鹫",
                    Strength=9,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    Flavor = "狮鹫喜欢玩弄自己的猎物，将其一点一点地活生生啄食吞咽。",
                    Info = "Deploy: Trigger the Deathwish of a Bronze Ally.",
                    CardArtsId = "13231200",
                }
            },
            {
                "24009",//孽鬼战士
                new GwentCard()
                {
                    CardId ="24009",
                    Name="Nekker Warrior",
                    Strength=9,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Ogroid},
                    Flavor = "各位小心，这座桥下有孽鬼出没。",
                    Info = "Choose a Bronze ally and add 2 copies of it to your deck.",
                    CardArtsId = "13221100",
                }
            },
            {
                "24010",//蟹蜘蛛巨兽
                new GwentCard()
                {
                    CardId ="24010",
                    Name="Arachas Behemoth",
                    Strength=8,
                    Countdown=4,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = true,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Insectoid},
                    Flavor = "看起来像螃蟹和蜘蛛的杂交……只是体型硕大无比。",
                    Info = "Whenever you Consume a unit, Spawn an Arachas Hatchling. Repeat up to 3 times.",
                    CardArtsId = "13220100",
                }
            },
            {
                "24011",//腐食魔
                new GwentCard()
                {
                    CardId ="24011",
                    Name="Rotfiend",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Necrophage},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "还没见到它们的踪影，恶臭就先远远地传过来了。",
                    Info = "Deathwish: Damage all units on the opposite row by 2.",
                    CardArtsId = "20029500",
                }
            },
            {
                "24012",//叉尾龙
                new GwentCard()
                {
                    CardId ="24012",
                    Name="Forktail",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Draconid},
                    Flavor = "要想印叉尾龙上钩，得这样做：在地里打一根桩子，上头绑一只山羊，然后赶紧钻到旁边的灌木丛里藏起来。",
                    Info = "Consume 2 allies and boost self by their power.",
                    CardArtsId = "20141500",
                }
            },
            {
                "24013",//巨棘魔树
                new GwentCard()
                {
                    CardId ="24013",
                    Name="Archespore",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "根据民间传说，它们会在亡者鲜血的浇灌下破土而出。因此在拥有黑暗过往的地方，它们长得特别茂盛。",
                    Info = "Move to a random row and deal 1 damage to a random enemy on turn start. Deathwish: Deal 4 damage to a random enemy.",
                    CardArtsId = "20003800",
                }
            },
            {
                "24014",//水鬼
                new GwentCard()
                {
                    CardId ="24014",
                    Name="Drowner",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Necrophage},
                    Flavor = "尽管猎魔人想多赚些金币，但杀水鬼这活儿只值一枚银币，或者三个铜板——不能再多了。",
                    Info = "Move an enemy to the opposite row and deal 2 damage to it. If that row is under a Hazard, deal 4 damage instead.",
                    CardArtsId = "13231400",
                }
            },
            {
                "24015",//狂猎长船
                new GwentCard()
                {
                    CardId ="24015",
                    Name="Wild Hunt Drakkar",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.WildHunt,Categorie.Machine},
                    Flavor = "鬼船纳吉尔法的船头劈开波浪，将海水破成两道。号角响彻天际，汉姆多尔站在燃烧的彩虹之上，迎接敌人的来犯。白霜降临，狂风和暴雨近在咫尺……",
                    Info = "Aura: Boost all Wild Hunt allies by 1",
                    CardArtsId = "20030100",
                }
            },
            {
                "24016",//狂猎战士
                new GwentCard()
                {
                    CardId ="24016",
                    Name="Wild Hunt Warrior",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.WildHunt,Categorie.Soldier},
                    Flavor = "白霜将至。",
                    Info = "Deal 3 damage to an enemy. If the enemy is destroyed or is under Frost, boost self by 2.",
                    CardArtsId = "13230900",
                }
            },
            {
                "24017",//狼人
                new GwentCard()
                {
                    CardId ="24017",
                    Name="Werewolf",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = true,
                    Countdown = 1,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Cursed},
                    Flavor = "有人说，如果被狼人咬了，那么你就会被感染，也变成狼人。当然，猎魔人都知道这是胡说八道。只有强大的诅咒才能造成这种效果。",
                    Info = "Boost by 7 on contact with Full Moon. Immune.",
                    CardArtsId = "20009900",
                }
            },
            {
                "24018",//赛尔伊诺鹰身女妖
                new GwentCard()
                {
                    CardId ="24018",
                    Name="Celaeno Harpy",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    Flavor = "一般的鹰身女妖以腐肉为食，赛尔伊诺鹰身女妖……则以梦境为食。",
                    Info = "Spawn 2 Harpy Eggs.",
                    CardArtsId = "13221700",
                }
            },
            {
                "24019",//石化鸡蛇
                new GwentCard()
                {
                    CardId ="24019",
                    Name="Cockatrice",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Draconid},
                    Flavor = "头部拥有超强的防抖能力，因此总能轻易命中目标的腰椎之间、左肾下面，或是主动脉。",
                    Info = "Reset a unit.",
                    CardArtsId = "20023300",
                }
            },
            {
                "24020",//地灵
                new GwentCard()
                {
                    CardId ="24020",
                    Name="D'ao",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Construct},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "怎么跟土元素打？別想了，跑吧，能跑多快跑多快。",
                    Info = "Deathwish: Spawn 2 Lesser D'ao.",
                    CardArtsId = "13221300",
                }
            },
            {
                "24021",//寒冰巨人
                new GwentCard()
                {
                    CardId ="24021",
                    Name="Ice Giant",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Ogroid},
                    Flavor = "我这辈子只当过一次逃兵，就是碰上寒冰巨人那次——我一点也没觉得丢人。",
                    Info = "If a Frost Hazard is anywhere on the Board, Boost self by 6.",
                    CardArtsId = "13221200",
                }
            },
            {
                "24022",//蜥蜴人战士
                new GwentCard()
                {
                    CardId ="24022",
                    Name="Vran Warrior",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    Countdown = 2,
                    IsDoomed = false,
                    IsCountdown = true,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Draconid},
                    Flavor = "他们静静地骑在马上，看起来很放松，但全副武装：宽头短矛、剑柄独特的剑、战斧以及锯齿长斧。",
                    Info = "Deploy: Consume the Unit to the right. Every 2 turns, at the start of your turn, Consume the Unit to the right.",
                    CardArtsId = "13230800",
                }
            },
            {
                "24023",//翼手龙
                new GwentCard()
                {
                    CardId ="24023",
                    Name="Wyvern",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Draconid},
                    Flavor = "想象一下在最可怕的噩梦中出现的长翅膀的蛇——翼手龙比这更可怕。",
                    Info = "Deal 5 damage.",
                    CardArtsId = "13230300",
                }
            },
            {
                "24024",//女蛇妖
                new GwentCard()
                {
                    CardId ="24024",
                    Name="Lamia",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    Flavor = "有个迷信的家伙用蜡堵住耳朵，结果什么也听不到，包括警告——他的船直接撞上了礁石。",
                    Info = "Deal 4 damage to an enemy. If the enemy is under Blood Moon, deal 7 damage instead.",
                    CardArtsId = "13240900",
                }
            },
            {
                "24025",//须岩怪
                new GwentCard()
                {
                    CardId ="24025",
                    Name="Barbegazi",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Insectoid},
                    Flavor = "岩洞中先前还和石头没什么两样的怪物，倏地瞪大眼睛，充满恶意地盯着他。",
                    Info = "Consume an ally and boost self by its power. Resilient. ",
                    CardArtsId = "20170100",
                }
            },
            {
                "24026",//蝙魔
                new GwentCard()
                {
                    CardId ="24026",
                    Name="Ekimmara",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Vampire},
                    Flavor = "谁能想到巨型蝙蝠也会喜欢俗艳的珠宝？",
                    Info = "Drain a unit by 3.",
                    CardArtsId = "13231300",
                }
            },
            {
                "24027",//猫人
                new GwentCard()
                {
                    CardId ="24027",
                    Name="Werecat",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Cursed},
                    Flavor = "他不喜欢你挠他的肚子。",
                    Info = "Deal 5 damage to an enemy, then deal 1 damage to all enemies under Blood Moon.",
                    CardArtsId = "20011300",
                }
            },
            {
                "24028",//小雾妖
                new GwentCard()
                {
                    CardId ="24028",
                    Name="Foglet",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Necrophage},
                    Flavor = "浓雾悄然弥漫时，小雾妖便会出没，来享用它们的受害者。",
                    Info = "Whenever you apply Fog to an enemy row, Summon a copy of this unit from your deck.",
                    CardArtsId = "13230100",
                }
            },
            {
                "24029",//食尸鬼
                new GwentCard()
                {
                    CardId ="24029",
                    Name="Ghoul",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Necrophage},
                    Flavor = "如果食尸鬼也是生死循环的一环……那这循环也太残酷了。",
                    Info = "Deploy: Consume a Bronze or Silver Unit from your Graveyard. ",
                    CardArtsId = "13230600",
                }
            },
            {
                "24030",//鹰身女妖
                new GwentCard()
                {
                    CardId ="24030",
                    Name="Harpy",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    Flavor = "鹰身女妖有很多种，每种都有窃盗癖。",
                    Info = "Summon a copy of this unit whenever you destroy an allied Beast.",
                    CardArtsId = "13231500",
                }
            },
            {
                "24031",//孽鬼
                new GwentCard()
                {
                    CardId ="24031",
                    Name="Nekker",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Ogroid},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "如果忽略它们会攻击人类的残酷事实，这些小家伙其实挺可爱的。",
                    Info = "Whenever you Consume a card, boost this unit by 1, wherever it is. Deathwish: Play a copy of this unit from your deck.",
                    CardArtsId = "13230500",
                }
            },
            {
                "24032",//狂猎之犬
                new GwentCard()
                {
                    CardId ="24032",
                    Name="Wild Hunt Hound",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.WildHunt,Categorie.Construct},
                    Flavor = "下令出动，放狗开战。",
                    Info = "Deploy: Play a Biting Frost card from your Deck.",
                    CardArtsId = "13240200",
                }
            },
            {
                "24033",//女海妖
                new GwentCard()
                {
                    CardId ="24033",
                    Name="Siren",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    Flavor = "传说她们会用诱人的歌声引水手们上钩……倒不如说，是她们身上一些更加诱人的地方迷住了水手。",
                    Info = "Play Moonlight from your deck.",
                    CardArtsId = "20011210",
                }
            },
            {
                "24034",//冰巨魔
                new GwentCard()
                {
                    CardId ="24034",
                    Name="Ice Troll",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Ogroid},
                    Flavor = "巨魔形形色色，身材、嗜好各有不同。不过它们的脑子都和一桶锈钉子差不了多少。",
                    Info = "Duel an enemy. If it is under Frost, deal double damage.",
                    CardArtsId = "20050200",
                }
            },
            {
                "24035",//蟹蜘蛛雄蛛
                new GwentCard()
                {
                    CardId ="24035",
                    Name="Arachas Drone",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Insectoid},
                    Flavor = "丑陋的外表即是警告，叫你“离远点”。",
                    Info = "Summon all copies of this unit.",
                    CardArtsId = "13230400",
                }
            },
            {
                "24036",//狂猎导航员
                new GwentCard()
                {
                    CardId ="24036",
                    Name="Wild Hunt Navigator",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.WildHunt,Categorie.Mage},
                    Flavor = "几百年来，阿瓦拉克一直试图通过回育之术重塑长者之血的基因——但由此抚育出的精灵孩子不过是萤火灯烛，全然无法与劳拉光辉耀眼的血统相提并论。",
                    Info = "Choose a non-Mage Wild Hunt ally and play a copy of it from your deck.",
                    CardArtsId = "20002600",
                }
            },
            {
                "24037",//飞蜥
                new GwentCard()
                {
                    CardId ="24037",
                    Name="Slyzard",
                    Strength=2,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Draconid},
                    Flavor = "不管多强壮的人，不管他的本领多么高强，都不可能在飞蜥尾巴的抽打、巨蝎的大螯、或是狮鹫的爪子下保住性命。",
                    Info = "Consume a different Bronze unit from your graveyard, then play a copy of it from your deck. ",
                    CardArtsId = "20138400",
                }
            },
            {
                "24038",//月光
                new GwentCard()
                {
                    CardId ="24038",
                    Name="Moonlight",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Hazard,Categorie.Boon},
                    Flavor = "满月的时候，梦魇便会从世界的各个角落匍匐而出。",
                    Info = "Choose One: Apply a Full Moon Boon; or Apply a Blood Moon Hazard.",
                    CardArtsId = "20006700",
                }
            },
            {
                "25001",//次级地灵
                new GwentCard()
                {
                    CardId ="25001",
                    Name="Lesser D'ao",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Construct,Categorie.Token},
                    Flavor = "它很容易被误认作岩石，许多糊涂巨魔已痛彻心扉地领悟到这一点。",
                    Info = "No Ability.",
                    CardArtsId = "13240500",
                }
            },
            {
                "25002",//蟹蜘蛛幼虫
                new GwentCard()
                {
                    CardId ="25002",
                    Name="Arachas Drone",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Insectoid,Categorie.Token},
                    Flavor = "有时候，“年轻即是美”不过是大自然的谎言罢了。",
                    Info = "Summon all copies of this unit.",
                    CardArtsId = "20031000",
                }
            },
            {
                "25003",//战鬼
                new GwentCard()
                {
                    CardId ="25003",
                    Name="Draugir",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Token},
                    Flavor = "战鬼是战之恶魔。它们会出现在极度血腥惨烈的战场上，由万千憎恨凝结而成，嗜血成性。",
                    Info = "No Ability.",
                    CardArtsId = "20045700",
                }
            },
            {
                "25004",//鹰身女妖蛋
                new GwentCard()
                {
                    CardId ="25004",
                    Name="Harpy Egg",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Token},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "鹰身女妖蛋卷，真是美味佳肴啊，好先生。但它也非常昂贵，您可能料得到，这些可怜的鸟儿并不愿跟自己的蛋分离。",
                    Info = "When Consumed by another Unit, Boost that Unit by an additional 5. Deathwish: Spawn a Harpy on a random row.",
                    CardArtsId = "13231600",
                }
            },
            {
                "25005",//鹰身女妖幼崽
                new GwentCard()
                {
                    CardId ="25005",
                    Name="25005",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Token},
                    Flavor = "有时候，“年轻即是美”不过是大自然的谎言罢了。",
                    Info = "No ability.",
                    CardArtsId = "20030800",
                }
            },
            {
                "25006",//次级伊夫利特
                new GwentCard()
                {
                    CardId ="25006",
                    Name="Lesser Ifrit",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Construct,Categorie.Token},
                    Flavor = "曾经有个法师觉得它们可爱，而他的命运催生了一句俗语：“不要玩火自焚。”",
                    Info = "Deal 1 damage to a random enemy",
                    CardArtsId = "13240400",
                }
            },
            {
                "25007",//狼
                new GwentCard()
                {
                    CardId ="25007",
                    Name="Rabid Wolf",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Token},
                    Flavor = "“放心，我知道怎么驯狼……”——猎人邓巴的遗言。",
                    Info = "No Ability.",
                    CardArtsId = "13240300",
                }
            },
            {
                "25008",//血月
                new GwentCard()
                {
                    CardId ="25008",
                    Name="Blood Moon",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Hazard,Categorie.Token},
                    Flavor = "满月的时候，梦魇便会从世界的各个角落匍匐而出。",
                    Info = " Apply a Hazard to an enemy row that deals 2 damage to all units on contact.",
                    CardArtsId = "20006700",
                }
            },
            {
                "25009",//满月
                new GwentCard()
                {
                    CardId ="25009",
                    Name="Full Moon",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Monsters,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Boon,Categorie.Token},
                    Flavor = "满月的时候，梦魇便会从世界的各个角落匍匐而出。",
                    Info = "Apply a Boon to an allied row that boosts a random Beast or Vampire by 2 on turn start.",
                    CardArtsId = "20006700",
                }
            },
            {
                "31002",//恩希尔·恩瑞斯
                new GwentCard()
                {
                    CardId ="31002",
                    Name="Emhyr var Emreis",
                    Strength=7,
                    Group=Group.Leader,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Officer},
                    Flavor = "我没什么耐心。把我惹毛了，小心小命不保。",
                    Info = "Play a card from your hand, then return a Bronze or Silver ally to your hand.",
                    CardArtsId = "16110100",
                }
            },
            {
                "31003",//莫尔凡·符里斯
                new GwentCard()
                {
                    CardId ="31003",
                    Name="Morvran Voorhis",
                    Strength=7,
                    Group=Group.Leader,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Officer},
                    Flavor = "夏日阳光在阿尔巴河平静的水面上熠熠生辉——我印象中的尼弗迦德就是这样啊。",
                    Info = "Reveal up to 4 cards.",
                    CardArtsId = "16110200",
                }
            },
            {
                "31001",//约翰·卡尔维特
                new GwentCard()
                {
                    CardId ="31001",
                    Name="Jan Calveit",
                    Strength=5,
                    Group=Group.Leader,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Officer},
                    Flavor = "剑只是统治者的工具之一。",
                    Info = "Look at 3 cards from your deck, then play 1.",
                    CardArtsId = "16110300",
                }
            },
            {
                "31004",//篡位者
                new GwentCard()
                {
                    CardId ="31004",
                    Name="Usurper",
                    Strength=1,
                    Group=Group.Leader,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Officer},
                    Flavor = "王权怎能单凭出身的贵贱来随便决定？",
                    Info = "Spying. Create any Leader and boost it by 2.",
                    CardArtsId = "20158000",
                }
            },
            {
                "32002",//沙斯希乌斯
                new GwentCard()
                {
                    CardId ="32002",
                    Name="Xarthisius",
                    Strength=13,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "占卜术、水卜术、肠卜术、蜡卜术、蛋卜术、烬卜术、尿卜术、雷卜术……",
                    Info = "Look at your opponent's deck and move a card to the bottom.",
                    CardArtsId = "16210800",
                }
            },
            {
                "32003",//瓦提尔·德·李道克斯
                new GwentCard()
                {
                    CardId ="32003",
                    Name="Vattier de Rideaux",
                    Strength=11,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "精心策划的暗算能解决所有麻烦。",
                    Info = "Reveal up to 2 of your cards, then Reveal the same number of your opponent's randomly.",
                    CardArtsId = "16210300",
                }
            },
            {
                "32004",//史提芬·史凯伦
                new GwentCard()
                {
                    CardId ="32004",
                    Name="Stefan Skellen",
                    Strength=10,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "我在我们未来皇后的脸上留下了伤疤，这是我最引以为傲的成就。",
                    Info = "Choose a card from your deck, boost it by 5 and move it to the top of your deck.",
                    CardArtsId = "16210600",
                }
            },
            {
                "32005",//蒂博尔·艾格布拉杰
                new GwentCard()
                {
                    CardId ="32005",
                    Name="Tibor Eggebracht",
                    Strength=10,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "蒂博尔以狂热的忠诚而闻名。据说皇帝驾崩时，他深深地鞠躬致敬，几乎可以说贴在了地上。",
                    Info = "Truce: Boost self by 15, then your opponent draws a Revealed Bronze card.",
                    CardArtsId = "16210700",
                }
            },
            {
                "32006",//威戈佛特兹
                new GwentCard()
                {
                    CardId ="32006",
                    Name="Vilgefortz",
                    Strength=9,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "我们都是他棋盘上的棋子，而这棋局的规则，我们一无所知。",
                    Info = "Destroy an ally, then play a card from your deck; or Truce: Destroy an enemy, then your opponent draws a Revealed Bronze card.",
                    CardArtsId = "16210500",
                }
            },
            {
                "32007",//希拉德
                new GwentCard()
                {
                    CardId ="32007",
                    Name="Shilard",
                    Strength=9,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "所谓外交官，就是用华丽的辞藻，来透露一些只言片语。",
                    Info = "Truce: Draw a card from both decks. Keep one and give the other to your opponent.",
                    CardArtsId = "20007100",
                }
            },
            {
                "32008",//门诺·库霍恩
                new GwentCard()
                {
                    CardId ="32008",
                    Name="Menno Coehoorn",
                    Strength=8,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "细心的侦察分队比训练有素的军团更管用。",
                    Info = "Deploy: Damage an Enemy by 4. If it is Spying, Destroy it. ",
                    CardArtsId = "16210200",
                }
            },
            {
                "32009",//雷欧·邦纳特
                new GwentCard()
                {
                    CardId ="32009",
                    Name="Leo Bonhart",
                    Strength=7,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "他就坐在那里，死盯着我，一言不发。他的眼睛，好像……鱼眼，没有眉毛，没有睫毛……活脱脱两颗水球包裹的黑石头。一片死寂中，他就那样凝视着我，这却比被痛打我一顿更让我不寒而栗。",
                    Info = "Reveal one of your units and deal damage equal to its base power to an enemy.",
                    CardArtsId = "20003100",
                }
            },
            {
                "32001",//亚特里的林法恩
                new GwentCard()
                {
                    CardId ="32001",
                    Name="Rainfarn of Attre",
                    Strength=5,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "辛特拉沦陷后，亚特里随即告破，这里的守军若不听任尼弗迦德人驱策，就只能去死。",
                    Info = "Play a Bronze or Silver Spying unit from your deck.",
                    CardArtsId = "20003200",
                }
            },
            {
                "32010",//叶奈法：女术士
                new GwentCard()
                {
                    CardId ="32010",
                    Name="Yennefer: Enchantress",
                    Strength=5,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Aedirn},
                    HideTags = new HideTag[]{HideTag.Yennefer},
                    Flavor = "最好不要挡叶奈法的道。特别是当她忙着赶路的时候。",
                    Info = "Spawn the last Bronze or Silver Spell you played. ",
                    CardArtsId = "20160100",
                }
            },
            {
                "32011",//雷索：弑王者
                new GwentCard()
                {
                    CardId ="32011",
                    Name="Letho: Kingslayer",
                    Strength=5,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    Flavor = "这僧侣为什么戴着镶钉手套……？",
                    Info = "Choose One: Destroy an enemy Leader, then boost self by 5; or Play a Bronze or Silver Tactic from your deck.",
                    CardArtsId = "20160300",
                }
            },
            {
                "32012",//叶奈法：死灵法师
                new GwentCard()
                {
                    CardId ="32012",
                    Name="Yennefer: Divination",
                    Strength=5,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Aedirn},
                    HideTags = new HideTag[]{HideTag.Yennefer},
                    Flavor = "身体已经开始腐烂……但声带依然完好。说不定我们还能让他开口说话……",
                    Info = "Resurrect a Bronze or Silver Soldier from your opponent's graveyard.",
                    CardArtsId = "20178000",
                }
            },
            {
                "32013",//卡西尔·迪弗林
                new GwentCard()
                {
                    CardId ="32013",
                    Name="Cahir Dyffryn",
                    Strength=1,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer,Categorie.Doomed},
                    Flavor = "他的双眼在翼盔下熠熠生辉，剑刃上反射着火光。",
                    Info = "Resurrect a Leader.",
                    CardArtsId = "16210400",
                }
            },
            {
                "32014",//古雷特的雷索
                new GwentCard()
                {
                    CardId ="32014",
                    Name="Letho of Gulet",
                    Strength=1,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    Flavor = "猎魔人绝不会死在自己的床上。",
                    Info = "Spying. Toggle 2 units' Lock on the row, then Drain all their power.",
                    CardArtsId = "16210100",
                }
            },
            {
                "32015",//暗算
                new GwentCard()
                {
                    CardId ="32015",
                    Name="Treason",
                    Strength=0,
                    Group=Group.Gold,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "“请你出手要多少钱？” “看情况喽。比如说目标是你，大改100奥伦币左右。”",
                    Info = "Damage Enemies by 8 and then 8",
                    CardArtsId = "16310100",
                }
            },
            {
                "33004",//坎塔蕾拉
                new GwentCard()
                {
                    CardId ="33004",
                    Name="Cantarella",
                    Strength=13,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Agent},
                    Flavor = "男人渴望着诱惑，神秘加优雅往往事半功倍。",
                    Info = "Spying. Single-Use. Draw 2 cards. Keep one and move the other to the bottom of your deck.",
                    CardArtsId = "16221000",
                }
            },
            {
                "33005",//艾希蕾·阿纳兴
                new GwentCard()
                {
                    CardId ="33005",
                    Name="Assire var Anahid",
                    Strength=11,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "尼弗迦德法师也有选择：要么服从，要么上断头台。",
                    Info = "Return 2 Bronze or Silver cards from either graveyard to their respective decks.",
                    CardArtsId = "16220200",
                }
            },
            {
                "33003",//魔像守卫
                new GwentCard()
                {
                    CardId ="33003",
                    Name="The Guardian",
                    Strength=11,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Construct},
                    Flavor = "石拳阻挡刀剑，逻辑战胜谎言。",
                    Info = "Add a Lesser Guardian to the top of your opponent's deck.",
                    CardArtsId = "16240100",
                }
            },
            {
                "33006",//亚伯力奇
                new GwentCard()
                {
                    CardId ="33006",
                    Name="亚伯力奇",
                    Strength=10,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "火球？没问题。陛下想要什么都行。",
                    Info = "Truce: Each player draws a card. The opponent's card is Revealed.",
                    CardArtsId = "16220100",
                }
            },
            {
                "33007",//斯维尔
                new GwentCard()
                {
                    CardId ="33007",
                    Name="Sweers",
                    Strength=9,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "别碰那女孩！听明白没，你们这群乡巴佬？",
                    Info = "Choose an enemy or a Revealed unit in your opponent's hand, then move all copies of it from from their deck to the graveyard.",
                    CardArtsId = "16220600",
                }
            },
            {
                "33008",//亨利·凡·阿特里
                new GwentCard()
                {
                    CardId ="33008",
                    Name="Henry var Attre",
                    Strength=9,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support},
                    Flavor = "我在诺维格瑞驻守了十三年，什么我没见过？残忍、讥嘲、贪欲。可如今发生的事情却让我极度不安",
                    Info = "Conceal any number of units. If allies, boost by 2. If enemies, deal 2 damage.",
                    CardArtsId = "20022700",
                }
            },
            {
                "33002",//冒牌希里
                new GwentCard()
                {
                    CardId ="33002",
                    Name="False Ciri",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "“她来了，”他心想，“皇帝的联姻对象。冒牌公主、冒牌的辛特拉女王、冒牌的雅鲁加河口统治者，也是帝国未来的命脉。”",
                    Info = "Spying. If Spying, boost self by 1 on turn start and when your opponent passes, move to the opposite row. Deathwish: Destroy the Lowest unit on the row.",
                    CardArtsId = "16221200",
                }
            },
            {
                "33009",//重弩海尔格
                new GwentCard()
                {
                    CardId ="33009",
                    Name="Hefty Helge",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine},
                    Flavor = "并非攻城的最佳选择，却是毁城的行家里手。",
                    Info = "Deploy: If this Unit was Revealed, Damage all Enemies by 1. Otherwise, Damage all Enemies except those on opposite row by 1.",
                    CardArtsId = "20004100",
                }
            },
            {
                "33010",//奥克斯
                new GwentCard()
                {
                    CardId ="33010",
                    Name="Auckes",
                    Strength=7,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    Flavor = "雷索已有计划……还能出什么岔子？",
                    Info = "Lock 2 Units. Won't damage locked enemies anymore.",
                    CardArtsId = "16220800",
                }
            },
            {
                "33011",//彼得·萨尔格温利
                new GwentCard()
                {
                    CardId ="33011",
                    Name="Peter Saar Gwynleve",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "这双手不属于什么“阁下”，只属于一介农夫。所以这是农夫与农夫间的对话。",
                    Info = "Reset an ally and Strengthen it by 3; or Reset an enemy and Weaken it by 3.",
                    CardArtsId = "16220400",
                }
            },
            {
                "33012",//瑟瑞特
                new GwentCard()
                {
                    CardId ="33012",
                    Name="Serrit",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    Flavor = "这是我们必须做的，我并不为此感到羞愧。",
                    Info = "Deal 7 damage to an enemy or set a Revealed opposing unit to 1.",
                    CardArtsId = "16220900",
                }
            },
            {
                "33013",//辛西亚
                new GwentCard()
                {
                    CardId ="33013",
                    Name="Cynthia",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "决不能轻视辛西亚，必须把她看紧点儿。",
                    Info = "Deploy: Reveal the Highest Unit in your opponent's Hand and Boost self by its Power.",
                    CardArtsId = "16220300",
                }
            },
            {
                "33001",//约阿希姆·德·维特
                new GwentCard()
                {
                    CardId ="33001",
                    Name="Joachim de Wett",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "即便用“无能”来形容德·维特公爵对维登集团军的领导，都算给他面子",
                    Info = "Spying. Play the top non-Spying Bronze or Silver unit from your deck and boost it by 10.",
                    CardArtsId = "16221100",
                }
            },
            {
                "33014",//维尔海夫
                new GwentCard()
                {
                    CardId ="33014",
                    Name="Vrygheff",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "以眼还眼，我们最后一定会全都变成瞎子。",
                    Info = "Play a Bronze Machine from your deck",
                    CardArtsId = "20136700",
                }
            },
            {
                "33015",//凡赫玛
                new GwentCard()
                {
                    CardId ="33015",
                    Name="Vanhemar",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "作为火法师，他算不上……多么热烈。",
                    Info = "Spawn Frost, Clear Skies or Overdose.",
                    CardArtsId = "16220700",
                }
            },
            {
                "33016",//弗林姆德
                new GwentCard()
                {
                    CardId ="33016",
                    Name="Vreemde",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "即便要击败你们每一个人，我也要让伟大日轮照耀北境。",
                    Info = "Create a Bronze Nilfgaardian Soldier.",
                    CardArtsId = "20005000",
                }
            },
            {
                "33017",//契拉克·迪弗林
                new GwentCard()
                {
                    CardId ="33017",
                    Name="Ceallach Dyffryn",
                    Strength=2,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "“陛下……”皇家总管呜咽着说。直到刚才为止，根本没人留意他。“求您发发慈悲……卡西尔……我的儿子……”",
                    Info = "Deploy: Spawn an Ambassador, Assassin or Emissary.",
                    CardArtsId = "16221300",
                }
            },
            {
                "33018",//芙琳吉拉·薇歌
                new GwentCard()
                {
                    CardId ="33018",
                    Name="Fringilla Vigo",
                    Strength=1,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "魔法的价值高于一切，高于所有争论和敌意。",
                    Info = "Copy the power from the unit to the left to the unit to the right. Spying",
                    CardArtsId = "16220500",
                }
            },
            {
                "33019",//达兹伯格符文石
                new GwentCard()
                {
                    CardId ="33019",
                    Name="Dazhbog Runestone",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "当心。还烫着呢。",
                    Info = "Create and play a Bronze Nilfgaard card.",
                    CardArtsId = "20158300",
                }
            },
            {
                "33020",//通敌
                new GwentCard()
                {
                    CardId ="33020",
                    Name="Treason",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "许多人相信，帝国的实力在于纪律严明的军队与恪尽职守的法师。但事实上，金钱才是尼弗迦德统治世界的关键。",
                    Info = "Force 2 adjacent enemies to Duel each other.",
                    CardArtsId = "16320100",
                }
            },
            {
                "33021",//吊死鬼之毒
                new GwentCard()
                {
                    CardId ="33021",
                    Name="Cadaverine",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "我不会拿自己的性命去碰运气。我会拿上一把长剑，厚厚地涂上一层吊死鬼之毒。",
                    Info = "Deal 2 damage to an enemy and all units that share its categories; or destroy a Bronze or Silver Neutral unit.",
                    CardArtsId = "20154000",
                }
            },
            {
                "33022",//尼弗迦德大门
                new GwentCard()
                {
                    CardId ="33022",
                    Name="Nilfgaardian Gate",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "应该不会对游客开放……",
                    Info = "Play a Bronze or Silver Officer from your deck and boost it by 1.",
                    CardArtsId = "20055600",
                }
            },
            {
                "33023",//奴隶贩子
                new GwentCard()
                {
                    CardId ="33023",
                    Name="Slave Driver",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "奴隶贩子只有一个追求：那就是把他的命令一丝不苟地执行下去。",
                    Info = "Set an ally's power to 1 and deal damage to an enemy by the amount of power lost.",
                    CardArtsId = "20137700",
                }
            },
            {
                "34004",//尼弗迦德骑士
                new GwentCard()
                {
                    CardId ="34004",
                    Name="Nilfgaardian Knight",
                    Strength=12,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "出自名门望族，生于金塔之城，组成帝国的精锐部队。",
                    Info = "Reveal a random card in your hand. 2 Armor.",
                    CardArtsId = "16231800",
                }
            },
            {
                "34006",//伪装大师
                new GwentCard()
                {
                    CardId ="34006",
                    Name="Master of Disguise",
                    Strength=11,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "哦，高悬上苍的伟大日轮啊，把我们从裤腿里除之不尽的虱子中解救出来吧！",
                    Info = "Conceal 2 cards.",
                    CardArtsId = "20012000",
                }
            },
            {
                "34007",//阿尔巴师矛兵
                new GwentCard()
                {
                    CardId ="34007",
                    Name="Alba Spearman",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "为了帝国，至死不渝！",
                    Info = "Boost self by 1 whenever either player draws a card.",
                    CardArtsId = "16231200",
                }
            },
            {
                "34008",//渗透者
                new GwentCard()
                {
                    CardId ="34008",
                    Name="Infiltrator",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{},
                    Flavor = "你可以一直逃，但你永远藏不了。",
                    Info = "Toggle a unit's Spying status.",
                    CardArtsId = "20011800",
                }
            },
            {
                "34009",//炼金术士
                new GwentCard()
                {
                    CardId ="34009",
                    Name="Alchemist",
                    Strength=9,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "两盎司钙素，一盎司结合剂……",
                    Info = "Reveal 2 cards.",
                    CardArtsId = "16231600",
                }
            },
            {
                "34010",//军旗手
                new GwentCard()
                {
                    CardId ="34010",
                    Name="Standard Bearer",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "“你要拼上性命，保卫这面军旗！Gloir aen Ard Feain！”",
                    Info = "Boost an ally by 2 whenever you play a Soldier. ",
                    CardArtsId = "20029400",
                }
            },
            {
                "34011",//投尸机
                new GwentCard()
                {
                    CardId ="34011",
                    Name="Rot Tosser",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine},
                    Flavor = "向围城中散播瘟疫是否人道，这个话题还是留给史学家吧。我们只关心这法子有没有效。",
                    Info = "Spawn a Cow Carcass on an enemy row.",
                    CardArtsId = "16230200",
                }
            },
            {
                "34012",//奴隶猎人
                new GwentCard()
                {
                    CardId ="34012",
                    Name="Slave Hunter",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "诀窍在于摧残他们的意志，而不是肉体",
                    Info = "Charm a Bronze enemy with 3 power or less.",
                    CardArtsId = "20133700",
                }
            },
            {
                "34013",//哨卫
                new GwentCard()
                {
                    CardId ="34013",
                    Name="Sentry",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "要造桥，不要造城墙。",
                    Info = "Boost all copies of a Soldier by 2",
                    CardArtsId = "20166100",
                }
            },
            {
                "34014",//阿尔巴师装甲骑兵
                new GwentCard()
                {
                    CardId ="34014",
                    Name="Alba Armored Cavalry",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "他们以雷动之势冲进敌军方阵，犹如一把尖刀插入柔软的肚腹。阿尔巴之师所向披靡，一路横扫，直取泰莫利亚步兵团的咽喉。",
                    Info = "Whenever an ally appears, boost self by 1.",
                    CardArtsId = "20029600",
                }
            },
            {
                "34015",//戴斯文强弩手
                new GwentCard()
                {
                    CardId ="34015",
                    Name="Deithwen Arbalest",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "我只瞄膝盖，一向如此。",
                    Info = "Deal 3 damage to an enemy. If it is Spying, deal 6 damage instead.",
                    CardArtsId = "16230500",
                }
            },
            {
                "34016",//射石机
                new GwentCard()
                {
                    CardId ="34016",
                    Name="Mangonel",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine},
                    Flavor = "适用于投掷残骸和干粪。",
                    Info = "Deal 2 damage to a random enemy. Repeat this ability whenever you Reveal this card.",
                    CardArtsId = "16231700",
                }
            },
            {
                "34017",//那乌西卡旅中士
                new GwentCard()
                {
                    CardId ="34017",
                    Name="Nauzicaa Sergeant",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Officer},
                    Flavor = "皇帝会教北方人懂点儿规矩的。",
                    Info = "Clear Hazards from its row and boost an ally or a Revealed unit by 3.",
                    CardArtsId = "16230900",
                }
            },
            {
                "34018",//作战工程师
                new GwentCard()
                {
                    CardId ="34018",
                    Name="Combat Engineer",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support},
                    CrewCount = 1,
                    Flavor = "战争是文明进步的确凿证据——看看吧，现在大伙儿打仗更有效率了。",
                    Info = "Boost an ally by 5. Crew.",
                    CardArtsId = "16231300",
                }
            },
            {
                "34003",//近卫军
                new GwentCard()
                {
                    CardId ="34003",
                    Name="Impera Brigade",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "近卫军绝不投降，绝不。",
                    Info = "Deploy: Boost self by 2 for each Spying Enemy. Whenever a Spying Enemy appears, Boost self by 2.",
                    CardArtsId = "16230700",
                }
            },
            {
                "34005",//近卫军铁卫
                new GwentCard()
                {
                    CardId ="34005",
                    Name="Impera Enforcers",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "皇帝最忠诚的贴身护卫，誓死保卫皇帝的安全。",
                    Info = "Deal 2 damage to an enemy. For each Spying enemy that appears during your turn, deal 2 damage to an enemy on turn end.",
                    CardArtsId = "16230800",
                }
            },
            {
                "34019",//火蝎攻城弩
                new GwentCard()
                {
                    CardId ="34019",
                    Name="Fire Scorpion",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine},
                    Flavor = "名字与实物可谓风马牛不相及，听上去它好像是某种肥大的红色甲壳生物，但其实是一种由能工巧匠精心设计的大规模杀伤性武器……",
                    Info = "Deal 5 damage to an enemy. Whenever you Reveal this unit, trigger its ability.",
                    CardArtsId = "16230600",
                }
            },
            {
                "34020",//那乌西卡旅
                new GwentCard()
                {
                    CardId ="34020",
                    Name="Nauzicaa Brigade",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "我们被称作死神头。想知道为什么吗？",
                    Info = "Deploy: Damage a Spying Unit by 7. If it was Destroyed, Strengthen self by 4.",
                    CardArtsId = "16231000",
                }
            },
            {
                "34021",//侦察员
                new GwentCard()
                {
                    CardId ="34021",
                    Name="Spotter",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "北方佬耍不出花招了。",
                    Info = "Deploy: Choose a bronze or silver Revealed Unit in either Hand and Boost self by its base Power.",
                    CardArtsId = "16230300",
                }
            },
            {
                "34022",//毒蛇学派猎魔人
                new GwentCard()
                {
                    CardId ="34022",
                    Name="Viper Witcher",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Witcher},
                    Flavor = "毒蛇学派将会重生……雷索志在必得。",
                    Info = "Deal 1 damage for each Alchemy card in your starting deck.",
                    CardArtsId = "20012400",
                }
            },
            {
                "34023",//迪尔兰士兵
                new GwentCard()
                {
                    CardId ="34023",
                    Name="Daerlan Soldier",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "我在布莱班特军事学院学到了不少东西，比如洗土豆",
                    Info = "Whenever you Reveal this unit, play it on a random row and draw a card.",
                    CardArtsId = "16230100",
                }
            },
            {
                "34024",//阿尔巴师枪兵
                new GwentCard()
                {
                    CardId ="34024",
                    Name="Alba Pikeman",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "宣誓效忠吾皇恩希尔·恩瑞斯……不然就受刑吧！",
                    Info = "Summon all copies of this unit.",
                    CardArtsId = "16231100",
                }
            },
            {
                "34025",//帝国魔像
                new GwentCard()
                {
                    CardId ="34025",
                    Name="Imperial Golem",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Construct},
                    Flavor = "尼弗迦德最强大的法师们终于成功掌握了制造魔像的方法。更棒的是，他们已经“偶尔”能让这些魔像为帝国而战了……",
                    Info = "Summon a copy of this unit whenever you Reveal a card in your opponent's hand. ",
                    CardArtsId = "13240700",
                }
            },
            {
                "34026",//马格尼师
                new GwentCard()
                {
                    CardId ="34026",
                    Name="Magne Division",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "皇帝固然应该胸怀天下……但派人守卫这么一块不毛之地，实在是浪费资源。",
                    Info = "Play a random Bronze Item from your deck.",
                    CardArtsId = "20004400",
                }
            },
            {
                "34027",//奴隶步兵
                new GwentCard()
                {
                    CardId ="34027",
                    Name="Slave Infantry",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "自由人可以选择。奴隶只能由别人替他们决定。",
                    Info = "Spawn a Doomed default copy of this unit on your other rows.",
                    CardArtsId = "20136500",
                }
            },
            {
                "34028",//大使
                new GwentCard()
                {
                    CardId ="34028",
                    Name="Ambassador",
                    Strength=2,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{},
                    Flavor = "间谍？不，这么说就太过啦。我觉得自己不过是个观察员而已。",
                    Info = "Spying. Boost an ally by 12.",
                    CardArtsId = "16231500",
                }
            },
            {
                "34002",//特使
                new GwentCard()
                {
                    CardId ="34002",
                    Name="Emissary",
                    Strength=2,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{},
                    Flavor = "但是……这样不对啊！两国交兵不斩来使！",
                    Info = "Spying. Look at 2 random Bronze units from your deck, then play 1.",
                    CardArtsId = "16231400",
                }
            },
            {
                "34001",//维可瓦罗见习法师
                new GwentCard()
                {
                    CardId ="34001",
                    Name="Vicovaro Novice",
                    Strength=2,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "尼弗迦德的法师们就像手纸。一旦谁被皇帝厌倦，立刻有大把新人迫不及待地赶来补缺。",
                    Info = "Deploy: Draw the top 2 Bronze Alchemy cards from your Deck. Play 1 and shuffle the other back. ",
                    CardArtsId = "12240300",
                }
            },
            {
                "34029",//刺客
                new GwentCard()
                {
                    CardId ="34029",
                    Name="Assassin",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{},
                    Flavor = "帝国宫廷最受欢迎的职业之一，仅次于抄书吏和轻浮的贵妇。",
                    Info = "Spying. Deal 10 damage to the unit to the left.",
                    CardArtsId = "20011500",
                }
            },
            {
                "34030",//维可瓦罗医师
                new GwentCard()
                {
                    CardId ="34030",
                    Name="Vicovaro Medic",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support,Categorie.Doomed},
                    Flavor = "这个世界的瘟疫跟战争一样多，夺人性命也一样地出其不意。",
                    Info = "Resurrect a Bronze unit from your opponent's graveyard.",
                    CardArtsId = "16230400",
                }
            },
            {
                "34031",//文登达尔精锐
                new GwentCard()
                {
                    CardId ="34031",
                    Name="Venendal Elite",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "艾宾以其顶尖的雇佣兵和轻骑兵闻名天下。",
                    Info = "Switch this unit's power with that of a Revealed unit.",
                    CardArtsId = "20051800",
                }
            },
            {
                "34032",//新兵
                new GwentCard()
                {
                    CardId ="34032",
                    Name="Recruit",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "他也不问为什么，只能……一个接一个地削那该死的马铃薯。",
                    Info = "Play a random different Bronze Soldier from your deck.",
                    CardArtsId = "20161700",
                }
            },
            {
                "34033",//油膏
                new GwentCard()
                {
                    CardId ="34033",
                    Name="Ointment",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "它管用吗？谁知道呢。反正试试也没坏处。可能吧。",
                    Info = "Resurrect a Bronze unit with 5 power or less.",
                    CardArtsId = "20153900",
                }
            },
            {
                "35001",//次级魔像守卫
                new GwentCard()
                {
                    CardId ="35001",
                    Name="Lesser Guardian",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Construct,Categorie.Token},
                    Flavor = "按理说死去的守卫者不该再坚守岗位，但魔法可往往不会遵循常理……",
                    Info = "No Ability.",
                    CardArtsId = "16240100",
                }
            },
            {
                "35002",//牛尸
                new GwentCard()
                {
                    CardId ="35002",
                    Name="Cow Carcass",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Nilfgaard,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = true,
                    Countdown = 2,//冷却2
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Token},
                    Flavor = "那是只鸟？还是头狮鹫？不对！那是……",
                    Info = "After 2 turns, destroy the weakest non-Gold unit(s) on the row (except self). Banish when moved to the graveyard.",
                    CardArtsId = "16240200",
                }
            },
            {
                "41001",//拉多维德五世
                new GwentCard()
                {
                    CardId ="41001",
                    Name="King Radovid V",
                    Strength=6,
                    Group=Group.Leader,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Redania},
                    CrewCount = 1,
                    Flavor = "身为国王，对待敌人应冷酷无情，对待朋友当慷慨大度。",
                    Info = "Toggle 2 units' Lock statuses. If enemies, deal 4 damage to them. Crew.",
                    CardArtsId = "12110200",
                }
            },
            {
                "41002",//雅妲公主
                new GwentCard()
                {
                    CardId ="41002",
                    Name="Princess Adda",
                    Strength=6,
                    Group=Group.Leader,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Cursed},
                    Flavor = "她的诅咒被解除了……但是喜欢吃生肉的习惯却没改掉。",
                    Info = "Create a Bronze or Silver Cursed unit.",
                    CardArtsId = "20006300",
                }
            },
            {
                "41003",//弗尔泰斯特国王
                new GwentCard()
                {
                    CardId ="41003",
                    Name="King Foltest",
                    Strength=5,
                    Group=Group.Leader,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Temeria},
                    CrewCount = 1,
                    Flavor = "我不需要谋臣和他们的诡计，我相信士兵的利刃。",
                    Info = "Boost all other allies and your non-Spying units in hand and deck by 1. Crew.",
                    CardArtsId = "12110100",
                }
            },
            {
                "41004",//亨赛特国王
                new GwentCard()
                {
                    CardId ="41004",
                    Name="King Henselt",
                    Strength=3,
                    Group=Group.Leader,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Kaedwen},
                    CrewCount = 1,
                    Flavor = "恕我直言，亨赛特国王不是看起来像贼，他本就是贼。",
                    Info = "Choose a Bronze Machine or Kaedweni ally and play all copies of it from your deck. Crew.",
                    CardArtsId = "12110300",
                }
            },
            {
                "42001",//丹德里恩
                new GwentCard()
                {
                    CardId ="42001",
                    Name="Dandelion",
                    Strength=11,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support},
                    Flavor = "丹德里恩，你愤世嫉俗、好色成性又谎话连篇——却也是我最好的朋友。",
                    Info = "Boost 3 units in your deck by 2.",
                    CardArtsId = "12220100",
                }
            },
            {
                "42002",//血红男爵
                new GwentCard()
                {
                    CardId ="42002",
                    Name="Bloody Baron",
                    Strength=9,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Temeria,Categorie.Officer},
                    Flavor = "我知道自己不是个好父亲，但……现在弥补或许还来得及。",
                    Info = "Whenever an enemy is destroyed, boost self by 1, wherever it is.",
                    CardArtsId = "12210100",
                }
            },
            {
                "42003",//古雷特的赛尔奇克
                new GwentCard()
                {
                    CardId ="42003",
                    Name="Seltkirk of Gulet",
                    Strength=8,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Aedirn,Categorie.Officer},
                    Flavor = "尽管赛尔奇克美德过人，更是有着不屈的勇气，然而他还是和所有命丧上亚甸之战的将士一样，没能逃过自己的命运。",
                    Info = "Duel an enemy. 3 Armor.",
                    CardArtsId = "20161800",
                }
            },
            {
                "42004",//范德格里夫特
                new GwentCard()
                {
                    CardId ="42004",
                    Name="Vandergrift",
                    Strength=7,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Kaedwen,Categorie.Officer},
                    Flavor = "将军本以为洛马克的战争会很快结束，不会有什么损失……结果却陷入了永恒的征战。",
                    Info = "Deal 1 damage to all enemies. If a unit is destroyed, apply Ragh Nar Roog to its row.",
                    CardArtsId = "20162000",
                }
            },
            {
                "42005",//约翰·纳塔利斯
                new GwentCard()
                {
                    CardId ="42005",
                    Name="John Natalis",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Temeria,Categorie.Officer},
                    Flavor = "那座广场应以我的士兵及其他牺牲者来命名，而不是顶着我的名字。",
                    Info = "Deploy: Play a Bronze or Silver Tactics card from your Deck. Shuffle the others back.",
                    CardArtsId = "12210300",
                }
            },
            {
                "42006",//凯拉·梅兹
                new GwentCard()
                {
                    CardId ="42006",
                    Name="Keira Metz",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Temeria},
                    Flavor = "即便今天死，我也要死得光鲜亮丽。",
                    Info = "Spawn Alzur's Thunder, Thunderbolt or Arachas Venom.",
                    CardArtsId = "12210800",
                }
            },
            {
                "42007",//罗契：冷酷之心
                new GwentCard()
                {
                    CardId ="42007",
                    Name="Roche: Merciless",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Temeria,Categorie.Officer},
                    Flavor = "我们内心从不畏惧。不过，倒是有一个人类……弗农·罗契。千万要当心他。",
                    Info = "Destroy a face-down Ambush enemy.",
                    CardArtsId = "20177700",
                }
            },
            {
                "42008",//迪杰斯特拉
                new GwentCard()
                {
                    CardId ="42008",
                    Name="Sigismund Dijkstra",
                    Strength=4,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Redania},
                    Flavor = "你真以为这种下三滥的谎话能糊弄我？",
                    Info = "Spying. Play 2 random cards from your deck.",
                    CardArtsId = "12210500",
                }
            },
            {
                "42009",//夏妮
                new GwentCard()
                {
                    CardId ="42009",
                    Name="Shani",
                    Strength=4,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Redania,Categorie.Support,Categorie.Doomed},
                    Flavor = "我是医师，不会乱开药。",
                    Info = "Resurrect a non-Cursed Bronze or Silver unit and give it 2 Armor.",
                    CardArtsId = "12210600",
                }
            },
            {
                "42010",//凯亚恩
                new GwentCard()
                {
                    CardId ="42010",
                    Name="Kiyan",
                    Strength=4,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Witcher},
                    Flavor = "我们生活在无尽黑色大海中一座宁静的世外小岛上。我们不该扬帆远航。",
                    Info = "Choose One: Create a Bronze or Silver Alchemy card; or Play a Bronze or Silver Item from your deck.",
                    CardArtsId = "20162100",
                }
            },
            {
                "42011",//普西拉
                new GwentCard()
                {
                    CardId ="42011",
                    Name="Priscilla",
                    Strength=3,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support},
                    Flavor = "想像一下穿裙子的丹德里恩，大概就是那副模样。",
                    Info = "Boost 5 random allies by 3.",
                    CardArtsId = "12220200",
                }
            },
            {
                "42012",//弗农·罗契
                new GwentCard()
                {
                    CardId ="42012",
                    Name="Vernon Roche",
                    Strength=3,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Temeria,Categorie.Officer},
                    Flavor = "一位爱国者……也是个令人头疼的家伙。",
                    Info = "Deal 7 damage. At the start of the game, add a Blue Stripes Commando to your deck.",
                    CardArtsId = "12210200",
                }
            },
            {
                "42013",//菲丽芭·艾哈特
                new GwentCard()
                {
                    CardId ="42013",
                    Name="Philippa Eilhart",
                    Strength=1,
                    Group=Group.Gold,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Redania},
                    Flavor = "王族的权势即将凋零，女术士集会所必将崛起。",
                    Info = "Deal 5 damage to an enemy, then deal 4, 3, 2 and 1 damage to random enemies.",
                    CardArtsId = "12210400",
                }
            },
            {
                "43001",//塔勒 
                new GwentCard()
                {
                    CardId ="43001",
                    Name="Thaler",
                    Strength=13,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Temeria,Categorie.Agent},
                    Flavor = "滚开！我们中间不是每个人都那么轻浮、那么浅薄……",
                    Info = "Spying. Single-Use. Draw 2 cards, keep one and return the other to your deck.",
                    CardArtsId = "12220300",
                }
            },
            {
                "43002",//薇丝
                new GwentCard()
                {
                    CardId ="43002",
                    Name="Ves",
                    Strength=12,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Temeria},
                    Flavor = "宁似帝王快活一天，强如乞丐苟活一世。",
                    Info = "Swap up to 2 cards.",
                    CardArtsId = "12220400",
                }
            },
            {
                "43003",//巨魔魔
                new GwentCard()
                {
                    CardId ="43003",
                    Name="Trollololo",
                    Strength=11,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Redania,Categorie.Ogroid},
                    Flavor = "我是拉多多德国王的兵兵。收到命令，看守船船。",
                    Info = "9 Armor.",
                    CardArtsId = "12220900",
                }
            },
            {
                "43004",//没完没了的朗维德
                new GwentCard()
                {
                    CardId ="43004",
                    Name="Ronvid the Incessant",
                    Strength=11,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Kaedwen},
                    CrewCount = 1,
                    Flavor = "这位自封的骑士四海漂泊，捍卫着心爱少女比贝莉的荣誉。虽然没人知道她住在哪里，她是不是哈活着，甚至是不是曾经有过这个人。",
                    Info = "Resurrect on a random row with 1 power on turn end. Crew.",
                    CardArtsId = "20046500",
                }
            },
            {
                "43005",//异婴
                new GwentCard()
                {
                    CardId ="43005",
                    Name="Botchling",
                    Strength=10,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed},
                    Flavor = "承认错误，妥善安葬——否则他们会回来缠着你不放。",
                    Info = "Summon a Lubberkin.",
                    CardArtsId = "12240100",
                }
            },
            {
                "43006",//南尼克
                new GwentCard()
                {
                    CardId ="43006",
                    Name="Nenneke",
                    Strength=10,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support,Categorie.Temeria},
                    Flavor = "南尼克的医术无人可及。",
                    Info = "Return 3 Bronze or Silver units from the graveyard to your deck.",
                    CardArtsId = "12221200",
                }
            },
            {
                "43007",//弗尔泰斯特之傲
                new GwentCard()
                {
                    CardId ="43007",
                    Name="Foltest's Pride",
                    Strength=10,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine},
                    Flavor = "正如弗尔泰斯特国王常说的那样，尺寸并不重要，关键要好用。",
                    Info = "Damage an enemy by 2 and move it to the row above. Crewed: Repeat its ability.",
                    CardArtsId = "20149400",
                }
            },
            {
                "43008",//文森特·梅斯
                new GwentCard()
                {
                    CardId ="43008",
                    Name="Vincent Meis",
                    Strength=9,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Cursed},
                    Flavor = "白天是维吉玛城卫兵队长。到了晚上，便化身为无情的复仇者，保卫受尽压迫的劳苦大众。",
                    Info = "Destroy the Armor of all units, then boost self by half the value destroyed.",
                    CardArtsId = "20009800",
                }
            },
            {
                "43009",//欧德林
                new GwentCard()
                {
                    CardId ="43009",
                    Name="Odrin",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Kaedwen},
                    Flavor = "喝酒少了欧德林，就像划船没带桨。",
                    Info = "Move to a random row and boost all allies on it by 1 on turn start. ",
                    CardArtsId = "12221300",
                }
            },
            {
                "43010",//休伯特·雷亚克
                new GwentCard()
                {
                    CardId ="43010",
                    Name="Hubert Rejk",
                    Strength=7,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Vampire},
                    Flavor = "验尸官是个冷静、淡定的人。就算是尸体，也会精心照料。",
                    Info = "Drain all boosts from units in your deck.",
                    CardArtsId = "20008800",
                }
            },
            {
                "43011",//玛格丽塔
                new GwentCard()
                {
                    CardId ="43011",
                    Name="Margarita of Aretuza",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Temeria},
                    Flavor = "我只关心艾瑞图萨学院和我的学生们。",
                    Info = "Reset a unit and toggle its Lock status.",
                    CardArtsId = "12221100",
                }
            },
            {
                "43012",//家事妖精
                new GwentCard()
                {
                    CardId ="43012",
                    Name="Lubberkin",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed},
                    Flavor = "吾为汝取名蒂雅，收汝为吾女。",
                    Info = "Summon a Botchling",
                    CardArtsId = "12240200",
                }
            },
            {
                "43013",//戴斯摩
                new GwentCard()
                {
                    CardId ="43013",
                    Name="Dethmold",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Kaedwen},
                    Flavor = "我曾让一个囚犯搜肠刮肚地狂吐……啊，好怀念……",
                    Info = "Spawn Rain, Clear Skies or Alzur's Thunder.",
                    CardArtsId = "12220700",
                }
            },
            {
                "43014",//席儿·德·坦沙维耶
                new GwentCard()
                {
                    CardId ="43014",
                    Name="Síle de Tansarville",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "女术士集会所缺乏谦逊，对权力的渴望可能会让我们功亏一篑。",
                    Info = "Play a Bronze or Silver special card from your hand, then draw a card.",
                    CardArtsId = "12220500",
                }
            },
            {
                "43015",//帕薇塔公主
                new GwentCard()
                {
                    CardId ="43015",
                    Name="Princess Pavetta",
                    Strength=3,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Cintra},
                    Flavor = "他们说公主容易动怒，但我没想到……",
                    Info = "Return each player's Lowest Bronze or Silver unit to their deck.",
                    CardArtsId = "12221000",
                }
            },
            {
                "43016",//斯坦尼斯王子
                new GwentCard()
                {
                    CardId ="43016",
                    Name="Prince Stennis",
                    Strength=3,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Aedirn,Categorie.Officer},
                    Flavor = "他穿着黄金铠甲——没错，混账一个。",
                    Info = "Play a random non-Spying Bronze or Silver unit from your deck and give it 5 Armor. 3 Armor.",
                    CardArtsId = "12220800",
                }
            },
            {
                "43017",//萨宾娜·葛丽维希格
                new GwentCard()
                {
                    CardId ="43017",
                    Name="Sabrina Glevissig",
                    Strength=3,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Kaedwen},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "科德温荒野之女。",
                    Info = "Spying. Deathwish: Set the power of all units on the row to the power of the Lowest unit on the row.",
                    CardArtsId = "12220600",
                }
            },
            {
                "43018",//萨宾娜的幽灵
                new GwentCard()
                {
                    CardId ="43018",
                    Name="Sabrina's Specter",
                    Strength=3,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Cursed,Categorie.Doomed},
                    Flavor = "萨宾娜·葛丽维希格用尽最后一口气，释放出一道强大的诅咒，不但处刑人遭了殃，留在附近的所有人也都没能幸免。",
                    Info = "Resurrect a Bronze Cursed unit.",
                    CardArtsId = "20165000",
                }
            },
            {
                "43019",//佐里亚符文石
                new GwentCard()
                {
                    CardId ="43019",
                    Name="Zoria Runestone",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "这块符文石让我不寒而栗……我是不是做了什么伤它感情的事？",
                    Info = "Create a Bronze or Silver Northern Realms card.",
                    CardArtsId = "20158200",
                }
            },
            {
                "43020",//增援
                new GwentCard()
                {
                    CardId ="43020",
                    Name="Reinforcements",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "吹号撤退！重新集结！等待增援！",
                    Info = "Play a Bronze or Silver Soldier, Machine, Officer or Support unit from your deck.",
                    CardArtsId = "12320100",
                }
            },
            {
                "43021",//范德格里夫特之剑
                new GwentCard()
                {
                    CardId ="43021",
                    Name="Vandergrift's Blade",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Item},
                    Flavor = "在阿德卡莱的一次骑士比武中，赛尔奇克打断了范德格里夫特的长剑。于是，愤怒的范德格里夫特下令铸造一把新的兵刃，还在上面附了强大的符文石。",
                    Info = "Choose One: Destroy a Bronze or Silver Cursed enemy; or Deal 9 damage. If the unit was destroyed, Banish it.",
                    CardArtsId = "20163300",
                }
            },
            {
                "44001",//崔丹姆步兵
                new GwentCard()
                {
                    CardId ="44001",
                    Name="Tridam Infantry",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "他们本是忠于崔丹姆老男爵的士兵，随法利波离开城市后，如今却成了被悬赏的叛徒。",
                    Info = "4 Armor.",
                    CardArtsId = "20017100",
                }
            },
            {
                "44002",//班·阿德导师
                new GwentCard()
                {
                    CardId ="44002",
                    Name="Ban Ard Tutor",
                    Strength=9,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Kaedwen},
                    Flavor = "我一直拿艾瑞图萨学院的女生和班·阿德的愣头小子们作对比。结果总是姑娘们胜出。",
                    Info = "Swap a card in your with a Bronze special card from your deck.",
                    CardArtsId = "20004800",
                }
            },
            {
                "44003",//科德温中士
                new GwentCard()
                {
                    CardId ="44003",
                    Name="Kaedweni Sergeant",
                    Strength=9,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Kaedwen,Categorie.Officer},
                    CrewCount = 1,
                    Flavor = "冲锋，没用的蠢货！冲锋，不然你就会知道，我比尼弗迦德人更可怕！",
                    Info = "Clear Hazards from its row. 3 Armor. Crew.",
                    CardArtsId = "12221400",
                }
            },
            {
                "44004",//科德温骑兵
                new GwentCard()
                {
                    CardId ="44004",
                    Name="Kaedweni Cavalry",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Kaedwen},
                    Flavor = "我一直很好奇，这帮家伙是怎么解决内急的？",
                    Info = "Destroy a unit's Armor, then boost self by the amount destroyed.",
                    CardArtsId = "12231400",
                }
            },
            {
                "44005",//战地医师
                new GwentCard()
                {
                    CardId ="44005",
                    Name="Field Medic",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support},
                    Flavor = "红缝红，白缝白，活儿真不赖。",
                    Info = "Boost Soldier allies by 1.",
                    CardArtsId = "12231200",
                }
            },
            {
                "44006",//瑞达尼亚精锐
                new GwentCard()
                {
                    CardId ="44006",
                    Name="Redanian Elite",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Redania,Categorie.Soldier},
                    Flavor = "为了瑞达尼亚，不论上刀山下油锅，还是吃虫子，我都在所不惜。",
                    Info = "Whenever this unit's Armor reaches 0, boost self by 5. 4 Armor.",
                    CardArtsId = "12231700",
                }
            },
            {
                "44007",//攻城塔
                new GwentCard()
                {
                    CardId ="44007",
                    Name="Siege Tower",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine},
                    Flavor = "攻城用的最新武器。",
                    Info = "Boost self by 2. Crewed: Repeat its ability.",
                    CardArtsId = "12230400",
                }
            },
            {
                "44008",//加强型投石机
                new GwentCard()
                {
                    CardId ="44008",
                    Name="Reinforced Trebuchet",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine},
                    Flavor = "感受到了吗？每当这宝贝儿投出巨石，大地都会震颤。",
                    Info = "Deal 1 damage to a random enemy on turn end.",
                    CardArtsId = "12231500",
                }
            },
            {
                "44009",//科德温骑士
                new GwentCard()
                {
                    CardId ="44009",
                    Name="Kaedweni Knight",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Kaedwen},
                    Flavor = "科德温军队里并非所有人都认同国王的政治手段。然而谁都不敢说出来。",
                    Info = "Boost this unit by 5 if played from the deck. 2 Armor.",
                    CardArtsId = "20003400",
                }
            },
            {
                "44010",//被诅咒的骑士
                new GwentCard()
                {
                    CardId ="44010",
                    Name="Cursed Knight",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Aedirn},
                    Flavor = "深陷无尽的战斗，却早已忘记了起因。",
                    Info = "Transform a Cursed ally into a copy of this unit. 2 Armor.",
                    CardArtsId = "20162500",
                }
            },
            {
                "44011",//攻城后援
                new GwentCard()
                {
                    CardId ="44011",
                    Name="Siege Support",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Kaedwen,Categorie.Support},
                    CrewCount = 1,
                    Flavor = "“你得把准星左校5度。”“把什么调多少？”",
                    Info = "Whenever an ally appears, boost it by 1. If it's a Machine, also give it 1 Armor. Crew.",
                    CardArtsId = "12230900",
                }
            },
            {
                "44012",//瑞达尼亚骑士
                new GwentCard()
                {
                    CardId ="44012",
                    Name="Redanian Knight",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Redania,Categorie.Soldier},
                    Flavor = "为了荣耀，为了拉多维德陛下！",
                    Info = "If that unit has no Armor, boost it by 2 and give it 2 Armor on turn end.",
                    CardArtsId = "12230800",
                }
            },
            {
                "44013",//瑞达尼亚当选骑士
                new GwentCard()
                {
                    CardId ="44013",
                    Name="Redanian Knight-Elect",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Redania,Categorie.Soldier},
                    Flavor = "不为名不为利，高尚的动机才能成就英雄！",
                    Info = "If this unit has Armor on turn end, boost adjacent units by 1. 2 Armor.",
                    CardArtsId = "12330100",
                }
            },
            {
                "44014",//加强型弩炮
                new GwentCard()
                {
                    CardId ="44014",
                    Name="Reinforced Ballista",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine},
                    Flavor = "从没两次命中同一处，仔细想想，真是个大问题。",
                    Info = "Deploy: Damage an Enemy by 2. Fresh Crew: Repeat the Deploy ability.",
                    CardArtsId = "12230200",
                }
            },
            {
                "44015",//投石机
                new GwentCard()
                {
                    CardId ="44015",
                    Name="Trebuchet",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine},
                    Flavor = "城堡可是块硬骨头。快去准备投石机！",
                    Info = "Deploy: Damage 3 Adjacent Enemies by 1. Fresh Crew: Increase the Damage dealt by 1.",
                    CardArtsId = "12230300",
                }
            },
            {
                "44016",//亚甸槌击者
                new GwentCard()
                {
                    CardId ="44016",
                    Name="Aedirnian Mauler",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Aedirn},
                    Flavor = "呃，这些家伙真让人头疼。",
                    Info = "Deal 4 damage to an enemy.",
                    CardArtsId = "20167500",
                }
            },
            {
                "44017",//弩炮
                new GwentCard()
                {
                    CardId ="44017",
                    Name="Ballista",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine},
                    Flavor = "成为弩炮是所有十字弩的终极梦想。",
                    Info = "Deploy: Damage an Enemy and up to 4 other random Enemies with the same Power by 1. Fresh Crew: Repeat the Deploy ability.",
                    CardArtsId = "12230100",
                }
            },
            {
                "44018",//攻城槌
                new GwentCard()
                {
                    CardId ="44018",
                    Name="Battering Ram",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine},
                    Flavor = "不肯开门是吧？那我们就再加把劲敲一敲啰。",
                    Info = "Deal 3 damage. If the unit was destroyed, deal 3 damage to another unit. Crewed: Increase initial damage by 1.",
                    CardArtsId = "20004900",
                }
            },
            {
                "44019",//攻城大师
                new GwentCard()
                {
                    CardId ="44019",
                    Name="Siege Master",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Kaedwen,Categorie.Support},
                    CrewCount = 1,
                    Flavor = "我绝不会失手两次。",
                    Info = "Heal an allied Bronze or Silver Machine and repeat its ability. Crew.",
                    CardArtsId = "12231800",
                }
            },
            {
                "44020",//可怜的步兵
                new GwentCard()
                {
                    CardId ="44020",
                    Name="Poor Fucking Infantry",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Temeria},
                    Flavor = "看在我是老兵的份上！打赏个一克朗吧？",
                    Info = "Spawn Left Flank Infantry and Right Flank Infantry to the left and right of this unit, respectively.",
                    CardArtsId = "12230510",
                }
            },
            {
                "44021",//掠夺者猎人
                new GwentCard()
                {
                    CardId ="44021",
                    Name="Reaver Hunter",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Redania,Categorie.Soldier},
                    Flavor = "看见这纹身没？纹的是我在痛扁一条龙。一条龙哟，女士。",
                    Info = "Boost all copies of this unit by 1, wherever they are. Repeat its ability whenever a copy of this unit is played.",
                    CardArtsId = "12230610",
                }
            },
            {
                "44022",//泰莫利亚鼓手
                new GwentCard()
                {
                    CardId ="44022",
                    Name="Temerian Drummer",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support,Categorie.Temeria},
                    Flavor = "他告诉妈妈，自己想当个音乐家。只是没料到演奏的是这种乐器。",
                    Info = "Boost an ally by 6.",
                    CardArtsId = "20029900",
                }
            },
            {
                "44023",//褐旗营
                new GwentCard()
                {
                    CardId ="44023",
                    Name="Dun Banner Light Cavalry",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Kaedwen},
                    Flavor = "冷静，所有人保持警惕！这可能是那帮披斗篷戴海狸皮帽的家伙的陷阱……",
                    Info = "If you are losing by more than 25 on turn start, Summon this unit to a random row.",
                    CardArtsId = "12231300",
                }
            },
            {
                "44024",//科德温亡魂
                new GwentCard()
                {
                    CardId ="44024",
                    Name="Kaedweni Revenant",
                    Strength=4,
                    Countdown =1,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = true,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Kaedwen},
                    Flavor = "万劫不复的士兵日复一日地过着同一天，就好像奇安凡尼银行的职员一样。",
                    Info = "When you play your next Spell or Item, Spawn a Doomed default copy of this unit on its row. 1 Armor.",
                    CardArtsId = "20162400",
                }
            },
            {
                "44025",//中邪的女术士
                new GwentCard()
                {
                    CardId ="44025",
                    Name="Damned Sorceress",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Cursed},
                    Flavor = "萨宾娜的诅咒谁也不放过，就连其他的女术士也难以幸免。",
                    Info = "If there is a Cursed unit on this unit's row, deal 7 damage.",
                    CardArtsId = "20163000",
                }
            },
            {
                "44026",//艾瑞图萨学院学员
                new GwentCard()
                {
                    CardId ="44026",
                    Name="Aretuza Adept",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Temeria},
                    Flavor = "这些女学员在艾瑞图萨活得像公主一样，任何怪诞的想法都能得到满足，同时半个城市都在服务于她们：裁缝、帽商、糖果商、贩夫走卒……",
                    Info = "Play a random Bronze Hazard card from your Deck.",
                    CardArtsId = "20003300",
                }
            },
            {
                "44027",//蓝衣铁卫突击队
                new GwentCard()
                {
                    CardId ="44027",
                    Name="Blue Stripe Commando",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Temeria},
                    Flavor = "我愿为泰莫利亚赴汤蹈火，不过大多时候是在排除异己。",
                    Info = "Whenever a different Temerian ally with the same power is played, Summon a copy of this unit from your deck.",
                    CardArtsId = "12231110",
                }
            },
            {
                "44028",//蓝衣铁卫斥候
                new GwentCard()
                {
                    CardId ="44028",
                    Name="Blue Stripe Scout",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Temeria},
                    CrewCount = 1,
                    Flavor = "蓝衣铁卫与松鼠党有个共通点——满心仇恨。",
                    Info = "Boost all Temerian allies and your non-Spying Temerian units in hand and deck with the same power as this unit by 1. Crew.",
                    CardArtsId = "12231000",
                }
            },
            {
                "44029",//泰莫利亚步兵
                new GwentCard()
                {
                    CardId ="44029",
                    Name="Temerian Infantry",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Temeria},
                    Flavor = "泰莫利亚！泰莫利亚！诸神恩赐汝等！降怒于敌，使其永世灾厄！",
                    Info = "Summon all copies of this unit.",
                    CardArtsId = "12231610",
                }
            },
            {
                "44030",//女巫猎人
                new GwentCard()
                {
                    CardId ="44030",
                    Name="Witch Hunter",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Redania,Categorie.Soldier},
                    Flavor = "女巫猎人都是些什么人？大部分都是流氓无赖、狂热分子。然而看到女术士集会所犯下的肮脏罪行，不少怒不可遏的体面人也加入了他们的行列……",
                    Info = "Reset a Unit. If it's a Mage, play another Witch Hunter from your Deck.",
                    CardArtsId = "20013200",
                }
            },
            {
                "44031",//受折磨的法师
                new GwentCard()
                {
                    CardId ="44031",
                    Name="Tormented Mage",
                    Strength=2,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Cursed},
                    Flavor = "萨宾娜·葛丽维希格的诅咒摧枯拉朽。面对这股怒火，就连法师们也束手无策。",
                    Info = "Look at 2 Bronze Spells or Items from your deck, then play 1.",
                    CardArtsId = "20162800",
                }
            },
            {
                "44032",//掠夺者斥候
                new GwentCard()
                {
                    CardId ="44032",
                    Name="Reaver Scout",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Redania,Categorie.Support},
                    Flavor = "最近没怪兽可杀，所以我们从军了。",
                    Info = "Choose a different Bronze ally and play a copy of it from your deck.",
                    CardArtsId = "12230700",
                }
            },
            {
                "44033",//绞盘
                new GwentCard()
                {
                    CardId ="44033",
                    Name="Winch",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Tactic,Categorie.Special},
                    Flavor = "就是一个绞盘。没什么可大惊小怪的。",
                    Info = "Boost all machines on your side of the board by 3.",
                    CardArtsId = "20165900",
                }
            },
            {
                "44034",//染血连枷
                new GwentCard()
                {
                    CardId ="44034",
                    Name="Bloody Flail",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Item},
                    Flavor = "有些武器在整个北方领域都禁止使用。因为它们所造成的伤害超出了人们的想象。",
                    Info = "Deal 5 damage and Spawn a Specter.",
                    CardArtsId = "20150300",
                }
            },
            {
                "45001",//鬼灵
                new GwentCard()
                {
                    CardId ="45001",
                    Name="Specter",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Token},
                    Flavor = "身陷无尽的战斗，却早已忘记了起因。",
                    Info = "No Ability.",
                    CardArtsId = "20045700",
                }
            },
            {
                "45002",//左侧翼步兵
                new GwentCard()
                {
                    CardId ="45002",
                    Name="Left Flank Infantry",
                    Strength=2,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Temeria,Categorie.Token},
                    Flavor = "看在我是老兵的份上！打赏个一克朗吧？",
                    Info = "No Ability.",
                    CardArtsId = "12230500",
                }
            },
            {
                "45003",//右侧翼步兵
                new GwentCard()
                {
                    CardId ="45003",
                    Name="Right Flank Infantry",
                    Strength=2,
                    Group=Group.Copper,
                    Faction = Faction.NorthernRealms,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Temeria,Categorie.Token},
                    Flavor = "看在我是老兵的份上！打赏个一克朗吧？",
                    Info = "No Ability.",
                    CardArtsId = "12230520",
                }
            },
            {
                "51001",//法兰茜丝卡
                new GwentCard()
                {
                    CardId ="51001",
                    Name="Francesca Findabair",
                    Strength=7,
                    Group=Group.Leader,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Mage,Categorie.Elf},
                    Flavor = "世上没有轻而易举的和平，人类的压迫终将画下残酷的句点。",
                    Info = "Swap a card with one of your choice and boost it by 3.",
                    CardArtsId = "14110100",
                }
            },
            {
                "51002",//艾思娜
                new GwentCard()
                {
                    CardId ="51002",
                    Name="Eithné",
                    Strength=5,
                    Group=Group.Leader,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Dryad},
                    Flavor = "树精女王眼似融银，心如冷钢。",
                    Info = "Resurrect a Bronze or Silver special card.",
                    CardArtsId = "14110200",
                }
            },
            {
                "51003",//菲拉凡德芮
                new GwentCard()
                {
                    CardId ="51003",
                    Name="Filavandrel",
                    Strength=4,
                    Group=Group.Leader,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Elf},
                    Flavor = "虽然我们人数不多、四散分离，但我们的内心燃烧得比任何时候都要炽热。",
                    Info = "Create a Silver special card.",
                    CardArtsId = "20007500",
                }
            },
            {
                "51004",//布罗瓦尔·霍格
                new GwentCard()
                {
                    CardId ="51004",
                    Name="Brouver Hoog",
                    Strength=4,
                    Group=Group.Leader,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.Dwarf},
                    Flavor = "那个老糊涂？你甚至分不清他是活人还是木偶！",
                    Info = "Play a non-Spying Silver unit or a Bronze Dwarf from your deck.",
                    CardArtsId = "14110300",
                }
            },
            {
                "52001",//萨琪亚
                new GwentCard()
                {
                    CardId ="52001",
                    Name="Saskia",
                    Strength=11,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Aedirn,Categorie.Draconid},
                    Flavor = "王权于我毫无意义，只有东方那位才配为尊。",
                    Info = "Swap 2 cards with 2 Bronze cards.",
                    CardArtsId = "20020900",
                }
            },
            {
                "52002",//萨琪亚萨司
                new GwentCard()
                {
                    CardId ="52002",
                    Name="Saesenthessis",
                    Strength=10,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Aedirn,Categorie.Draconid},
                    Flavor = "我继承了父亲的变身能力……好吧，尽管我只有一种变化形态。",
                    Info = "Boost self by 1 for each Dwarf ally and deal 1 damage to an enemy for each Elf ally.",
                    CardArtsId = "14210100",
                }
            },
            {
                "52003",//泽维尔·莫兰
                new GwentCard()
                {
                    CardId ="52003",
                    Name="Xavier Moran",
                    Strength=10,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Dwarf},
                    Flavor = "怎么了，公主？吃不惯野味吗？嗯？",
                    Info = "Boost this unit by the starting power of the last different Dwarf you played.",
                    CardArtsId = "20008000",
                }
            },
            {
                "52004",//艾格莱丝
                new GwentCard()
                {
                    CardId ="52004",
                    Name="Aglaïs",
                    Strength=8,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Dryad},
                    Flavor = "布洛克莱昂在滴血……可就连我也无能为力。",
                    Info = "Resurrect a Bronze or Silver special card from your opponent's graveyard, then Banish it.",
                    CardArtsId = "14210600",
                }
            },
            {
                "52005",//卓尔坦·齐瓦
                new GwentCard()
                {
                    CardId ="52005",
                    Name="Zoltan Chivay",
                    Strength=8,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Dwarf},
                    HideTags = new HideTag[]{HideTag.Zoltan},
                    Flavor = "一人单独喝酒的滋味，就好比俩人一起蹲坑。",
                    Info = "Choose 3 units. Strengthen allies by 2 and move them to this unit's row. Damage enemies by 2 and move them to the opposite row.",
                    CardArtsId = "14210500",
                }
            },
            {
                "52006",//伊森格林
                new GwentCard()
                {
                    CardId ="52006",
                    Name="Isengrim Faoiltiarna",
                    Strength=7,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Elf,Categorie.Officer},
                    Flavor = "他们一见我的疤就知道：这下死定了。",
                    Info = "Play a Bronze or Silver Ambush from your Deck.",
                    CardArtsId = "14210200",
                }
            },
            {
                "52007",//伊欧菲斯
                new GwentCard()
                {
                    CardId ="52007",
                    Name="Iorveth",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Elf,Categorie.Officer},
                    Flavor = "国王还是乞丐于我并无差别，人类少一个算一个。",
                    Info = "Deal 8 damage to an enemy. If the unit was destroyed, boost all Elves in your hand by 1.",
                    CardArtsId = "14210300",
                }
            },
            {
                "52008",//米尔瓦
                new GwentCard()
                {
                    CardId ="52008",
                    Name="Milva",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "每次拉弓射箭，我总想起父亲。他……应该会为我骄傲吧。",
                    Info = "Return each player's Highest Bronze or Silver unit to their deck.",
                    CardArtsId = "14210400",
                }
            },
            {
                "52009",//莫丽恩：森林之女
                new GwentCard()
                {
                    CardId ="52009",
                    Name="Morenn: Forest Child",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    IsConcealCard = true,
                    Categories = new Categorie[]{ Categorie.Dryad, Categorie.Ambush },
                    Flavor = "布洛克莱昂的意义远高于我的生命。她是一位母亲，关怀着自己的孩子们。我至死都要捍卫她。",
                    Info = "Ambush: When your opponent plays a Bronze or Silver special card, flip over and cancel its ability.",
                    CardArtsId = "20177900",
                }
            },
            {
                "52010",//希鲁
                new GwentCard()
                {
                    CardId ="52010",
                    Name="Schirrú",
                    Strength=4,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "直面死神的时候到了。",
                    Info = "Spawn Scorch or Epidemic.",
                    CardArtsId = "14210800",
                }
            },
            {
                "52011",//伊斯琳妮
                new GwentCard()
                {
                    CardId ="52011",
                    Name="Ithlinne Aegli",
                    Strength=2,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Elf},
                    Flavor = "她因不断预言世界末日而闻名遐迩——那些可不是什么好玩言论。",
                    Info = "Play a Bronze Spell, Boon or Hazard from your deck twice.",
                    CardArtsId = "14210700",
                }
            },
            {
                "52012",//伊欧菲斯：冥想
                new GwentCard()
                {
                    CardId ="52012",
                    Name="Iorveth: Meditation",
                    Strength=2,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Elf,Categorie.Officer},
                    Flavor = "即使伊欧菲斯只剩一只眼睛，他内心的洞察力也无人能及。",
                    Info = "Force 2 enemies on the same row to Duel each other.",
                    CardArtsId = "20161100",
                }
            },
            {
                "52013",//伊森格林：亡命徒
                new GwentCard()
                {
                    CardId ="52013",
                    Name="Isengrim: Outlaw",
                    Strength=2,
                    Group=Group.Gold,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Elf,Categorie.Officer},
                    Flavor = "在我们眼前的便是艾尔斯克德格山道，再往前，就是瑟瑞卡尼亚和哈克兰。这将是一条漫长而危险的道路。要想一同走下去，我们就得摒除彼此的猜忌。",
                    Info = "Choose One: Play a Bronze or Silver special card from your deck; or Create a Silver Elf.",
                    CardArtsId = "20161500",
                }
            },
            {
                "53001",//亚伊文
                new GwentCard()
                {
                    CardId ="53001",
                    Name="Yaevinn",
                    Strength=13,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Elf,Categorie.Agent},
                    Flavor = "我们是汇成风暴的雨滴。",
                    Info = "Spying. Single-Use. Draw a special card and a unit. Keep one and return the other to your deck.",
                    CardArtsId = "14220300",
                }
            },
            {
                "53002",//艾雷亚斯
                new GwentCard()
                {
                    CardId ="53002",
                    Name="Ele'yas",
                    Strength=10,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "只要出于爱，疯狂就是合理的。",
                    Info = "Whenever you draw this unit or return it to your deck, boost self by 2. ",
                    CardArtsId = "14221400",
                }
            },
            {
                "53003",//席朗·依斯尼兰
                new GwentCard()
                {
                    CardId ="53003",
                    Name="Ciaran aep Easnillen",
                    Strength=9,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "通往自由的路由鲜血铺就，而非墨水写成。",
                    Info = "Toggle a unit's Lock status and move it to this unit's row on its side.",
                    CardArtsId = "14220600",
                }
            },
            {
                "53004",//谢尔顿·斯卡格斯
                new GwentCard()
                {
                    CardId ="53004",
                    Name="Sheldon Skaggs",
                    Strength=9,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Dwarf,Categorie.Officer},
                    Flavor = "我可是在战况最激烈的前线！",
                    Info = "Move all allies on this unit's row to random rows and boost self by 1 for each.",
                    CardArtsId = "14221200",
                }
            },
            {
                "53005",//丹尼斯·克莱默
                new GwentCard()
                {
                    CardId ="53005",
                    Name="Dennis Cranmer",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Dwarf,Categorie.Officer},
                    Flavor = "我知道如何执行命令，冲别人去说教吧。",
                    Info = "Strengthen all your Dwarves by 1, wherever they are.",
                    CardArtsId = "14220100",
                }
            },
            {
                "53006",//莫丽恩
                new GwentCard()
                {
                    CardId ="53006",
                    Name="Morenn",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    IsConcealCard = true,
                    Categories = new Categorie[]{ Categorie.Dryad,Categorie.Ambush},
                    Flavor = "艾思娜女士的女儿继承了她无与伦比的美貌，也同样极端仇视与人类有关的一切。",
                    Info = "Ambush: When a unit is played from either hand on your opponent's side, flip over and deal 7 damage to that unit.",
                    CardArtsId = "14220800",
                }
            },
            {
                "53007",//亚尔潘·齐格林
                new GwentCard()
                {
                    CardId ="53007",
                    Name="Yarpen Zigrin",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Dwarf},
                    Flavor = "听说过巨龙奥克维斯塔吗？石英山那只？亚尔潘·齐格林与他的矮人同伴们把它解决了。",
                    Info = "Resilience. Whenever a Dwarf ally appears, boost self by 1.",
                    CardArtsId = "14221300",
                }
            },
            {
                "53008",//玛丽娜
                new GwentCard()
                {
                    CardId ="53008",
                    Name="Malena",
                    Strength=7,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    IsConcealCard = true,
                    Categories = new Categorie[]{ Categorie.Elf, Categorie.Ambush },
                    Flavor = "我恨你们，人类。你们全都一个样。",
                    Info = "Ambush: After 2 turns, flip over and Charm the Highest Bronze or Silver enemy with 5 power or less.",
                    CardArtsId = "14221000",
                }
            },
            {
                "53009",//爱黎瑞恩
                new GwentCard()
                {
                    CardId ="53009",
                    Name="Aelirenn",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Elf,Categorie.Officer},
                    Flavor = "苟活不如好死。",
                    Info = "When 5 Elven allies are on the board, Summon this unit.",
                    CardArtsId = "14221100",
                }
            },
            {
                "53010",//布蕾恩
                new GwentCard()
                {
                    CardId ="53010",
                    Name="Braenn",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Dryad},
                    Flavor = "莫娜？不，不。我是布蕾恩。布洛克莱昂的女儿。",
                    Info = "Deal damage equal to this unit's power. If a unit was destroyed, boost all your Dryad and Ambush units by 1, wherever they are.",
                    CardArtsId = "14220900",
                }
            },
            {
                "53011",//托露薇尔
                new GwentCard()
                {
                    CardId ="53011",
                    Name="Toruviel",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    IsConcealCard = true,
                    Categories = new Categorie[]{ Categorie.Elf,Categorie.Officer,Categorie.Ambush},
                    Flavor = "我很乐意站在你面前，直视你的双眼然后干掉你……但你臭死了，人类。",
                    Info = "Ambush: When your opponent passes, turn this Unit over and Boost 2 Units on each side by 2.",
                    CardArtsId = "14220400",
                }
            },
            {
                "53012",//帕扶科“舅舅”盖尔
                new GwentCard()
                {
                    CardId ="53012",
                    Name="Pavko Gale",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier},
                    Flavor = "为蓝山的精灵走私粮食最多的人当属盖尔。他为他们带来了一袋袋芜菁，还有最最珍贵的韭葱，因此被亲切地称为“舅舅”。",
                    Info = "Play a Bronze or Silver Item from your deck.",
                    CardArtsId = "20167600",
                }
            },
            {
                "53013",//艾达·艾敏
                new GwentCard()
                {
                    CardId ="53013",
                    Name="Ida Emean aep Sivney",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Elf},
                    Flavor = "我是名贤者。我的力量源于占有知识，而非传播知识。",
                    Info = "Spawn Impenetrable Fog, Clear Skies or Alzur's Thunder.",
                    CardArtsId = "14220200",
                }
            },
            {
                "53014",//麦莉
                new GwentCard()
                {
                    CardId ="53014",
                    Name="Milaen",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Elf},
                    Flavor = "老男爵对待偷猎者向来毫不留情。幸亏麦莉运气够好，老男爵已经死了，他的手下也成了亡命之徒。",
                    Info = "Deal 6 damage to the units at the end of a row.",
                    CardArtsId = "6010300",
                }
            },
            {
                "53015",//哈托利
                new GwentCard()
                {
                    CardId ="53015",
                    Name="Éibhear Hattori",
                    Strength=3,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Elf,Categorie.Support,Categorie.Doomed},
                    Flavor = "只有一样东西能和他打造的长剑相媲美——他包的饺子。",
                    Info = "Resurrect a lower or equal Bronze or Silver Scoia'tael unit.",
                    CardArtsId = "20052000",
                }
            },
            {
                "53016",//保利·达尔伯格
                new GwentCard()
                {
                    CardId ="53016",
                    Name="Paulie Dahlberg",
                    Strength=3,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support,Categorie.Dwarf,Categorie.Doomed},
                    Flavor = "快走！这是个该死的陷阱！",
                    Info = "Resurrect a non-Support Bronze Dwarf.",
                    CardArtsId = "20169600",
                }
            },
            {
                "53017",//巴克莱·艾尔斯
                new GwentCard()
                {
                    CardId ="53017",
                    Name="Barclay Els",
                    Strength=2,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Dwarf,Categorie.Officer},
                    Flavor = "嫌我们的蜂蜜酒味道不好？好办，堵住你的鼻子就行了！",
                    Info = "Play a random Bronze or Silver Dwarf from your deck and Strengthen it by 3.",
                    CardArtsId = "14220700",
                }
            },
            {
                "53018",//莫拉纳符文石
                new GwentCard()
                {
                    CardId ="53018",
                    Name="Morana Runestone",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "一看到它我就头晕……",
                    Info = "Create and play a bronze Scoia'tael card.",
                    CardArtsId = "20158500",
                }
            },
            {
                "53019",//自然的馈赠
                new GwentCard()
                {
                    CardId ="53019",
                    Name="Nature's Gift",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "你们贪得无厌地榨干大地，野蛮强横地攫取它的财富。但在我们这儿，它生机勃勃，春华秋实，慷慨大方。因为它爱我们，正如我们爱它。",
                    Info = "Play a Bronze or Silver Special card from your Deck. Shuffle the others back.",
                    CardArtsId = "14320100",
                }
            },
            {
                "53020",//陷坑
                new GwentCard()
                {
                    CardId ="53020",
                    Name="Pit Trap",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Item},
                    Flavor = "简单、廉价，又十分好用。难怪它是松鼠党最喜欢用的一种陷阱。",
                    Info = "Apply a Hazard to an enemy row that deals 3 damage to units on contact.",
                    CardArtsId = "20149000",
                }
            },
            {
                "53021",//玛哈坎号角
                new GwentCard()
                {
                    CardId ="53021",
                    Name="Mahakam Horn",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Item},
                    Flavor = "从前，玛哈坎举办过一次吹号角比赛。那一天，矮人们学到了重要的一课：不要在积雪殷厚的雪上下大声吹号。",
                    Info = "Choose One: Create a Bronze or Silver Dwarf; or Strengthen a unit by 7.",
                    CardArtsId = "20153700",
                }
            },
            {
                "54001",//维里赫德旅工兵
                new GwentCard()
                {
                    CardId ="54001",
                    Name="Vrihedd Sappers",
                    Strength=11,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    Countdown = 2,
                    IsDerive = false,
                    IsConcealCard = true,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf,Categorie.Ambush},
                    Flavor = "不管流言怎么说，精灵才不会碰人类的头皮。因为虱子太多了。",
                    Info = "Ambush: After 2 turns, flip over. ",
                    CardArtsId = "14230700",
                }
            },
            {
                "54002",//精灵斥候
                new GwentCard()
                {
                    CardId ="54002",
                    Name="Elven Scout",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "他们说精灵踏雪无痕。不过要我说，“他们”不过是一帮住在乡下的白痴，就知道胡说八道。",
                    Info = "Swap a card.",
                    CardArtsId = "20143800",
                }
            },
            {
                "54003",//维里赫德旅新兵
                new GwentCard()
                {
                    CardId ="54003",
                    Name="Vrihedd Neophyte",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "许多非人种族在城市里饱受歧视和排斥，于是决定加入松鼠党。",
                    Info = "Boost 2 random units in your hand by 1.",
                    CardArtsId = "14240100",
                }
            },
            {
                "54004",//维里赫德旅
                new GwentCard()
                {
                    CardId ="54004",
                    Name="Vrihedd Brigade",
                    Strength=9,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "“维里赫德旅？那是什么？”“麻烦。”",
                    Info = "Clear Hazards from its row and move a unit to this row on its side.",
                    CardArtsId = "14230200",
                }
            },
            {
                "54005",//矮人佣兵
                new GwentCard()
                {
                    CardId ="54005",
                    Name="Dwarven Mercenary",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Dwarf},
                    Flavor = "工作就该既有趣又赚钱——比如拿悬赏换金子。",
                    Info = "Move a unit to this row on its side. If it's an ally, boost it by 3.",
                    CardArtsId = "14231100",
                }
            },
            {
                "54006",//先知
                new GwentCard()
                {
                    CardId ="54006",
                    Name="Farseer",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Elf},
                    Flavor = "有时候，他的话语听似令人费解，但其中总是蕴藏着深邃的道理和惊人的智慧。",
                    Info = "If a different Ally or Unit in your Hand is Boosted during your turn, Boost self by 2 at the end of the turn.",
                    CardArtsId = "20013600",
                }
            },
            {
                "54007",//维里赫德旅骑兵
                new GwentCard()
                {
                    CardId ="54007",
                    Name="Vrihedd Dragoon",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "我见过的最可怕的场景？卡特利欧纳瘟疫、范格堡被夷为平地，还有维里赫德旅骑兵的冲锋。",
                    Info = "Boost a random loyal unit in your hand by 1 on turn end.",
                    CardArtsId = "14220500",
                }
            },
            {
                "54008",//多尔·布雷坦纳弓箭手
                new GwentCard()
                {
                    CardId ="54008",
                    Name="Dol Blathanna Archer",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "再走一步试试，人类。你眉宇间插根箭肯定好看得多。",
                    Info = "Deal 3 damage, then deal 1 damage.",
                    CardArtsId = "14231000",
                }
            },
            {
                "54009",//多尔·布雷坦纳射手
                new GwentCard()
                {
                    CardId ="54009",
                    Name="Dol Blathanna Bowman",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "也许你能躲过他们，但要被发现了，就别浪费时间逃跑了。",
                    Info = "Deal 2 damage to an enemy. Whenever an enemy moves, deal 2 damage to it. Whenever this unit moves, deal 2 damage to a random enemy.",
                    CardArtsId = "14231400",
                }
            },
            {
                "54010",//私枭走私者
                new GwentCard()
                {
                    CardId ="54010",
                    Name="Hawker Smuggler",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Elf,Categorie.Support},
                    Flavor = "谁付的钱多我就给谁卖命，不然就挑个最容易抢的去抢。",
                    Info = "Whenever an enemy appears, boost self by 1.",
                    CardArtsId = "14231500",
                }
            },
            {
                "54011",//私枭后援者
                new GwentCard()
                {
                    CardId ="54011",
                    Name="Hawker Support",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Elf,Categorie.Support},
                    Flavor = "矮人和精灵在我眼里都一样，给钱就行。",
                    Info = "Boost a unit in your hand by 3.",
                    CardArtsId = "14231200",
                }
            },
            {
                "54012",//玛哈坎劫掠者
                new GwentCard()
                {
                    CardId ="54012",
                    Name="Mahakam Marauder",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Dwarf},
                    Flavor = "在玛哈坎崎岖的悬崖峭壁上狩猎可不是件简单事……但矮人们也从不轻易向危险低头。",
                    Info = "Whenever this Unit is Boosted, Damaged, Strengthened or Weakened, Boost it by 2.",
                    CardArtsId = "20004200",
                }
            },
            {
                "54013",//维里赫德旅先锋
                new GwentCard()
                {
                    CardId ="54013",
                    Name="Vrihedd Vanguard",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "管他泰莫利亚人还是瑞达尼亚人，杀无赦。",
                    Info = "Boost Elf allies by 1. Whenever you Swap this card, trigger its ability.",
                    CardArtsId = "14230900",
                }
            },
            {
                "54014",//多尔·布雷坦纳爆破手
                new GwentCard()
                {
                    CardId ="54014",
                    Name="Dol Blathanna Bomber",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "他们的追踪本领犹如猎犬，双腿健似矫鹿，残忍更胜恶魔。",
                    Info = "Spawn an Incinerating Trap on an enemy row. ",
                    CardArtsId = "14230400",
                }
            },
            {
                "54015",//矮人好斗分子
                new GwentCard()
                {
                    CardId ="54015",
                    Name="Dwarven Skirmisher",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Dwarf},
                    Flavor = "我跟十字镐打了一辈子交道，动动斧头算什么问题？",
                    Info = "Deal 3 damage to an enemy. If the unit was not destroyed, boost self by 3.",
                    CardArtsId = "14230500",
                }
            },
            {
                "54016",//玛哈坎捍卫者
                new GwentCard()
                {
                    CardId ="54016",
                    Name="Mahakam Defender",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Dwarf},
                    Flavor = "听好了，我们是天生的战士——拳拳到肉，绝不留情！",
                    Info = "Resilient.",
                    CardArtsId = "14230600",
                }
            },
            {
                "54017",//半精灵猎人
                new GwentCard()
                {
                    CardId ="54017",
                    Name="Half-Elf Hunter",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "被人类痛恨，被精灵唾骂，而且学校操场上谁都不肯带他们玩。难怪半精灵一肚子委屈。",
                    Info = "Spawn a Doomed default copy of this unit.",
                    CardArtsId = "20163600",
                }
            },
            {
                "54018",//私枭治疗者
                new GwentCard()
                {
                    CardId ="54018",
                    Name="Hawker Healer",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Elf,Categorie.Support},
                    Flavor = "帮你包扎，没问题——只要你有钱。",
                    Info = "Deploy: Boost 2 Allies by 3.",
                    CardArtsId = "14230100",
                }
            },
            {
                "54019",//烟火技师
                new GwentCard()
                {
                    CardId ="54019",
                    Name="Pyrotechnician",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Dwarf},
                    Flavor = "在玛哈坎，这份行当的风险非同一般，因此回报也异常优厚。其中最负盛名的行业翘楚，当数那位名叫麦柯尔·贝的矮人。",
                    Info = "Deal 3 damage to a random enemy on each row.",
                    CardArtsId = "20013500",
                }
            },
            {
                "54020",//维里赫德旅军官
                new GwentCard()
                {
                    CardId ="54020",
                    Name="Vrihedd Officer",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Elf,Categorie.Officer},
                    Flavor = "“仇恨之火比地狱烈焰更猛烈，比任何伤口都更刻骨铭心。”",
                    Info = "Swap a card and boost self by its base power.",
                    CardArtsId = "14230300",
                }
            },
            {
                "54021",//精灵剑术大师
                new GwentCard()
                {
                    CardId ="54021",
                    Name="Elven Swordmaster",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "战斗如同舞蹈，千万不能让你的对手领舞。",
                    Info = "Deal damage equal to this unit's power.",
                    CardArtsId = "20156400",
                }
            },
            {
                "54022",//玛哈坎守卫
                new GwentCard()
                {
                    CardId ="54022",
                    Name="Mahakam Guard",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Dwarf},
                    Flavor = "破坏玛哈坎的和平只有一种下场：一记重锤。",
                    Info = "Boost an ally by 7.",
                    CardArtsId = "14231700",
                }
            },
            {
                "54023",//黑豹
                new GwentCard()
                {
                    CardId ="54023",
                    Name="Panther",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    Flavor = "曾经有位牛堡学者在观察一只黑豹后，宣称它不过是颜色不同的花豹而已。黑豹貌似对这一说法毫不关心。他还没等学者完成研究，就把他狼吞虎咽地吃下了肚。",
                    Info = "Deal 7 damage to an enemy on a row with less than 4 units.",
                    CardArtsId = "20013900",
                }
            },
            {
                "54024",//战舞者
                new GwentCard()
                {
                    CardId ="54024",
                    Name="Wardancer",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "你说那个女精灵在大家打得不可开交时跳起舞来了？你疯了吗，下士？！",
                    Info = "Whenever you Swap this unit, play it automatically on a random row.",
                    CardArtsId = "14231300",
                }
            },
            {
                "54025",//蓝山精锐
                new GwentCard()
                {
                    CardId ="54025",
                    Name="Blue Mountain Elite",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "听到他们奔袭的动静时，想跑已来不及了……",
                    Info = "Summon all copies of this unit. Whenever this unit moves, boost self by 2.",
                    CardArtsId = "14231600",
                }
            },
            {
                "54026",//玛哈坎志愿军
                new GwentCard()
                {
                    CardId ="54026",
                    Name="Mahakam Volunteers",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Dwarf},
                    Flavor = "呼啊！呼啊！把你们的屁股准备好！我们要狠狠地踹一脚！踢得你们夹着尾巴到处跑！",
                    Info = "Summon all copies of this unit.",
                    CardArtsId = "20155900",
                }
            },
            {
                "54027",//多尔·布雷坦纳哨兵
                new GwentCard()
                {
                    CardId ="54027",
                    Name="Dol Blathanna Sentry",
                    Strength=2,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "只要我们一息尚存，就绝不容许人类践踏多尔·布雷坦纳的绿荫。",
                    Info = "If in hand, deck or on board, boost self by 1 whenever you play a special card.",
                    CardArtsId = "20003900",
                }
            },
            {
                "54028",//贤者
                new GwentCard()
                {
                    CardId ="54028",
                    Name="Sage",
                    Strength=2,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage,Categorie.Elf},
                    Flavor = "亲爱的，知识，乃是一种特权。而特权，只能被实力相当的人所分享。",
                    Info = "Resurrect a Bronze Alchemy or Spell card, then Banish it.",
                    CardArtsId = "20013800",
                }
            },
            {
                "54029",//矮人煽动分子
                new GwentCard()
                {
                    CardId ="54029",
                    Name="Dwarven Agitator",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support,Categorie.Dwarf},
                    Flavor = "“记住我说的话，如果你们不行动起来，人类就会抢走我们的姑娘！”",
                    Info = "Spawn a default copy of a random different Bronze Dwarf from your Deck.",
                    CardArtsId = "20029300",
                }
            },
            {
                "54030",//精灵佣兵
                new GwentCard()
                {
                    CardId ="54030",
                    Name="Elven Mercenary",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.Elf},
                    Flavor = "我瞧不起松鼠党，但不讨厌他们的钱。",
                    Info = "Look at 2 random Bronze special cards from your deck, then play 1.",
                    CardArtsId = "14230800",
                }
            },
            {
                "54031",//精灵利剑
                new GwentCard()
                {
                    CardId ="54031",
                    Name="Elven Blade",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Item},
                    Flavor = "精灵的利剑轻盈，却能造成重伤。",
                    Info = "Deal 10 damage to a non-Elf unit.",
                    CardArtsId = "20151100",
                }
            },
            {
                "54032",//碎骨陷阱
                new GwentCard()
                {
                    CardId ="54032",
                    Name="Crushing Trap",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Item},
                    Flavor = "要是被它击倒，你就别想在爬起来了。",
                    Info = "Deal 6 damage to the units at the end of an enemy row.",
                    CardArtsId = "20143900",
                }
            },
            {
                "55001",//焚烧陷阱
                new GwentCard()
                {
                    CardId ="55001",
                    Name="Incinerating Trap",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.ScoiaTael,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = true,
                    Countdown = 1,//冷却1
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Machine,Categorie.Token},
                    Flavor = "小心……！再走一步，你就要被化成青烟了。",
                    Info = "Damage all units on its row by 2 on turn end",
                    CardArtsId = "14330100",
                }
            },
            {
                "62001",//奥拉夫
                new GwentCard()
                {
                    CardId ="62001",
                    Name="Olaf",
                    Strength=20,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Cursed},
                    Flavor = "备受敬仰的小史凯利格岛竞技场十冠王。",
                    Info = "Deal 10 damage to self. Reduce the damage inflicted by 2 for each Beast you played this match.",
                    CardArtsId = "20010300",
                }
            },
            {
                "62002",//哈尔玛·奎特
                new GwentCard()
                {
                    CardId ="62002",
                    Name="Hjalmar an Craite",
                    Strength=16,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanAnCraite,Categorie.Officer},
                    Flavor = "別为死者哭泣，敬他们一杯吧！",
                    Info = "Spawn the Lord of Undvik on the opposite row.",
                    CardArtsId = "15210100",
                }
            },
            {
                "62003",//维伯约恩
                new GwentCard()
                {
                    CardId ="62003",
                    Name="Vabjorn",
                    Strength=11,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Cultist},
                    Flavor = "为了斯瓦勃洛！",
                    Info = "Deal 2 damage. If the unit was already damaged , destroy it instead.",
                    CardArtsId = "20002800",
                }
            },
            {
                "62004",//莫斯萨克
                new GwentCard()
                {
                    CardId ="62004",
                    Name="Ermion",
                    Strength=10,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support,Categorie.ClanAnCraite},
                    Flavor = "无知者才会轻视神话。",
                    Info = "Draw 2 cards, then Discard 2 cards.",
                    CardArtsId = "15210300",
                }
            },
            {
                "62005",//海上野猪
                new GwentCard()
                {
                    CardId ="62005",
                    Name="Wild Boar of the Sea",
                    Strength=8,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanAnCraite},
                    Flavor = "只消对尼弗迦德人提起这个名字，他们就会吓得尿裤子……",
                    Info = "On turn end, Strengthen the unit to the left by 1, then deal 1 damage to the unit to the right. 5 Armor.",
                    CardArtsId = "15210900",
                }
            },
            {
                "62006",//碧尔娜·布兰
                new GwentCard()
                {
                    CardId ="62006",
                    Name="Birna Bran",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanTuirseach,Categorie.Officer},
                    Flavor = "史凯利格需要一位强大的国王，无论付出何等代价。",
                    Info = "Apply Skellige Storm to an enemy row.",
                    CardArtsId = "15210500",
                }
            },
            {
                "62007",//凯瑞丝·奎特
                new GwentCard()
                {
                    CardId ="62007",
                    Name="Cerys an Craite",
                    Strength=6,
                    Group=Group.Gold,
                    Countdown =4,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = true,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanAnCraite,Categorie.Officer},
                    Flavor = "大家叫我小雀鹰，知道为什么吗？因为我专治你这种鼠辈。",
                    Info = "When 4 units are Resurrected while this unit is in the graveyard, Resurrect it.",
                    CardArtsId = "20017700",
                }
            },
            {
                "62008",//“疯子”卢戈
                new GwentCard()
                {
                    CardId ="62008",
                    Name="Madman Lugos",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanDrummond,Categorie.Officer},
                    Flavor = "哇哇哇哇哇哇啊！！！！",
                    Info = "Deploy: Discard a Bronze Unit from your Deck and Damage a Unit by the Discarded Unit's base Power.",
                    CardArtsId = "15210600",
                }
            },
            {
                "62009",//乌弗海登
                new GwentCard()
                {
                    CardId ="62009",
                    Name="Ulfhedinn",
                    Strength=6,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Cursed},
                    Flavor = "狼人？哦，不，不……比那要糟糕得多。",
                    Info = "Deal 1 damage to all enemies. If the enemies were damaged, deal 2 damage instead.",
                    CardArtsId = "20010400",
                }
            },
            {
                "62010",//凯瑞丝：无所畏惧
                new GwentCard()
                {
                    CardId ="62010",
                    Name="Cerys: Fearless",
                    Strength=6,
                    Countdown =1,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = true,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanAnCraite,Categorie.Officer},
                    Flavor = "我必须要团结各大家族。我希望能够避免开战。但假如尼弗迦德执意来犯，那我们就一定要同仇敌忾。",
                    Info = "Resurrect the next unit your Discard.",
                    CardArtsId = "20177800",
                }
            },
            {
                "62011",//珊瑚
                new GwentCard()
                {
                    CardId ="62011",
                    Name="Coral",
                    Strength=5,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Mage},
                    Flavor = "她的真名是艾丝翠特·丽塔尼德·艾斯杰芬比约斯道提尔，这名字不管怎么念都拗口极了。",
                    Info = "Transform a Bronze or Silver unit into a Jade Figurine.",
                    CardArtsId = "15210700",
                }
            },
            {
                "62012",//希姆
                new GwentCard()
                {
                    CardId ="62012",
                    Name="Hym",
                    Strength=3,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed},
                    Flavor = "诸神对我说话……我听见他们在暗影中的私语……",
                    Info = "Choose One: Play a Bronze or Silver Cursed unit from your deck; or Create a Silver unit from your opponent's deck.",
                    CardArtsId = "20010200",
                }
            },
            {
                "62013",//坎比
                new GwentCard()
                {
                    CardId ="62013",
                    Name="Kambi",
                    Strength=1,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "终焉之刻来临时，金公鸡坎比便会叫醒沉睡的汉姆多尔。",
                    Info = "Deathwish: Spawn Hemdall. Spying.",
                    CardArtsId = "15210400",
                }
            },
            {
                "63001",//茱塔·迪门
                new GwentCard()
                {
                    CardId ="63001",
                    Name="Jutta an Dimun",
                    Strength=13,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanDimun},
                    Flavor = "有人称她“铁娘子”。",
                    Info = "Deal 1 damage to self.",
                    CardArtsId = "15220800",
                }
            },
            {
                "63002",//乌达瑞克
                new GwentCard()
                {
                    CardId ="63002",
                    Name="Udalryk",
                    Strength=13,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Agent,Categorie.ClanBrokvar},
                    Flavor = "诸神已经发话，必须献上祭品。",
                    Info = "Spying. Single-Use. Look at 2 cards from your deck. Draw one and Discard the other.",
                    CardArtsId = "15221400",
                }
            },
            {
                "63003",//邓戈·费特
                new GwentCard()
                {
                    CardId ="63003",
                    Name="Djenge Frett",
                    Strength=10,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanDimun},
                    Flavor = "如果通缉令上写着“无论死活”，绝大多数赏金猎人会直接快刀斩乱麻。但我不会。如果被我抓到，我会把人吊起来挠痒，让他笑到岔气。",
                    Info = "Deal 1 damage to 2 allies and Strengthen self by 2 for each.",
                    CardArtsId = "15220300",
                }
            },
            {
                "63004",//“阿蓝”卢戈
                new GwentCard()
                {
                    CardId ="63004",
                    Name="Blueboy Lugos",
                    Strength=9,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanDrummond,Categorie.Soldier},
                    Flavor = "我无聊得快吐了。",
                    Info = "Spawn a Spectral Whale on an enemy row.",
                    CardArtsId = "15220100",
                }
            },
            {
                "63005",//莫克瓦格
                new GwentCard()
                {
                    CardId ="63005",
                    Name="Morkvarg",
                    Strength=9,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Cursed},
                    Flavor = "史凯利格有史以来最大的恶人。",
                    Info = "Whenever this unit enter the graveyard, Resurrect it and Weaken it by half.",
                    CardArtsId = "15220900",
                }
            },
            {
                "63006",//斯凡瑞吉·图尔赛克
                new GwentCard()
                {
                    CardId ="63006",
                    Name="Svanrige Tuirseach",
                    Strength=9,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanTuirseach,Categorie.Officer},
                    Flavor = "皇帝最开始也认为自己登上皇位是出于偶然。",
                    Info = "Draw a card, then Discard a card.",
                    CardArtsId = "15221300",
                }
            },
            {
                "63007",//多纳·印达
                new GwentCard()
                {
                    CardId ="63007",
                    Name="Donar an Hinda",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanHeymaey,Categorie.Officer},
                    Flavor = "我已齐集众位族长，有话快说。",
                    Info = "Toggle a unit's Lock status, then move a Bronze unit from your opponent's graveyard to yours.",
                    CardArtsId = "15220400",
                }
            },
            {
                "63008",//大野猪
                new GwentCard()
                {
                    CardId ="63008",
                    Name="Giant Boar",
                    Strength=8,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast},
                    Flavor = "如果在林子里捡到一头硕大的野猪，大多数人会尿了裤子，手忙脚乱地朝最近的树上爬。史凯利格人不会。他们反回两眼发直，大流口水。",
                    Info = "Destroy a random ally, then boost self by 10.",
                    CardArtsId = "20162300",
                }
            },
            {
                "63009",//至尊冠军
                new GwentCard()
                {
                    CardId ="63009",
                    Name="Champion of Hov",
                    Strength=7,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Ogroid},
                    Flavor = "他只对打败他的人报上名讳，因为他是个巨魔游侠，懂吗？",
                    Info = "Duel an enemy.",
                    CardArtsId = "15220200",
                }
            },
            {
                "63010",//德莱格·波·德乌
                new GwentCard()
                {
                    CardId ="63010",
                    Name="Draig Bon-Dhu",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support},
                    Flavor = "竖起耳朵，来听上一听奎特家族的英雄事迹吧！",
                    Info = "Strengthen 2 units in your graveyard by 3.",
                    CardArtsId = "15220500",
                }
            },
            {
                "63011",//“黑手”霍格
                new GwentCard()
                {
                    CardId ="63011",
                    Name="Holger Blackhand",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanDimun,Categorie.Officer},
                    Flavor = "敬尼弗迦德皇帝，祝他不得善终！",
                    Info = "Deal 6 damage. If the unit was destroyed, Strengthen the Highest unit in your graveyard by 3.",
                    CardArtsId = "15220700",
                }
            },
            {
                "63012",//哈罗德·霍兹诺特
                new GwentCard()
                {
                    CardId ="63012",
                    Name="Harald Houndsnout",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.ClanTordarroch},
                    Flavor = "曾经是托达洛克家族的首领，如今只是一个喋喋不休的疯子。",
                    Info = "Spawn Wilfred to the left, Wilhelm to the right and Wilmar on the opposite row.",
                    CardArtsId = "20004300",
                }
            },
            {
                "63013",//尤娜
                new GwentCard()
                {
                    CardId ="63013",
                    Name="Yoana",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanTordarroch,Categorie.Support},
                    Flavor = "没人会把我当成一名老练的盔甲师傅。只是一个人类，而且还是个女人。可是矮人铁匠就不同了……",
                    Info = "Heal an ally, then boost it by the amount Healed.",
                    CardArtsId = "20164400",
                }
            },
            {
                "63014",//迪兰
                new GwentCard()
                {
                    CardId ="63014",
                    Name="Derran",
                    Strength=6,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.ClanTuirseach},
                    Flavor = "能引发这样的疯狂，相比是极其可怖的……",
                    Info = "Whenever an enemy is damaged, boost this unit by 1.",
                    CardArtsId = "6010400",
                }
            },
            {
                "63015",//史凯裘
                new GwentCard()
                {
                    CardId ="63015",
                    Name="Skjall",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.ClanHeymaey},
                    Flavor = "把他剔出族谱！不许任何人给他食物和庇护！",
                    Info = "Deploy: Play a random Bronze or Silver Cursed Unit from your Deck.",
                    CardArtsId = "20021200",
                }
            },
            {
                "63016",//格雷密斯特
                new GwentCard()
                {
                    CardId ="63016",
                    Name="Gremist",
                    Strength=4,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support},
                    Flavor = "精通炼金术的大德鲁伊，也是群岛脾气最差的老混蛋。",
                    Info = "Spawn Rain, Clear Skies or Roar.",
                    CardArtsId = "15220600",
                }
            },
            {
                "63017",//茜格德莉法
                new GwentCard()
                {
                    CardId ="63017",
                    Name="Sigrdrifa",
                    Strength=3,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support,Categorie.Doomed},
                    Flavor = "跪在我身边，向圣母低头。",
                    Info = "Resurrect a Bronze or Silver Clan unit.",
                    CardArtsId = "15221100",
                }
            },
            {
                "63018",//史璀伯格符文石
                new GwentCard()
                {
                    CardId ="63018",
                    Name="Stribog Runestone",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Alchemy,Categorie.Special,Categorie.Item},
                    Flavor = "欧菲尔的符文大师可以把它们组合成威力无比的符文。",
                    Info = "Create a Bronze or Silver Skellige card.",
                    CardArtsId = "20158100",
                }
            },
            {
                "63019",//回复
                new GwentCard()
                {
                    CardId ="63019",
                    Name="Restore",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Spell,Categorie.Special},
                    Flavor = "那些该死的女术士又抢咱们的风头！只要几个年轻姑娘挥挥手就能解决的话，谁还选择这么费时费力的办法？",
                    Info = "Return a Bronze or Silver Skellige Unit from your Graveyard to your Hand and set its base Power to 8, then play a card from your Hand.",
                    CardArtsId = "15320100",
                }
            },
            {
                "63020",//华美的长剑
                new GwentCard()
                {
                    CardId ="63020",
                    Name="Ornamental Sword",
                    Strength=0,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Item},
                    Flavor = "看上去很精美，但顶多也就只能用来抹抹黄油。",
                    Info = "Create a Bronze or Silver Skellige Soldier and Strengthen it by 3.",
                    CardArtsId = "20164200",
                }
            },
            {
                "64001",//奎特家族战士
                new GwentCard()
                {
                    CardId ="64001",
                    Name="An Craite Warrior",
                    Strength=12,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanAnCraite},
                    Flavor = "我们的吟游诗人会世代传颂我的功绩，而你死了就会被世人遗忘！",
                    Info = "Deal 1 damage to self.",
                    CardArtsId = "15230300",
                }
            },
            {
                "64002",//迪门家族海盗
                new GwentCard()
                {
                    CardId ="64002",
                    Name="Dimun Pirate",
                    Strength=11,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanDimun},
                    Flavor = "我能看到他们眼中的恐惧。他们害怕我……害怕迪门家族！",
                    Info = "Discard all copies of this unit from your deck.",
                    CardArtsId = "15230500",
                }
            },
            {
                "64003",//海玫家族佛兰明妮卡
                new GwentCard()
                {
                    CardId ="64003",
                    Name="Heymaey Flaminica",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanHeymaey,Categorie.Support},
                    Flavor = "佛兰明妮卡是女德鲁伊最高领袖的头衔，她备受众人的崇敬，拥有无比的力量。",
                    Info = "Clear Hazards from the row and move 2 allies to it.",
                    CardArtsId = "20014700",
                }
            },
            {
                "64004",//迪门家族走私贩
                new GwentCard()
                {
                    CardId ="64004",
                    Name="Dimun Smuggler",
                    Strength=10,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanDimun},
                    Flavor = "史派克鲁格是一片死水，不过没有关系。我们想要什么，就从你们那儿夺。",
                    Info = "Return a Bronze unit from your graveyard to your deck.",
                    CardArtsId = "20014600",
                }
            },
            {
                "64005",//狂战士掠夺者
                new GwentCard()
                {
                    CardId ="64005",
                    Name="Berserker Marauder",
                    Strength=9,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Soldier,Categorie.Cultist},
                    Flavor = "把汤乖乖喝完，不然狂战士就会过来，把你给掳走。",
                    Info = "Boost self by 1 for each damaged or Cursed ally.",
                    CardArtsId = "15230200",
                }
            },
            {
                "64006",//海玫家族诗人
                new GwentCard()
                {
                    CardId ="64006",
                    Name="Heymaey Skald",
                    Strength=9,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanHeymaey,Categorie.Support},
                    Flavor = "海玫家族的事迹将流芳千古。",
                    Info = "Boost all allies from a Clan of your choice by 1.",
                    CardArtsId = "15230800",
                }
            },
            {
                "64007",//奎特家族盾牌匠
                new GwentCard()
                {
                    CardId ="64007",
                    Name="An Craite Blacksmith",
                    Strength=9,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support,Categorie.ClanAnCraite},
                    Flavor = "记住我的话：一面好盾能救你的小命。",
                    Info = "Strengthen an ally by 2 and give it 2 Armor.",
                    CardArtsId = "15231100",
                }
            },
            {
                "64008",//恶熊
                new GwentCard()
                {
                    CardId ="64008",
                    Name="Savage Bear",
                    Strength=9,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Cursed},
                    Flavor = "“驯服”？哈，小子，史凯利格人也许能训练它们，但那跟驯服完全不同……",
                    Info = "Whenever a unit is played from either hand on your opponent's side, deal 1 damage to it.",
                    CardArtsId = "15221000",
                }
            },
            {
                "64009",//奎特家族巨剑士
                new GwentCard()
                {
                    CardId ="64009",
                    Name="An Craite Greatsword",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanAnCraite},
                    Flavor = "啊哈哈，你真让我笑掉大牙，北方佬！怎么？我手上这把大家伙，你都不一定拿得动，还想用它对付我？",
                    Info = "Every 2 turns, if damaged, Heal self and Strengthen by 2 on turn start.",
                    CardArtsId = "20004000",
                }
            },
            {
                "64010",//图尔赛克家族弓箭手
                new GwentCard()
                {
                    CardId ="64010",
                    Name="Tuirseach Archer",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanTuirseach},
                    Flavor = "你能射中两百步外的移动靶吗？我能，而且是在暴风雨中。",
                    Info = "Deal 1 damage to 3 units.",
                    CardArtsId = "15231500",
                }
            },
            {
                "64011",//德拉蒙家族好战分子
                new GwentCard()
                {
                    CardId ="64011",
                    Name="Drummond Warmonger",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanDrummond,Categorie.Soldier},
                    Flavor = "为大局着想？！战争就是大局，至善至恶，没什么比它更带劲的了！",
                    Info = "Discard a Bronze card from your deck.",
                    CardArtsId = "20003600",
                }
            },
            {
                "64012",//图尔赛克家族好斗分子
                new GwentCard()
                {
                    CardId ="64012",
                    Name="Tuirseach Skirmisher",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanTuirseach},
                    Flavor = "记好了：我们对朋友掏心窝，对敌人挥斧子。",
                    Info = "Whenever this unit is Resurrected, Strengthen it by 3.",
                    CardArtsId = "15231300",
                }
            },
            {
                "64013",//暴怒的狂战士
                new GwentCard()
                {
                    CardId ="64013",
                    Name="Svalblod Ravager",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Soldier,Categorie.Cultist},
                    Flavor = "在诗人的歌谣里，鏖战中变身的狂战士跟野熊没两样。",
                    Info = "Whenever this unit is damaged or Weakened, transform into a Raging Bear.",
                    CardArtsId = "15230100",
                }
            },
            {
                "64014",//奎特家族捕鲸鱼叉手
                new GwentCard()
                {
                    CardId ="64014",
                    Name="An Craite Whaler",
                    Strength=8,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine,Categorie.ClanAnCraite},
                    Flavor = "无论是海上还是港口，他们盯上的目标永远是最漂亮的那个。",
                    Info = "Move an enemy to the opposite row, then deal damage equal to the number of units on that row.",
                    CardArtsId = "20030000",
                }
            },
            {
                "64015",//奎特家族盔甲匠
                new GwentCard()
                {
                    CardId ="64015",
                    Name="An Craite Armorsmith",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support,Categorie.ClanAnCraite},
                    Flavor = "你是讨打。",
                    Info = "Heal 2 allies and and give them 3 Armor.",
                    CardArtsId = "15231700",
                }
            },
            {
                "64016",//图尔赛克家族老兵
                new GwentCard()
                {
                    CardId ="64016",
                    Name="Tuirseach Veteran",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanTuirseach,Categorie.Support},
                    Flavor = "我见人所未见，能人所不能。",
                    Info = "Strengthen all your other Clan Tuirseach units in hand, deck, and on board by 1.",
                    CardArtsId = "20004600",
                }
            },
            {
                "64017",//迪门家族轻型长船
                new GwentCard()
                {
                    CardId ="64017",
                    Name="Dimun Light Longship",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanDimun,Categorie.Machine},
                    Flavor = "你以为能在史凯利格海域逃出他们的手掌心？自求多福吧。",
                    Info = "On turn end, deal 1 damage to the unit to the right, then boost self by 2. ",
                    CardArtsId = "15230900",
                }
            },
            {
                "64018",//奎特家族作战长船
                new GwentCard()
                {
                    CardId ="64018",
                    Name="An Craite Longship",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Machine,Categorie.ClanAnCraite},
                    Flavor = "据说只要有长船出海劫掠，汉姆多尔就会心潮澎湃。",
                    Info = "Deal 2 damage to a random enemy. Repeat this ability whenever you Discard a card.",
                    CardArtsId = "15231400",
                }
            },
            {
                "64019",//迪门家族战船
                new GwentCard()
                {
                    CardId ="64019",
                    Name="Dimun Warship",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanDimun,Categorie.Machine},
                    Flavor = "迪门家族的战船轻盈迅捷，最适合追逐缓慢笨重的商船。",
                    Info = "Deal 1 damage to the same unit 4 times.",
                    CardArtsId = "20010500",
                }
            },
            {
                "64020",//奎特家族劫掠者
                new GwentCard()
                {
                    CardId ="64020",
                    Name="An Craite Marauder",
                    Strength=7,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanAnCraite},
                    Flavor = "你疯了不成？你想去史凯利格？哪些野蛮人会让你吃大苦头的！",
                    Info = "Deal 4 damage. If Resurrected, deal 6 damage instead.",
                    CardArtsId = "20157800",
                }
            },
            {
                "64021",//图尔赛克家族猎人
                new GwentCard()
                {
                    CardId ="64021",
                    Name="Tuirseach Hunter",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanTuirseach},
                    Flavor = "别怀疑我们的狩猎本领，只恨史派克鲁格的猎物太少……",
                    Info = "Deal 5 damage.",
                    CardArtsId = "15230400",
                }
            },
            {
                "64022",//图尔赛克家族斧兵
                new GwentCard()
                {
                    CardId ="64022",
                    Name="Tuirseach Axeman",
                    Strength=6,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanTuirseach},
                    Flavor = "小姑娘才用剑，弄把斧头吧。",
                    Info = "Whenever an enemy on the opposite row is damaged, boost self by 1. 2 Armor.",
                    CardArtsId = "15231200",
                }
            },
            {
                "64023",//奎特家族战吼者
                new GwentCard()
                {
                    CardId ="64023",
                    Name="An Craite Warcrier",
                    Strength=5,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Support,Categorie.ClanAnCraite},
                    Flavor = "有人为泰莫利亚抛头颅，有人为尼弗迦德洒热血。我只为骑士的誓言而战。",
                    Info = "Boost an ally by half its power.",
                    CardArtsId = "11331300",
                }
            },
            {
                "64024",//奎特家族突袭者
                new GwentCard()
                {
                    CardId ="64024",
                    Name="An Craite Raider",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanAnCraite},
                    Flavor = "我们可是奎特家族！別人用金子购买，我们拿血汗交换。",
                    Info = "Whenever you Discard this unit, Resurrect it.",
                    CardArtsId = "15231600",
                }
            },
            {
                "64025",//德拉蒙家族女王卫队
                new GwentCard()
                {
                    CardId ="64025",
                    Name="Drummond Queensguard",
                    Strength=4,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanDrummond,Categorie.Soldier},
                    Flavor = "史凯利格的女王向来由最勇猛、最凶悍的持盾女卫保护。",
                    Info = "Resurrect all your copies of this unit.",
                    CardArtsId = "15230710",
                }
            },
            {
                "64026",//德拉蒙家族持盾女卫
                new GwentCard()
                {
                    CardId ="64026",
                    Name="Drummond Shieldmaid",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanDrummond,Categorie.Soldier},
                    Flavor = "我们的敌人会像打上嶙峋海岸的波浪一样，倒在我们的盾前。",
                    Info = "Summon all copies of this unit.",
                    CardArtsId = "15231810",
                }
            },
            {
                "64027",//海玫家族草药医生
                new GwentCard()
                {
                    CardId ="64027",
                    Name="Heymaey Herbalist",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanHeymaey,Categorie.Support},
                    Flavor = "“在史凯利格，我们可不会把聪明的女人绑在柴火上，而是听取她们的建议。”",
                    Info = "Play a random Bronze Organic or Hazard card from your deck.",
                    CardArtsId = "20008100",
                }
            },
            {
                "64028",//迪门家族海贼
                new GwentCard()
                {
                    CardId ="64028",
                    Name="Dimun Corsair",
                    Strength=3,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanDimun,Categorie.Support,Categorie.Doomed},
                    Flavor = "大海属于我们。海里的东西，不管是漂着的、游着的、划着的，也都是咱们的！",
                    Info = "Resurrect a Bronze Machine.",
                    CardArtsId = "20014500",
                }
            },
            {
                "64029",//海玫家族女矛手
                new GwentCard()
                {
                    CardId ="64029",
                    Name="Heymaey Spearmaiden",
                    Strength=2,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanHeymaey,Categorie.Support},
                    Flavor = "“史凯利格的女人生性狂野，难以捉摸。所有的部队都要把她们视为严重的威胁，绝不能低估她们的实力。”—将军对帝国舰队入侵部队下的指令",
                    Info = "Deal 1 damage to a Machine or Soldier ally, then play a copy of it from your deck.",
                    CardArtsId = "20014800",
                }
            },
            {
                "64030",//海玫家族保卫者
                new GwentCard()
                {
                    CardId ="64030",
                    Name="Heymaey Protector",
                    Strength=2,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanHeymaey},
                    Flavor = "他天不怕地不怕，除了弗蕾雅的怒火……还有他老婆。",
                    Info = "Play a Bronze Item from your deck.",
                    CardArtsId = "20014900",
                }
            },
            {
                "64031",//迪门家族海盗船长
                new GwentCard()
                {
                    CardId ="64031",
                    Name="Dimun Pirate Captain",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanDimun,Categorie.Officer},
                    Flavor = "加把劲儿把旗升起来！",
                    Info = "Play a different Bronze Dimun unit from your deck. ",
                    CardArtsId = "15230600",
                }
            },
            {
                "64032",//弗蕾雅女祭司
                new GwentCard()
                {
                    CardId ="64032",
                    Name="Priestess of Freya",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = true,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.ClanHeymaey,Categorie.Support,Categorie.Doomed},
                    Flavor = "圣母弗蕾雅是爱、美与丰饶的女神。",
                    Info = "Resurrect a Bronze Soldier.",
                    CardArtsId = "15231000",
                }
            },
            {
                "64033",//图尔赛克家族驯兽师
                new GwentCard()
                {
                    CardId ="64033",
                    Name="Tuirseach Bearmaster",
                    Strength=1,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Soldier,Categorie.ClanTuirseach},
                    Flavor = "别碰他。别盯着他的眼睛瞧。事实上……压根就别靠近他。",
                    Info = "Spawn a Bear.",
                    CardArtsId = "20014400",
                }
            },
            {
                "64034",//骨制护符
                new GwentCard()
                {
                    CardId ="64034",
                    Name="Bone Talisman",
                    Strength=0,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.AnyPlace,
                    CardType = CardType.Special,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Special,Categorie.Item},
                    Flavor = "有时最普通不过的物件却拥有最为强大的威力。",
                    Info = "Choose One: Resurrect a Bronze Beast or Cultist unit or Heal an ally and Strengthen it by 3.",
                    CardArtsId = "20159800",
                }
            },
            {
                "65001",//汉姆多尔
                new GwentCard()
                {
                    CardId ="65001",
                    Name="Hemdall",
                    Strength=20,
                    Group=Group.Gold,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Token},
                    Flavor = "白霜到来之时，汉姆多尔将吹响战斗的号角。",
                    Info = "Destroy all units and clear all Boons and Hazards.",
                    CardArtsId = "15240200",
                }
            },
            {
                "65002",//狂暴的熊
                new GwentCard()
                {
                    CardId ="65002",
                    Name="Raging Bear",
                    Strength=12,
                    Group=Group.Copper,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Beast,Categorie.Cursed,Categorie.Cultist},
                    Flavor = "吼！！！",
                    Info = "No Ability.",
                    CardArtsId = "15240500",
                }
            },
            {
                "65003",//乌德维克之主
                new GwentCard()
                {
                    CardId ="65003",
                    Name="Lord of Undvik",
                    Strength=5,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Ogroid,Categorie.Token},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "这个怪物将名门世族托达洛克家族的故乡——乌德维克岛变成了荒凉之地，昔日荣光一去不返……",
                    Info = "Spying. Deathwish: Boost enemy Hjalmars by 10.",
                    CardArtsId = "15240100",
                }
            },
            {
                "65004",//幽灵鲸
                new GwentCard()
                {
                    CardId ="65004",
                    Name="Spectral Whale",
                    Strength=3,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Token},
                    Flavor = "“呃，座头鲸应该没那么大。那是头长须鲸。”“嘴那么短的长须鲸？你被药草冲昏了头吗！”",
                    Info = "Move to a random row and deal 1 damage to all units on it on turn end.",
                    CardArtsId = "15240300",
                }
            },
            {
                "65005",//威尔弗雷德
                new GwentCard()
                {
                    CardId ="65005",
                    Name="Wilfred",
                    Strength=1,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Token},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "高个子的是威尔玛。他右边的是威尔弗雷德。结巴的那个是威尔海姆。",
                    Info = "Deathwish: Strengthen a random Ally by 3.",
                    CardArtsId = "20052500",
                }
            },
            {
                "65006",//威尔海姆
                new GwentCard()
                {
                    CardId ="65006",
                    Name="Wilhelm",
                    Strength=1,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Token},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "高个子的是威尔玛。他右边的是威尔弗雷德。结巴的那个是威尔海姆。",
                    Info = "Deathwish: Damage all Unis on the opposite row by 1.",
                    CardArtsId = "20052500",
                }
            },
            {
                "65007",//威尔玛
                new GwentCard()
                {
                    CardId ="65007",
                    Name="Wilmar",
                    Strength=1,
                    Group=Group.Silver,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.EnemyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = true,
                    Categories = new Categorie[]{ Categorie.Cursed,Categorie.Token},
                    HideTags = new HideTag[]{HideTag.Deathwish},
                    Flavor = "高个子的是威尔玛。他右边的是威尔弗雷德。结巴的那个是威尔海姆。",
                    Info = "Deathwish: The opposing player plays a random Bronze Cursed Unit from their Deck.",
                    CardArtsId = "20052500",
                }
            },
            {
                "61001",//“瘸子”哈罗德
                new GwentCard()
                {
                    CardId ="61001",
                    Name="Harald the Cripple",
                    Strength=6,
                    Group=Group.Leader,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.ClanAnCraite},
                    Flavor = "没人知道他的绰号从何而来，更没人敢问。",
                    Info = "Split 10 damage randomly between enemies on the opposite row.",
                    CardArtsId = "15110300",
                }
            },
            {
                "61002",//克拉茨·奎特
                new GwentCard()
                {
                    CardId ="61002",
                    Name="Crach an Craite",
                    Strength=5,
                    Group=Group.Leader,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.ClanAnCraite},
                    Flavor = "尼弗迦德人叫我“蒂斯·伊斯·穆瑞”，也就是海上野猪。他们还用我的名号来吓唬小孩！",
                    Info = "Strengthen the Highest non-Spying Bronze or Silver unit in your deck by 2 and play it.",
                    CardArtsId = "15110200",
                }
            },
            {
                "61003",//埃斯特·图尔赛克
                new GwentCard()
                {
                    CardId ="61003",
                    Name="Eist Tuirseach",
                    Strength=5,
                    Group=Group.Leader,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.ClanTuirseach},
                    Flavor = "埃斯特来到辛特拉，本想帮助克拉茨·奎特参加帕薇塔公主的选亲宴，结果自己却赢走了王后的芳心。",
                    Info = "Spawn a Bronze Clan Tuirseach Soldier.",
                    CardArtsId = "20006000",
                }
            },
            {
                "61004",//布兰王
                new GwentCard()
                {
                    CardId ="61004",
                    Name="Bran Tuirseach",
                    Strength=2,
                    Group=Group.Leader,
                    Faction = Faction.Skellige,
                    CardUseInfo = CardUseInfo.MyRow,
                    CardType = CardType.Unit,
                    IsDoomed = false,
                    IsCountdown = false,
                    IsDerive = false,
                    Categories = new Categorie[]{ Categorie.Leader,Categorie.ClanTuirseach},
                    Flavor = "没人能取代布兰王，但后世定会努力尝试。",
                    Info = "Discard up to 3 cards from your deck and Strengthen them by 1.",
                    CardArtsId = "15110100",
                }
            },
        };
        public static IEnumerable<GwentCard> DeckChange(IEnumerable<string> deck)
        {
            var step1 = deck.Select(x => CardMap[x]);
            return step1.Select(x => new GwentCard()
            {
                Categories = x.Categories,
                Faction = x.Faction,
                Flavor = x.Flavor,
                Group = x.Group,
                Info = x.Info,
                Name = x.Name,
                Strength = x.Strength,
                //-------
                CardId = x.CardId,
                IsCountdown = x.IsCountdown,
                Countdown = x.Countdown,
                IsDoomed = x.IsDoomed,
                CardArtsId = x.CardArtsId,
                CardType = x.CardType,
                CardUseInfo = x.CardUseInfo,
            });
        }
    }
}