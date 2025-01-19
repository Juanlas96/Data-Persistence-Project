using UnityEngine;
using System.IO;

public class MainGameManager : MonoBehaviour
{
   
    public static MainGameManager instance; // Singleton instance of this class
    public string playerName; // Current player's name
    public int bestScore; // Highest score achieved

    [System.Serializable]
    public class SaveData
    {
        public string playerName; // Player name to save
        public int bestScore; // Best score to save
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); 
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject); 
        LoadNameAndScore(); 
    }

    // Save high score
    public void SaveNameAndScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data); 
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); 
    }

    // Loads high score if exists
    public void LoadNameAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) 
        {
            string json = File.ReadAllText(path); 
            SaveData data = JsonUtility.FromJson<SaveData>(json); 
            playerName = data.playerName; 
            bestScore = data.bestScore; 
        }
        else
        {
            playerName = "Player"; 
            bestScore = 0; 
        }
    }
}
