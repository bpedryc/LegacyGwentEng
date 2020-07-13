using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using Cynthia.Card;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Script.GlobalUI
{
    public enum Language
    {
        Chinese,
        English,
        Polish
    }

    class LanguageManager
    {
        private static LanguageManager _instance;
        public static LanguageManager Instance => _instance ?? (_instance = new LanguageManager());
        private Dictionary<string, string> Texts = new Dictionary<string, string>();

        private Language _setLanguage = Language.Chinese;
        public Language SetLanguage
        {
            get => _setLanguage;
            set
            {
                if (!Enum.IsDefined(typeof(Language), value))
                    throw new InvalidEnumArgumentException(nameof(value), (int) value, typeof(Language));
                _setLanguage = value;
                LoadTexts();
            }
        }
        
        public LanguageManager()
        {
            LoadTexts();
        }
        private void LoadTexts()
        {
            var langFilePath = $"{Application.dataPath}\\Locales\\{GetFilename(SetLanguage)}.xml";
            var document = new XmlDocument();
            document.Load(langFilePath);
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
        public static string GetFilename(Language language)
        {
            string filename;
            switch (language)
            {
                case Language.Chinese:
                    filename = "zh";
                    break;
                case Language.English:
                    filename = "en";
                    break;
                case Language.Polish:
                    filename = "pl";
                    break;
                default:
                    filename = "en";
                    break;
            }

            return filename;
        }
        public string GetText(string id)
        {
            return Texts.ContainsKey(id) ? Texts[id] : id;
        }

        public void MakeXML()
        {
            var doc = new XmlDocument();
            var root = doc.CreateElement("entries");
            doc.AppendChild(root);

            var cardBase = GwentMap.CardMap;
            foreach (var card in cardBase)
            {
                var id = card.Key;
                var contents = card.Value;

                var nameElement = doc.CreateElement("entry");
                nameElement.InnerText = contents.Name;
                var nameAttr = doc.CreateAttribute("id");
                nameAttr.Value = $"card_{id}_name";
                nameElement.Attributes.Append(nameAttr);
                root.AppendChild(nameElement);

                var infoElement = doc.CreateElement("entry");
                infoElement.InnerText = contents.Info;
                var infoAttr = doc.CreateAttribute("id");
                infoAttr.Value = $"card_{id}_info";
                infoElement.Attributes.Append(infoAttr);
                root.AppendChild(infoElement);

                var flavorElement = doc.CreateElement("entry");
                flavorElement.InnerText = contents.Flavor;
                var flavorAttr = doc.CreateAttribute("id");
                flavorAttr.Value = $"card_{id}_flavor";
                flavorElement.Attributes.Append(flavorAttr);
                root.AppendChild(flavorElement);
            }

            doc.Save("CardLocale.xml");
        }
    }
}
