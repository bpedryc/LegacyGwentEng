﻿using Cynthia.Card.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml;
using UnityEngine;

namespace Assets.Script.LanguageScript
{
    class LanguageManager : ITranslator
    {
        private static LanguageManager _instance;
        public static LanguageManager Instance => _instance ?? (_instance = new LanguageManager());
        private Dictionary<string, string> Texts = new Dictionary<string, string>();

        private static readonly List<GameLocale> Locales = new List<GameLocale>(){
            new GameLocale("English", "en"),
            new GameLocale("Chinese", "zh")
        };
        private GameLocale _gameLanguage;

        public int GameLanguage
        {
            get => Locales.IndexOf(_gameLanguage);
            set
            {
                if (value >= Locales.Count || value < 0)
                {
                    value = 0;
                }
                _gameLanguage = Locales[value];
                LoadTexts();
            }
        }

        public LanguageManager()
        {
            GameLanguage = PlayerPrefs.GetInt("language", 0);
        }
        private void LoadTexts()
        {
            Texts.Clear();

            var localeFile = Resources.Load<TextAsset>($"Locales/{_gameLanguage.Filename}");
            var document = new XmlDocument();
            document.Load(new StringReader(localeFile.text));
            if (document.DocumentElement == null)
                return;

            var nodes = document.DocumentElement.ChildNodes;
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes == null)
                    continue;

                var id = node.Attributes["id"].Value;
                var val = node.InnerText;
                if (Texts.ContainsKey(id))
                {
                    throw new ArgumentException(
                        $"An item with the same key has already been added. Locale file has two entries with the same id : \"{id}\"");
                }
                if (!string.IsNullOrWhiteSpace(id))
                {
                    Texts.Add(id, val);
                }
            }
        }
        public string GetText(string id)
        {
            return Texts.ContainsKey(id) ? Texts[id] : id;
        }
    }
}
