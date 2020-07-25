using Alsein.Extensions;
using Assets.Script.LanguageScript;
using Autofac;
using Cynthia.Card;
using Cynthia.Card.Client;
using System.Collections.Generic;
using System.Linq;
using Cynthia.Card.Common.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MatchInfo : MonoBehaviour
{
    public ArtCard ShowArtCard;
    public GameObject LaderPrefab;
    public GameObject CardPrefab;
    public GameObject DeckPrefab;
    //-------------------------------------------
    public Transform CardsContext;
    public Transform DecksContext;
    public Text GoldCount;
    public Text SilverCount;
    public Text CopperCount;
    public Text AllCount;
    public Text AllCountText;
    public Image HeadT;
    public Image HeadB;
    public Sprite[] HeadTSprite;
    public Sprite[] HeadBSprite;

    public Text DeckName;
    public InputField MatchPassword;
    public Transform DeckNameBackground;
    public Image DeckIcon;
    //-------------------------------------------
    public Sprite[] FactionIcon;
    public Faction[] FactionIndex;
    //-------------------------------------------
    public GameObject ReturnButton;
    public GameObject SwitchButton;
    public GameObject CloseButton;
    public GameObject MatchButton;
    public GameObject DeckSwitch;
    public GameObject CardsScrollbar;
    public GameObject DecksScrollbar;
    //
    public GameObject[] DeckPrefabs;
    //
    public Text MatchButtonText;
    public Text MatchMessage;
    //-------------------------------------------
    public GameObject MainUI;
    public GameObject MatchUI;
    public MainMenuEffect[] ResetTextMenus;
    //-------------------------------------------
    private ITranslator _translator;
    //-------------------------------------------
    private void Awake()
    {
        _translator = DependencyResolver.Container.Resolve<ITranslator>();
    }

    public string CurrentDeckId { get; private set; }
    public bool IsDoingMatch { get; private set; }

    private GwentClientService _client { get => DependencyResolver.Container.Resolve<GwentClientService>(); }
    private GlobalUIService _UIService { get => DependencyResolver.Container.Resolve<GlobalUIService>(); }

    public void MatchMenuClick()
    {
        if (_client.User.Decks.Count() <= 0)
        {
            _UIService.YNMessageBox("error_title", "error_no_decks", "ok_button", isOnlyYes: true);
        }
        else
        {
            ResetMatch();
            MainUI.SetActive(false);
            MatchUI.SetActive(true);
            ResetTextMenus.ForAll(x => x.TextReset());
        }
    }
    public void ResetMatch()
    {
        if (!_client.User.Decks.Any(x => x.Id == ClientGlobalInfo.DefaultDeckId)) ClientGlobalInfo.DefaultDeckId = _client.User.Decks.First().Id;
        SetDeck(_client.User.Decks.Single(x => x.Id == ClientGlobalInfo.DefaultDeckId), ClientGlobalInfo.DefaultDeckId);
        SetDeckList(_client.User.Decks);
    }
    public void ShowMatch()/////待编辑
    {
        ReturnButton.SetActive(false);
        SwitchButton.SetActive(false);
        MatchMessage.text = _translator.GetText("looking_for_opponent");
        MatchButtonText.text = _translator.GetText("cancel_button");
        MatchPassword.readOnly = true;
    }
    public void ShowStopMatch()/////待编辑
    {
        ReturnButton.SetActive(true);
        SwitchButton.SetActive(true);
        MatchMessage.text = _translator.GetText("deck_ready");
        MatchButtonText.text = _translator.GetText("play_button");
        MatchPassword.readOnly = false;
    }
    public async void MatchButtonClick()/////点击匹配按钮的话
    {
        //如果正在进行匹配
        if (IsDoingMatch)
        {
            //停止匹配
            await _client.StopMatch();
            return;
        }
        if (!_client.User.Decks.Single(x => x.Id == CurrentDeckId).IsBasicDeck())
        { ;
            await _UIService.YNMessageBox("error_title", "error_incomplete_deck", "ok_button", isOnlyYes: true);
            return;
        }
        //否则尝试开始匹配(目前不关注匹配结果)
        _ = _client.MatchOfPassword(CurrentDeckId, MatchPassword.text);

        // else if (!await _client.Match(CurrentDeckId))
        // {
        //     //如果发生错误的话,匹配失败
        //     Debug.Log("发送未知错误,匹配失败");
        // }

        //将状态和显示都变成正在匹配
        IsDoingMatch = true;
        ShowMatch();

        //等待匹配的结果,如果是true代表成功匹配
        if (await _client.MatchResult())
        {
            //进入了游戏
            Debug.Log("成功匹配,进入游戏");
            ClientGlobalInfo.IsToMatch = false;
#if UNITY_STANDALONE_WIN
            ClientGlobalInfo.OpenWindow("UnityWndClass", "MyGwent");
#endif
            SceneManager.LoadScene("GamePlay");
            return;
        }
        else
        {
            //否则代表取消了匹配
            Debug.Log("成功停止匹配");
            IsDoingMatch = false;
            ShowStopMatch();
        }
    }
    public void SwitchDeckOpen()
    {
        ReturnButton.SetActive(false);
        SwitchButton.SetActive(false);
        MatchButton.SetActive(false);
        CloseButton.SetActive(true);
        MatchMessage.text = _translator.GetText("select_deck");
        DeckNameBackground.gameObject.SetActive(false);
        DecksScrollbar.GetComponent<Scrollbar>().value = 1;
        DeckSwitch.GetComponent<Animator>().Play("SwitchDeckOpen");
    }
    public void MatchReset()
    {
        ReturnButton.SetActive(true);
        SwitchButton.SetActive(true);
        MatchButton.SetActive(true);
        CloseButton.SetActive(false);
        MatchMessage.text = _translator.GetText("deck_ready");
        CardsScrollbar.GetComponent<Scrollbar>().value = 1;
        DeckNameBackground.gameObject.SetActive(true);
    }
    public void SwitchDeckClose()
    {
        MatchReset();
        DeckSwitch.GetComponent<Animator>().Play("SwitchDeckClose");
    }
    void Start()
    {
        ResetMatch();
        IsDoingMatch = false;
    }
    public void SetDeckList(IList<DeckModel> decks)
    {
        var count = DecksContext.childCount;
        for (var i = count - 1; i >= 0; i--)
        {
            Destroy(DecksContext.GetChild(i).gameObject);
        }
        DecksContext.DetachChildren();
        decks.ForAll(x =>
        {
            var deck = Instantiate(DeckPrefabs[GetFactionIndex(GwentMap.GetCard(x.Leader).Faction)]);
            deck.GetComponent<DeckShowInfo>().SetDeckInfo(x.Name, x.IsBasicDeck());
            deck.GetComponent<SwitchMatchDeck>().SetId(DecksContext.childCount);
            deck.transform.SetParent(DecksContext, false);
        });
        var height = decks.Count * 83 + 35;
        DecksContext.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(370, height > 800 ? height : 800);
    }

    public void SetMatchArtCard(CardStatus card, bool isOver = true)
    {

        ShowArtCard.CurrentCore = card;
        ShowArtCard.gameObject.SetActive(isOver);
    }

    public void SetDeck(DeckModel deck, string id)
    {
        CurrentDeckId = id;
        var count = CardsContext.childCount;
        for (var i = count - 1; i >= 0; i--)
        {
            Destroy(CardsContext.GetChild(i).gameObject);
        }
        CardsContext.DetachChildren();
        //////////////////////////////////////////////////
        DeckName.text = deck.Name;
        DeckNameBackground.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(25 * DeckName.text.Length + 150, 71);
        DeckName.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(25 * DeckName.text.Length, 40);
        DeckName.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-25 * DeckName.text.Length / 2 - 50, 0);
        DeckIcon.overrideSprite = FactionIcon[GetFactionIndex(GwentMap.GetCard(deck.Leader).Faction)];
        //DeckIcon.sprite = Resources.Load<Sprite>("Sprites/Control/coin_northern");
        //////////////////////////////////////////////////
        var leader = Instantiate(LaderPrefab);
        leader.GetComponent<LeaderShow>().SetLeader(deck.Leader);
        leader.transform.SetParent(CardsContext, false);
        var cards = deck.Deck.Select(x => GwentMap.GetCard(x));
        cards.OrderByDescending(x => x.Group).ThenByDescending(x => x.Strength).GroupBy(x => x.Name).ForAll(x =>
            {
                var card = Instantiate(CardPrefab);
                card.GetComponent<ListCardShowInfo>().SetCardInfo(x.First().CardId, x.Count());
                card.transform.SetParent(CardsContext, false);
            });
        CopperCount.text = cards.Where(x => x.Group == Group.Copper).Count().ToString();
        SilverCount.text = $"{cards.Where(x => x.Group == Group.Silver).Count().ToString()}/6";
        GoldCount.text = $"{cards.Where(x => x.Group == Group.Gold).Count().ToString()}/4";
        AllCount.text = $"{deck.Deck.Count()}";
        AllCount.color = deck.IsBasicDeck() ? ClientGlobalInfo.NormalColor : ClientGlobalInfo.ErrorColor;
        AllCountText.color = deck.IsBasicDeck() ? ClientGlobalInfo.NormalColor : ClientGlobalInfo.ErrorColor;
        HeadT.sprite = HeadTSprite[GetFactionIndex(GwentMap.GetCard(deck.Leader).Faction)];
        HeadB.sprite = HeadBSprite[GetFactionIndex(GwentMap.GetCard(deck.Leader).Faction)];
        //////////////////////////////////////////////////
        var height = ((41.5f + 3f) * CardsContext.childCount) + 8f + 38f;
        CardsContext.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, height);
    }
    public int GetFactionIndex(Faction faction)
    {
        return FactionIndex.Indexed().Single(x => x.Value == faction).Key;
    }

    public void ReturnButtonClick()
    {
        ClientGlobalInfo.IsToMatch = false;
    }
}

