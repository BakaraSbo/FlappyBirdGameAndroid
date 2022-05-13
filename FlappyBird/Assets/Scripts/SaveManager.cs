using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public Save state;
    public HighScores inGameScoreHolder;
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
        //Setting data for saving from ingame holder.
        state.scores = inGameScoreHolder.scores;
        PlayerPrefs.SetString("save", HelpingFunctions.Serialize<Save>(state));
    }
    //Loading from player prefs
    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = HelpingFunctions.Deserialize<Save>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new Save();
            Save();
            Debug.Log("No save file found creating new one");
        }
        //Setting our in game holder for score to be one from player prefs.
        inGameScoreHolder.scores = state.scores;
    }



}
