using Alsein.Extensions.IO;
using System.Threading.Tasks;
using Assets.Script.LanguageScript;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    public Text TitleText;
    public Text MessageText;
    public Text YesText;
    public Text NoText;
    public GameObject YesButton;
    public GameObject NoButton;
    public GameObject Buttons;
    public ITubeInlet sender;
    public ITubeOutlet receiver;
    //private IAsyncDataSender sender;
    //private IAsyncDataReceiver receiver;
    public RectTransform Context;
    private void Awake()
    {
        (sender, receiver) = Tube.CreateSimplex();
    }
    public void Wait(string title, string message)
    {
        Buttons.SetActive(false);
        TitleText.text = title;
        MessageText.text = message;
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
        Buttons.SetActive(true);
    }
    public Task<bool> Show(string title, string message, string yes = "yes_button", string no = "no_button", bool isOnlyYes = false)
    {
        Buttons.SetActive(true);
        if (isOnlyYes)
        {
            YesButton.SetActive(true);
            NoButton.SetActive(false);
        }
        else
        {
            YesButton.SetActive(true);
            NoButton.SetActive(true);
        }
        TitleText.text = title;
        MessageText.text = message;
        YesText.text = LanguageManager.Instance.GetText(yes);
        NoText.text = LanguageManager.Instance.GetText(no);
        gameObject.SetActive(true);
        return receiver.ReceiveAsync<bool>();
    }
    public void YesClick()
    {
        sender.SendAsync<bool>(true);
        gameObject.SetActive(false);
    }
    public void NoClick()
    {
        sender.SendAsync<bool>(false);
        gameObject.SetActive(false);
    }
}
