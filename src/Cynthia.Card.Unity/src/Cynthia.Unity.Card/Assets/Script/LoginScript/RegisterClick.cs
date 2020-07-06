using Cynthia.Card.Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Autofac;
using System;
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
        if (IsRegistering) return;
        IsRegistering = true;
        if (Password.text.Length == 0 || Username.text.Length == 0 || Playername.text.Length == 0)
        {
            RegisterMessage.text = "Input data cannot be empty. Try again.";
            IsRegistering = false;
            return;
        }
        if (Password.text != Password2.text)
        {
            RegisterMessage.text = "The passwords are not identical. Try again.";
            IsRegistering = false;
            return;
        }
        RegisterMessage.text = "Registering.. Please wait..";
        try
        {
            var hub = DependencyResolver.Container.Resolve<HubConnection>();
            if (hub.State == HubConnectionState.Disconnected)
                await hub.StartAsync();
            var result = await server.Register(Username.text, Password.text, Playername.text);
            if (!result)
            {
                RegisterMessage.text = "Registration failed. A user with the same username or nickname already exists.";
                IsRegistering = false;
                return;
            }
            IsRegistering = false;
            RegisterMessage.text = "Registration successful. Press the \'back\' button to return to the login page.";
        }
        catch (Exception e)
        {
            RegisterMessage.text = "There's been an error. The server may have been shut down.";
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
