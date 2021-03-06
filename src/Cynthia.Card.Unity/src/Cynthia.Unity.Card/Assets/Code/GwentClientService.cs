﻿using Alsein.Extensions.IO;
using Alsein.Extensions.LifetimeAnnotations;
using Autofac;
using Microsoft.AspNetCore.SignalR.Client;
using System.Linq;
using System.Threading.Tasks;
using Assets.Script.LanguageScript;
using Cynthia.Card.Common.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cynthia.Card.Client
{
    [Singleton]
    public class GwentClientService
    {
        public HubConnection HubConnection { get; set; }
        public LocalPlayer Player { get; set; }
        public UserInfo User { get; set; }
        public bool IsAutoPlay { get; set; } = false;

        private GlobalUIService _globalUIService;
        private ITubeInlet sender;/*待修改*/
        private ITubeOutlet receiver;/*待修改*/

        private ITranslator _translator;

        public Task<bool> MatchResult()
        {
            return receiver.ReceiveAsync<bool>();
        }

        public GwentClientService(HubConnection hubConnection, GlobalUIService globalUIService, ITranslator translator)
        {
            _translator = translator;
            _globalUIService = globalUIService;
            /*待修改*/
            (sender, receiver) = Tube.CreateSimplex();
            /*待修改*/
            hubConnection.On<bool>("MatchResult", async x =>
             {
                 await sender.SendAsync<bool>(x);
             });
            hubConnection.On("RepeatLogin", async () =>
            {
                SceneManager.LoadScene("LoginScene");
                await DependencyResolver.Container.Resolve<GlobalUIService>().YNMessageBox(_translator.GetText("logged_out_title"), _translator.GetText("logged_out"));
            });
            hubConnection.Closed += (async x =>
            {
                SceneManager.LoadScene("LoginScene");
                await _globalUIService.YNMessageBox(_translator.GetText("disconnected_title"),
                    _translator.GetText("disconnected").Replace("\\n", "\n"),
                    "ok_button", isOnlyYes: true);

                // LayoutRebuilder.ForceRebuildLayoutImmediate(Context);
                // var messageBox = GameObject.Find("GlobalUI").transform.Find("MessageBoxBg").gameObject.GetComponent<MessageBox>();//.Show("断开连接", "请尝试重新登陆\n注意! 在目前版本中,如果处于对局或匹配时断线,需要重新启动客户端,否则下次游戏开始时会异常卡死。\nNote!\nIn the current version, if you are disconnected when matching or Playing, you need to restart the client, otherwise the next game will start with an abnormal.".Replace("\\n", "\n"), isOnlyYes: true);
                // messageBox.Buttons.SetActive(true);
                // messageBox.YesButton.SetActive(true);
                // messageBox.NoButton.SetActive(false);
                // messageBox.TitleText.text = "断开连接";
                // messageBox.MessageText.text = "请尝试重新登陆\n注意! 在目前版本中,如果处于对局或匹配时断线,需要重新启动客户端,否则下次游戏开始时会异常卡死。\nNote!\nIn the current version, if you are disconnected when matching or Playing, you need to restart the client, otherwise the next game will start with an abnormal.".Replace("\\n", "\n");
                // messageBox.YesText.text = "确定";
                // messageBox.gameObject.SetActive(true);
                // await messageBox.receiver.ReceiveAsync<bool>();
                // LayoutRebuilder.ForceRebuildLayoutImmediate(messageBox.Context);
            });
            hubConnection.On("ExitGame", () =>
            {
                Application.Quit();
            });
            hubConnection.On<string, string, string, string, bool>("ShowMessageBox", (string title, string message, string yes, string no, bool isyes) =>
            {
                _globalUIService.YNMessageBox(title, message, yes, no, isyes);
            });
            hubConnection.On<string, string>("Wait", (string title, string message) =>
             {
                 _globalUIService.Wait(title, message);
             });
            hubConnection.On("Close", () =>
            {
                _globalUIService.Close();
            });
            hubConnection.On<string>("Test", message => Debug.Log($"收到了服务端来自Debug的信息:{message}"));
            Player = new LocalPlayer(hubConnection);
            HubConnection = hubConnection;
            hubConnection.StartAsync();
        }
        public async void ExitGameClick()
        {
            if (await _globalUIService.YNMessageBox(_translator.GetText("quit_title"), _translator.GetText("quit_confirm")))
            {
                Application.Quit();
            }
        }

        public Task<string> GetLatestVersion()
        {
            return HubConnection.InvokeAsync<string>("GetLatestVersion");
        }

        public Task<string> GetNotes()
        {
            return HubConnection.InvokeAsync<string>("GetNotes");
        }

        public Task<bool> Register(string username, string password, string playername) => HubConnection.InvokeAsync<bool>("Register", username, password, playername);
        public async Task<UserInfo> Login(string username, string password)
        {
            //登录,如果成功保存登录信息
            User = await HubConnection.InvokeAsync<UserInfo>("Login", username, password);
            if (User != null)
                Player.PlayerName = User.PlayerName;
            return User;
        }
        //开始匹配与停止匹配
        public Task<bool> MatchOfPassword(string deckId, string password)
        {
            Player.Deck = User.Decks.Single(x => x.Id == deckId);
            return HubConnection.InvokeAsync<bool>("MatchOfPassword", deckId, password);
        }
        public Task<bool> StopMatch()
        {
            return HubConnection.InvokeAsync<bool>("StopMatch");
        }
        //新建卡组,删除卡组,修改卡组
        public Task<bool> AddDeck(DeckModel deck) => HubConnection.InvokeAsync<bool>("AddDeck", deck);
        public Task<bool> RemoveDeck(string deckId) => HubConnection.InvokeAsync<bool>("RemoveDeck", deckId);
        public Task<bool> ModifyDeck(string deckId, DeckModel deck) => HubConnection.InvokeAsync<bool>("ModifyDeck", deckId, deck);
        public Task SendOperation(Task<Operation<UserOperationType>> operation) => HubConnection.SendAsync("GameOperation", operation);

        //开启连接,断开连接
        public Task StartAsync() => HubConnection.StartAsync();
        public Task StopAsync() => HubConnection.StopAsync();
    }
}