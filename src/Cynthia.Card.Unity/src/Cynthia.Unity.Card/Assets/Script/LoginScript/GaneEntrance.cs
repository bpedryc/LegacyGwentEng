using Autofac;
using Cynthia.Card;
using Cynthia.Card.Client;
using System;
using Assets.Script.LanguageScript;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GaneEntrance : MonoBehaviour
{
    public GameObject GlobalUI;
    public GameObject AudioSound;
    public AudioMixer AudioMixer;

    public Text NowVersionText;
    public Text LatestVersionText;
    public Text NotesText;

    public Translator Translator;
    private GwentClientService _gwentClientService;

    private void Start()
    {
        _gwentClientService = DependencyResolver.Container.Resolve<GwentClientService>();
        GwentMap.Translator = LanguageManager.Instance;
        Debug.Log(_gwentClientService);
        Debug.Log(_gwentClientService.HubConnection.State);
        ConfigureGame();
        LoadServerMessage();
    }

    public void ExitClick()
    {
        _gwentClientService.ExitGameClick();
    }

    public async void LoadServerMessage()
    {
        try
        {
            var version = new Version(await _gwentClientService.GetLatestVersion());
            LatestVersionText.text = string.Format(LanguageManager.Instance.GetText("latest_version_info"), version);
        }
        catch
        {
            if (LatestVersionText != null)
            {
                LatestVersionText.text = LanguageManager.Instance.GetText("latest_version_error");
            }
        }
        try
        {
            NotesText.text = (await _gwentClientService.GetNotes()).Replace("\\n", "\n");
        }
        catch
        {
            if (NotesText != null)
            {
                NotesText.text = LanguageManager.Instance.GetText("news_error");
                NotesText.alignment = TextAnchor.UpperLeft;
            }
        }
    }

    public void ConfigureGame()
    {
        if (ClientGlobalInfo.IsLoadGlobal) return;
        ClientGlobalInfo.IsLoadGlobal = true;
        var globalUI = Instantiate(GlobalUI);
        var musicSource = Instantiate(AudioSound);
        globalUI.name = "GlobalUI";
        musicSource.name = "MusicSource";
        DontDestroyOnLoad(globalUI);
        DontDestroyOnLoad(musicSource);

        SetResolution(PlayerPrefs.GetInt("resolutionIndex", 2));
        SetQuality(PlayerPrefs.GetInt("quality", 2));
        SetCloseSound(PlayerPrefs.GetInt("isCloseSound", 1));
        SetMusic(PlayerPrefs.GetInt("musicVolum", 5));
        SetEffect(PlayerPrefs.GetInt("effectVolum", 5));
        NowVersionText.text = string.Format(LanguageManager.Instance.GetText("current_version_info"),
            ClientGlobalInfo.Version);
    }

    private void SetLanguage(int languageIndex)
    {
        var lang = LanguageManager.Instance;
        lang.GameLanguage = languageIndex;
        PlayerPrefs.SetInt("language", lang.GameLanguage);
    }

    public void NextLanguage()
    {
        var lang = LanguageManager.Instance;
        SetLanguage(lang.GameLanguage + 1);
        Translator.TranslateAll();

        NowVersionText.text = string.Format(LanguageManager.Instance.GetText("current_version_info"),
            ClientGlobalInfo.Version);
        LoadServerMessage();

    }

    public Resolution IndexToResolution(int index)
    {
        Resolution resolution = new Resolution();
        switch (index)
        {
            case 0:
                resolution.width = 1024;
                resolution.height = 576;
                break;
            case 1:
                resolution.width = 1600;
                resolution.height = 900;
                break;
            case 2:
                resolution.width = 1920;
                resolution.height = 1080;
                break;
            default:
                resolution.width = 1920;
                resolution.height = 1080;
                break;
        }
        return resolution;
    }

    //屏幕分辨率
    public void SetResolution(int index)
    {
#if !UNITY_ANDROID
        PlayerPrefs.SetInt("resolutionIndex", index);
        var screenResolution = IndexToResolution(index);
        var isFullScreen = ((PlayerPrefs.GetInt("isFull", 0) == 0) ? true : false);
        Screen.SetResolution(screenResolution.width, screenResolution.height, isFullScreen);
#endif
    }

    //设置背景音乐大小
    public void SetMusic(int volum)
    {
        PlayerPrefs.SetInt("musicVolum", volum);
        AudioMixer.SetFloat("musicVolum", (float)((volum * 8) - 80));
    }

    //设置音效大小
    public void SetEffect(int volum)
    {
        PlayerPrefs.SetInt("effectVolum", volum);
        AudioMixer.SetFloat("effectVolum", (float)((volum * 8) - 80));
    }

    //设置画质
    public void SetQuality(int qualityIndex)
    {
        PlayerPrefs.SetInt("quality", qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //设置静音
    public void SetCloseSound(int isClose)
    {
        PlayerPrefs.SetInt("isCloseSound", isClose);
        var isCloseSound = ((isClose == 0) ? true : false);
        if (isCloseSound)
        {
            //AudioSource.GetComponent<AudioSource>().Pause();
            AudioMixer.SetFloat("volum", -80);
            return;
        }
        //AudioSource.GetComponent<AudioSource>().Play();
        AudioMixer.SetFloat("volum", 0);
    }
}
