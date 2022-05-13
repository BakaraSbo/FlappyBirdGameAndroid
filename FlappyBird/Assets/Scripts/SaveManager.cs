using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public Save state;
    public HighScores scores;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        Debug.Log(HelpingFunctions.Serialize<Save>(state));
    }
    //Saving to player prefs
    public void Save()
    {
        state.scores = scores.scores;
        PlayerPrefs.SetString("save", HelpingFunctions.Serialize<Save>(state));
    }
    //Loading from player prefs
    public void Load()
    {
        if (PlayerPrefs.HasKey("safe"))
        {
            state = HelpingFunctions.Deserialize<Save>(PlayerPrefs.GetString("safe"));
        }
        else
        {
            state = new Save();
            Save();
            Debug.Log("No save file found creating new one");
        }
        scores.scores = state.scores;
    }



}
