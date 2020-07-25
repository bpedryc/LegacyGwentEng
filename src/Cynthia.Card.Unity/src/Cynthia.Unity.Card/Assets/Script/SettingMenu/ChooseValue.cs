using Cynthia.Card.Common.Models;
using System;
using Autofac;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChooseValue : MonoBehaviour
{
    private ITranslator _translator;

    public string[] ChoseList;
    private int _index = 0;
    public int Index
    {
        get => _index;
        set
        {
            _index = value;

            if (_translator == null)
            {
                this.Awake();
            }

            ShowText.text = _translator.GetText(ChoseList[Index]);
            onValueChanged.Invoke(Index);
        }
    }
    [Serializable]
    public class ChoseValueEvent : UnityEvent<int>
    { }
    public ChoseValueEvent onValueChanged = new ChoseValueEvent();

    public Text ShowText;
    private void Awake()
    {
        _translator = DependencyResolver.Container.Resolve<ITranslator>();
    }
    private void Start()
    {
        ShowText.text = _translator.GetText(ChoseList[Index]);
    }

    public void LeftButtonClick()
    {
        if (Index - 1 < 0)
        {
            Index = ChoseList.Length - 1;
            return;
        }
        Index--;
    }
    public void RightButtonClick()
    {
        if (Index + 1 >= ChoseList.Length)
        {
            Index = 0;
            return;
        }
        Index++;
    }
}
