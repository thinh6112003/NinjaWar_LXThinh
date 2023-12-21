using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelData scriptableObject;
    [SerializeField] private Transform buttonsParent;
    [SerializeField] private LevelButton buttonPrefab;
    [SerializeField] private GameObject levelPanel;
    public static LevelManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        SpawnButtons();
    }
    private void SpawnButtons()
    {
        foreach (Level item in scriptableObject.listLevel)
        {
            LevelButton levelButton = Instantiate(buttonPrefab, buttonsParent);
            levelButton.name = $"Level {item.id}";
            levelButton.SetData(item.id);
        }
    }
    public void DestroyLevelManager()
    {
        levelPanel.SetActive(false);
    }
}
