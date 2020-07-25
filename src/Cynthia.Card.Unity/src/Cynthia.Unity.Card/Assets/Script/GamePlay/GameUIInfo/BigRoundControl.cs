using Assets.Script.LanguageScript;
using Autofac;
using Cynthia.Card;
using Cynthia.Card.Common.Models;
using UnityEngine;
using UnityEngine.UI;
public class BigRoundControl : MonoBehaviour
{
    public Text Title;
    public Text Message;
    public Text MyPoint;
    public Text EnemyPoint;
    public Image TitleBg;
    public Image BigRoundBg;
    public GameObject BigRound;
    public GameObject MessageShow;
    public GameObject PointShow;
    public GameObject MyWinCountLeft;
    public GameObject MyWinCountRight;
    public GameObject EnemyWinCountLeft;
    public GameObject EnemyWinCountRight;

    private ITranslator _translator;

    private void Start()
    {
        _translator = DependencyResolver.Container.Resolve<ITranslator>();
    }

    public void ShowPoint(BigRoundInfomation data)
    {
        if (data.GameStatus == GameStatus.Draw)
        {
            BigRoundBg.color = new Color32(10, 10, 10, 220);
            TitleBg.color = new Color32(200, 130, 80, 255);
            Title.text = _translator.GetText("round_draw_text");
            Message.text = _translator.GetText("starting_last_round");
        }
        if (data.GameStatus == GameStatus.Win)
        {
            BigRoundBg.color = new Color32(10, 10, 24, 220);
            TitleBg.color = new Color32(0, 130, 255, 255);
            Title.text = _translator.GetText("round_won_text");

            var roundCount = data.EnemyWinCount + data.MyWinCount;
            Message.text = _translator.GetText(roundCount == 1 ? "starting_second_round" : "starting_last_round");
        }
        if (data.GameStatus == GameStatus.Lose)
        {
            BigRoundBg.color = new Color32(24, 10, 10, 220);
            TitleBg.color = new Color32(255, 0, 0, 255);
            Title.text = _translator.GetText("round_lost_text");

            var roundCount = data.EnemyWinCount + data.MyWinCount;
            Message.text = _translator.GetText(roundCount == 1 ? "starting_second_round" : "starting_last_round");
        }

        SetPoint(data);
        BigRound.SetActive(true);
    }

    public void SetPoint(BigRoundInfomation data)
    {
        MyPoint.text = data.MyPoint.ToString();
        EnemyPoint.text = data.EnemyPoint.ToString();
        MyPoint.color = ClientGlobalInfo.NormalColor;
        EnemyPoint.color = ClientGlobalInfo.NormalColor;
        if (data.MyPoint > data.EnemyPoint)
        {
            MyPoint.color = ClientGlobalInfo.WinColor;
        }
        else if (data.EnemyPoint > data.MyPoint)
        {
            EnemyPoint.color = ClientGlobalInfo.WinColor;
        }
        MyWinCountLeft.SetActive(false);
        MyWinCountRight.SetActive(false);
        EnemyWinCountLeft.SetActive(false);
        EnemyWinCountRight.SetActive(false);
        if (data.MyWinCount > 0)
            MyWinCountLeft.SetActive(true);
        if (data.MyWinCount > 1)
            MyWinCountRight.SetActive(true);
        if (data.EnemyWinCount > 0)
            EnemyWinCountLeft.SetActive(true);
        if (data.EnemyWinCount > 1)
            EnemyWinCountRight.SetActive(true);
        PointShow.SetActive(true);
        MessageShow.SetActive(false);
    }
    public void CloseBigRound()
    {
        BigRound.SetActive(false);
    }

    public void DisplayMessage()
    {
        PointShow.SetActive(false);
        MessageShow.SetActive(true);
    }
}
