using Cynthia.Card.Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Autofac;
using System;
using Assets.Script.GlobalUI;
using Microsoft.AspNetCore.SignalR.Client;

public class RegisterClick : MonoBehaviour
{
    private static bool IsRegistering = false;
    public InputField Username;
    public InputField Playername;
    public InputField Password;
    public InputField Password2;
    public Text RegisterMessage;
    public Text LoginMessage;

    private GwentClientService server;

    private void Start()
    {
        if (server != null)
            return;
        server = DependencyResolver.Container.Resolve<GwentClientService>();
    }
    public async void Register()
    {
        var lang = LanguageManager.Instance;

        if (IsRegistering) return;
        IsRegistering = true;
        if (Password.text.Length == 0 || Username.text.Length == 0 || Playername.text.Length == 0)
        {
            RegisterMessage.text = lang.GetText("register_empty_input");
            IsRegistering = false;
            return;
        }
        if (Password.text != Password2.text)
        {
            RegisterMessage.text = lang.GetText("passwords_not_identical");
            IsRegistering = false;
            return;
        }
        RegisterMessage.text = lang.GetText("registering");
        try
        {
            var hub = DependencyResolver.Container.Resolve<HubConnection>();
            if (hub.State == HubConnectionState.Disconnected)
                await hub.StartAsync();
            var result = await server.Register(Username.text, Password.text, Playername.text);
            if (!result)
            {
                RegisterMessage.text = lang.GetText("error_already_registered");
                IsRegistering = false;
                return;
            }
            IsRegistering = false;
            RegisterMessage.text = lang.GetText("registration_successful");
        }
        catch (Exception e)
        {
            RegisterMessage.text = lang.GetText("error_registration");
            Debug.Log(e.Message);
        }
        finally
        {
            IsRegistering = false;
        }
    }
    public void Clean()
    {
        Username.text = "";
        Playername.text = "";
        Password.text = "";
        Password2.text = "";
        RegisterMessage.text = "";
    }
}
