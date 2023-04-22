using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public void GameStart()
    {
        //Save Player name
        nameInput = GameObject.Find("Name Input Field").GetComponent<TMP_InputField>();
        ScoreManager.Instance.playerName = nameInput.text;
        //Load next Scene
        SceneManager.LoadScene(1);
    }

    public void HighScoreTable()
    {
        SceneManager.LoadScene(2);
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene(3);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
