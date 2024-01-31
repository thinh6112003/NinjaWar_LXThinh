using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject gamePlayPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject offMusicbtn;
    [SerializeField] private GameObject onMusicbtn;

    [SerializeField] private GameObject level1MapPrefab;
    [SerializeField] private GameObject level2MapPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject canvasHealth;


    [SerializeField] private Button startButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button exitSettingButton;
    [SerializeField] private Button onMusicButton;
    [SerializeField] private Button offMusicButton;

    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private Button level4Button;
    [SerializeField] private Button level5Button;


    public void OnEnable()
    {
        startButton.onClick.AddListener(StartButton);
        settingButton.onClick.AddListener(SettingButton);
        exitSettingButton.onClick.AddListener(ExitSettingButton);
        onMusicButton.onClick.AddListener(OnMusicButton);
        offMusicButton.onClick.AddListener(OffMusicButton);
        level1Button.onClick.AddListener(Level1Button);
        level2Button.onClick.AddListener(Level2Button);
        level3Button.onClick.AddListener(Level2Button);
        level4Button.onClick.AddListener(Level2Button);
        level5Button.onClick.AddListener(Level2Button);
        
    }

    private void OffMusicButton()
    {
        onMusicbtn.SetActive(true);
        offMusicbtn.SetActive(false);
    }

    private void OnMusicButton()
    {
        onMusicbtn.SetActive(false);
        offMusicbtn.SetActive(true);
    }

    private void ExitSettingButton()
    {
        mainMenuPanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    private void SettingButton()
    {
        mainMenuPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    private void StartButton()
    {
        levelPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void Level1Button()
    {

        canvasHealth.SetActive(true);
        levelPanel.SetActive(false);
        player.SetActive(true);
        gamePlayPanel.SetActive(true);
        Instantiate(level1MapPrefab);
    }
    public void Level2Button()
    {
        canvasHealth.SetActive(true);
        levelPanel.SetActive(false);
        player.SetActive(true);
        gamePlayPanel.SetActive(true);
        Instantiate(level2MapPrefab);
    } 
   
}
