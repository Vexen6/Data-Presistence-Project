using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string playerName;
    public int highScore1;
    public int highScore2;
    public int highScore3;
    public string highScoreName1;
    public string highScoreName2;
    public string highScoreName3;

    public float speedMultiplier = 1f;

    
    // Start is called before the first frame update
    private void Awake()
    {
        //Makes this manager a singleton
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Instance = this;
        LoadScore();
        LoadSettings();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //start button code


   

    [System.Serializable]
    class SaveData
    {
        public string HighScoreName1;
        public int HighScore1;
        public string HighScoreName2;
        public int HighScore2;
        public string HighScoreName3;
        public int HighScore3;
    }
    public void SaveScore(int score)
    {
             if (score > highScore2)
            {
                if (score > highScore1)
                {
                    highScore3 = highScore2;
                    highScoreName3 = highScoreName2;
                    highScore2 = highScore1;
                    highScoreName2 = highScoreName1;
                    highScore1 = score;
                    highScoreName1 = playerName;
                }
                else
                {
                    highScore3 = highScore2;
                    highScoreName3 = highScoreName2;
                    highScore2 = score;
                    highScoreName2 = playerName;
                }
            }
            else
            {
                highScore3 = score;
                highScoreName3 = playerName;
            }    


        SaveData data = new SaveData();
        data.HighScoreName1 = highScoreName1;
        data.HighScore1 = highScore1;
        data.HighScoreName2 = highScoreName2;
        data.HighScore2 = highScore2;
        data.HighScoreName3 = highScoreName3;
        data.HighScore3 = highScore3;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName1 = data.HighScoreName1;
            highScore1 = data.HighScore1;
            highScoreName2 = data.HighScoreName2;
            highScore2 = data.HighScore2;
            highScoreName3 = data.HighScoreName3;
            highScore3 = data.HighScore3;
        }
    }

    [System.Serializable]
    class SettingsData
    {
        public float SpeedMultiplier;
    }

    public void SaveSettings(float speed)
    {
        speedMultiplier = speed;
        SettingsData settings = new SettingsData();
        settings.SpeedMultiplier = speedMultiplier;
        string json = JsonUtility.ToJson(settings);

        File.WriteAllText(Application.persistentDataPath + "/settingsfile.json", json);
    }
    public void LoadSettings()
    {
        string path = Application.persistentDataPath + "/settingsfile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SettingsData settings = JsonUtility.FromJson<SettingsData>(json);
            speedMultiplier = settings.SpeedMultiplier;
        }
    }
}
