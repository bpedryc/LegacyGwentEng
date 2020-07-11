﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.GlobalUI
{
    public class Translator : MonoBehaviour
    {
        public List<Translatable> ObjectsToTranslate;
        void Start()
        {
            TranslateAll();
        }

        private void TranslateAll()
        {
            foreach (var entry in ObjectsToTranslate)
            {
                var textId = entry.Id;
                try
                {
                    var textContent = entry.TextObject.GetComponent<Text>();
                    textContent.text = LanguageManager.Instance.GetText(textId);
                }
                catch (NullReferenceException exception)
                {
                    Debug.Log($"{exception.Message}. Faulty object is: {entry.TextObject.name}");
                }
            }
        }
    }
}
