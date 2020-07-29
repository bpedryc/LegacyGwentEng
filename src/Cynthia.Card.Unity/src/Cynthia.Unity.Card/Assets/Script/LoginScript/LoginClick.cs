using Autofac;
using Cynthia.Card.Client;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using Assets.Script.LanguageScript;
using Cynthia.Card.Common.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginClick : MonoBehaviour
{
    private static bool IsLogining = false;

    public InputField Username;

    public InputField Password;

    public Text LogMessage;

    public Toggle RecordStatus;

    private GwentClientService _client;
    private ITranslator _translator;

    private void Start()
    {
        RecordStatus.isOn = PlayerPrefs.GetInt("RecordBox", 0) != 0;
        if (RecordStatus.isOn)
        {
            Username.text = PlayerPrefs.GetString("Username", "");
            Password.text = PlayerPrefs.GetString("Password", "");
        }
        RecordStatus.onValueChanged.AddListener(x =>
        {
            PlayerPrefs.SetInt("RecordBox", x ? 1 : 0);
            IsOnPreservation(x);
        });
        Username.onValueChanged.AddListener(x =>
        {
            IsOnPreservation(RecordStatus.isOn);
        });
        Password.onValueChanged.AddListener(x =>
        {
            IsOnPreservation(RecordStatus.isOn);
        });
        if (_client != null)
            return;
        _client = DependencyResolver.Container.Resolve<GwentClientService>();
        _translator = DependencyResolver.Container.Resolve<ITranslator>();
    }
    public async void Login()
    {
        if (IsLogining) return;
        IsLogining = true;
        LogMessage.text = _translator.GetText("logging_in");
        try
        {
            var hub = DependencyResolver.Container.Resolve<HubConnection>();
            if (hub.State == HubConnectionState.Disconnected)
                await hub.StartAsync();
            await _client.Login(Username.text, Password.text);
            if (_client.User == null)
            {
                LogMessage.text = _translator.GetText("wrong_credentials");
                IsLogining = false;
                return;
            }
            LogMessage.text = string.Format(_translator.GetText("login_welcome"), _client.User.PlayerName);
            SceneManager.LoadScene("Game");
            IsLogining = false;
        }
        catch (Exception exception)
        {
            //await DependencyResolver.Container.Resolve<HubConnection>().StartAsync();
            //await _client.Login(Username.text, Password.text);
            //if (_client.User == null)
            //{
            LogMessage.text = exception.Message;
            //    return;
            //}
        }
        finally
        {
            // Debug.Log("执行了!finally");
            IsLogining = false;
        }
    }
    public void Clean()
    {
        Username.text = "";
        Password.text = "";
        LogMessage.text = "";
    }
    void IsOnPreservation(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetString("Username", Username.text);
            PlayerPrefs.SetString("Password", Password.text);
        }
    }
}
