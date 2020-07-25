using System.Runtime.InteropServices.WindowsRuntime;
using Alsein.Extensions.IO;
using System.Threading.Tasks;
using Assets.Script.LanguageScript;
using Autofac;
using Cynthia.Card.Common.Models;
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

    private ITranslator _translator;

    private void Awake()
    {
        (sender, receiver) = Tube.CreateSimplex();
        _translator = DependencyResolver.Container.Resolve<ITranslator>();
    }
    public void Wait(string title, string message)
    {
        Buttons.SetActive(false);
        gameObject.SetActive(true);
        TitleText.text = _translator.GetText(title);
        MessageText.text = _translator.GetText(message);
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
        gameObject.SetActive(true);
        TitleText.text = _translator.GetText(title);
        MessageText.text = _translator.GetText(message);
        YesText.text = _translator.GetText(yes);
        NoText.text = _translator.GetText(no);
        return receiver.ReceiveAsync<bool>();
    }
    public void YesClick()
    {
        sender.SendAsync(true);
        gameObject.SetActive(false);
    }
    public void NoClick()
    {
        sender.SendAsync(false);
        gameObject.SetActive(false);
    }
}
