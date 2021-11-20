using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuildMenuController : MonoBehaviour
{
    public Button ExitButton;

    public List<MenuButton> builds = new List<MenuButton>();

    private void Start()
    {
        foreach(MenuButton menu in builds)
        {
            SetMenuButton(menu.BuildButton, menu.BuildSceneName);
        }

        ExitButton.onClick.RemoveAllListeners();
        ExitButton.onClick.AddListener(Application.Quit);
    }

    private void SetMenuButton(Button button, string Name)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => { SceneManager.LoadScene(Name, LoadSceneMode.Single); });
    }
}

[System.Serializable]
public class MenuButton
{
    public Button BuildButton;
    public string BuildSceneName;
}
