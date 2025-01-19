using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{

    public TMP_InputField nameInput;
    public TextMeshProUGUI highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        LoadBestScore();
    }

    // Start the game and set the current name
    public void StartGame()
    {
        PlayerPrefs.SetString("CurrentPlayerName", nameInput.text);
        SceneManager.LoadScene(1);
    }
    // Load the best score between sessions
    public void LoadBestScore()
    {
        highScoreText.text = "High Score: " + MainGameManager.instance.bestScore + " " + MainGameManager.instance.playerName;
    }

    // Quit the game
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
