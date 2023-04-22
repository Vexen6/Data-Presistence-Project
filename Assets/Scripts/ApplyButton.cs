using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplyButton : MonoBehaviour
{
    
    public Slider speedSlider;
    public void Apply()
    {
        ScoreManager.Instance.SaveSettings(speedSlider.value);
        SceneManager.LoadScene(0);
    }
}
