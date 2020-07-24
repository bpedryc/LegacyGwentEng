using Assets.Script.LanguageScript;
using Cynthia.Card;
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

    public void Test()
    {
        //ShowPoint(false, "输掉啦!", 1, 99999, 0, 2);
    }

    public void ShowPoint(BigRoundInfomation data)
    {
        var lang = LanguageManager.Instance;

        if (data.GameStatus == GameStatus.Draw)
        {
            BigRoundBg.color = new Color32(10, 10, 10, 220);
            TitleBg.color = new Color32(200, 130, 80, 255);
            Title.text = lang.GetText("round_draw_text");
            Message.text = lang.GetText("starting_last_round");
        }
        if (data.GameStatus == GameStatus.Win)
        {
            BigRoundBg.color = new Color32(10, 10, 24, 220);
            TitleBg.color = new Color32(0, 130, 255, 255);
            Title.text = lang.GetText("round_won_text");

            var roundCount = data.EnemyWinCount + data.MyWinCount;
            Message.text = lang.GetText(roundCount == 1 ? "starting_second_round" : "starting_last_round");
        }
        if (data.GameStatus == GameStatus.Lose)
        {
            BigRoundBg.color = new Color32(24, 10, 10, 220);
            TitleBg.color = new Color32(255, 0, 0, 255);
            Title.text = lang.GetText("round_lost_text");

            var roundCount = data.EnemyWinCount + data.MyWinCount;
            Message.text = lang.GetText(roundCount == 1 ? "starting_second_round" : "starting_last_round");
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

    /*public void ShowMessage(BigRoundInfomation data)
    {
        //bool isWin,string title, string message
        //Title.text = data.Title;

        BigRound.SetActive(true);
        var lang = LanguageManager.Instance;

        if (data.GameStatus == GameStatus.Win)
        {
            BigRoundBg.color = new Color32(10, 10, 24, 220);
            TitleBg.color = new Color32(0, 130, 255, 255);
            Title.text = lang.GetText("won_round_text");
        }
        else if (data.GameStatus == GameStatus.Lose)
        {
            BigRoundBg.color = new Color32(24, 10, 10, 220);
            TitleBg.color = new Color32(255, 0, 0, 255);
            Title.text = lang.GetText("lost_round_text");
        }
        else
        {
            BigRoundBg.color = new Color32(10, 10, 10, 220);
            TitleBg.color = new Color32(200, 130, 80, 255);
            Title.text = lang.GetText("draw_round_text");
        }
        SetMessage(data.Message);
        BigRound.SetActive(true);
    }

    public void SetMessage(string message)
    {
        //Message.text = message;
        PointShow.SetActive(false);
        MessageShow.SetActive(true);
    }*/
}
