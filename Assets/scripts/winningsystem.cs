using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winningsystem : MonoBehaviour
{
    public Text AIScore;
    public Text PlayerScore;
    public Button resetButton;
    public BallMovement ballMovement;

    private bool gameEnded = false;

    private void Start()
    {
        resetButton.gameObject.SetActive(false);
    }

    private void EndGame()
    {
        if (AIScore.text == "10" || PlayerScore.text == "10")
        {
            DisplayWinMessage();
        }
    }

    private void DisplayWinMessage()
    {
        Debug.Log("Game over! Someone wins!");

        resetButton.gameObject.SetActive(true);
        gameEnded = true;
    }

    public void ResetGame()
    {
        AIScore.text = "0";
        PlayerScore.text = "0";
        ballMovement.transform.position = new Vector3(0, 0, 0);
        resetButton.gameObject.SetActive(false);
        gameEnded = false;
    }

    public bool IsGameEnded()
    {
        return gameEnded;
    }

    void Update()
    {
        if (!gameEnded)
        {
            EndGame();
        }
    }
}