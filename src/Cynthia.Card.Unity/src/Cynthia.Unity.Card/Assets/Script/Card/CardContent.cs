using System.Linq;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cynthia.Card;
using Alsein.Extensions;
using Assets.Script.GlobalUI;

public class CardContent : MonoBehaviour
{
    public Text CardNameText;
    public Text TagsText;
    public Text CardInfoText;

    public Image Head;
    public Image Bottom;

    public Sprite NorthernRealmsHead;//北方
    public Sprite ScoiaTaelHead;//松鼠党
    public Sprite MonstersHead;//怪物
    public Sprite SkelligeHead;//群岛
    public Sprite NilfgaardHead;//帝国
    public Sprite NeutralHead;//中立

    public Sprite NorthernRealmsContent;//北方
    public Sprite ScoiaTaelContent;//松鼠党
    public Sprite MonstersContent;//怪物
    public Sprite SkelligeContent;//群岛
    public Sprite NilfgaardContent;//帝国
    public Sprite NeutralContent;//中立
    //--------

    public IDictionary<Faction, Sprite> HeadMap;
    public IDictionary<Faction, Sprite> ContentMap;

    public RectTransform Content;

    // Start is called before the first frame update
    void Init()
    {
        HeadMap = new Dictionary<Faction, Sprite>();
        ContentMap = new Dictionary<Faction, Sprite>();
        HeadMap[Faction.Monsters] = MonstersHead;
        HeadMap[Faction.Neutral] = NeutralHead;
        HeadMap[Faction.Nilfgaard] = NilfgaardHead;
        HeadMap[Faction.NorthernRealms] = NorthernRealmsHead;
        HeadMap[Faction.ScoiaTael] = ScoiaTaelHead;
        HeadMap[Faction.Skellige] = SkelligeHead;
        //---
        ContentMap[Faction.Monsters] = MonstersContent;
        ContentMap[Faction.Neutral] = NeutralContent;
        ContentMap[Faction.Nilfgaard] = NilfgaardContent;
        ContentMap[Faction.NorthernRealms] = NorthernRealmsContent;
        ContentMap[Faction.ScoiaTael] = ScoiaTaelContent;
        ContentMap[Faction.Skellige] = SkelligeContent;
    }


    public void SetCard(CardStatus cardStatus)
    {
        if (cardStatus.IsCardBack || cardStatus.Conceal)
        {
            return;
        }
        if (HeadMap == null || ContentMap == null)
        {
            Init();
        }
        Head.sprite = HeadMap[cardStatus.Faction];
        Bottom.sprite = ContentMap[cardStatus.Faction];

        var lang = LanguageManager.Instance;
        CardInfoText.text = lang.GetText($"card_{cardStatus.CardId}_info");//ToTrueString(cardStatus.Info);
        CardNameText.text = lang.GetText($"card_{cardStatus.CardId}_name");//ToTrueString(cardStatus.Name);
        TagsText.text = cardStatus.Categories.Select(x => GwentMap.CategorieInfoMap[x])
            .ForAll(t => t = lang.GetText($"card_{t}_tag")).Join(", ");
        //TagsText.text = ToTrueString(cardStatus.Categories.Select(x => GwentMap.CategorieInfoMap[x]).Join(", "));

        if (cardStatus.IsImmue)
            TagsText.text += string.IsNullOrWhiteSpace(TagsText.text) ? "Immune" : ", Immune";

        if (cardStatus.IsDoomed && !TagsText.text.Contains("Doomed"))
            TagsText.text += string.IsNullOrWhiteSpace(TagsText.text) ? "Doomed" : ", Doomed";

        /*if (cardStatus.IsDoomed && !TagsText.text.Contains("佚亡"))
            TagsText.text += string.IsNullOrWhiteSpace(TagsText.text) ? "佚亡" : ", 佚亡";*/
        Content.sizeDelta = new Vector2(Content.sizeDelta.x, CardInfoText.preferredHeight + 115);
        // Debug.Log(CardInfoText.preferredHeight);
    }

    public string ToTrueString(string s)
    {
        return s.Replace(" ", "\u00A0");
    }
}
