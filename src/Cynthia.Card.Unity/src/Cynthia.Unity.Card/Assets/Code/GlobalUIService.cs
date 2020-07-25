﻿using System;
using System.Threading.Tasks;
using Alsein.Extensions.LifetimeAnnotations;
using Autofac;
using Microsoft.AspNetCore.SignalR.Client;
using UnityEngine;
using UnityEngine.Audio;
using Alsein.Extensions;

namespace Cynthia.Card.Client
{
    [Singleton]
    public class GlobalUIService
    {
        private Func<MessageBox> _messageBox;

        public GlobalUIService()
        {
            _messageBox = () => GameObject.Find("GlobalUI").transform.Find("MessageBoxBg").gameObject.GetComponent<MessageBox>();
        }
        public Task<bool> YNMessageBox(string title, string message, string yes = "yes_button", string no = "no_button", bool isOnlyYes = false)
        {
            //return _messageBox().Show(title.Replace("\\n", "\n"), message.Replace("\\n", "\n"), yes, no, isOnlyYes);
            return _messageBox().Show(title, message, yes, no, isOnlyYes);
        }

        public void Wait(string title, string message)
        {
            _messageBox().Wait(title.Replace("\\n", "\n"), message.Replace("\\n", "\n"));
        }

        public void Close()
        {
            _messageBox().Close();
        }
    }
}
