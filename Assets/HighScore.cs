using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    static public int highScore = 10;
    private Text hsText;

    void Awake()
    {
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
        {
            highScore = PlayerPrefs.GetInt("ApplePickerHighScore");
        }
        PlayerPrefs.SetInt("ApplePickerHighScore", highScore);
    }

	void Start ()
    {
        hsText = GetComponent<Text>();
        updateHighScore(highScore);
	}
	
	public void updateHighScore (int newScore)
    {
        highScore = newScore;
        hsText.text = "High Score: " + highScore;
        PlayerPrefs.SetInt("ApplePickerHighScore", highScore);


    }
}
