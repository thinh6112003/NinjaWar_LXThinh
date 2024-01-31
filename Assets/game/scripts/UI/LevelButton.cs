using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public Button levelButton;
    [SerializeField] public TextMeshProUGUI textButton;
    public void SetData(int id)
    {
        textButton.text = $"Level {id}";
        levelButton.onClick.AddListener(() =>
        {
            GameObject levelPrefab = Resources.Load<GameObject>($"Level{id}");
            Instantiate(levelPrefab);
            LevelManager.Instance.DestroyLevelManager();
            LevelManager.Instance.SpawnPlayer();
            UIManager.instance.panelGamePlay.SetActive(true);
        });
    }
}
