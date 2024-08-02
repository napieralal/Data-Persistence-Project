using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerNameInput;
    public TextMeshProUGUI maxScoreText;

    void Start()
    {
        LoadMaxScore();
    }

    public void StartGame() {
        Debug.Log(playerNameInput.text);
        PlayerPrefs.SetString("CurrentPlayerName", playerNameInput.text);

        SceneManager.LoadScene(1);
    }

    public void LoadMaxScore() {
        maxScoreText.text = "Best Score: " + MainGameManager.Instance.maxScore + " Name: " + MainGameManager.Instance.playerName;
    }

    public void Quit() {
        Application.Quit();
    }
}
