using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LauncherManager : MonoBehaviour
{
    public List<Button> gameStartButtons;
    private void Awake()
    {
        foreach (var item in gameStartButtons)
        {
            item.onClick.AddListener(() => LaunchGame());
        }
    }
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    void LaunchGame()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
        SceneManager.LoadScene("Game");
    }

}
