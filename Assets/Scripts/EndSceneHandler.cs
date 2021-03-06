﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneHandler : MonoBehaviour
{
    public Text gameResult;

    public int prevLevel;

    /**
     * check if game has been ended by win or by loss and display
     * correct screen
     */
    void Start()
    {
        prevLevel = SceneHandler.levelDifficulty;
        if (SceneHandler.hasWon == true)
        {
            FindObjectOfType<Text>().color = Color.green;
            gameResult.text = "success!";
        }
        else
        {
            FindObjectOfType<Text>().color = Color.red;
            if (MarathonHandler.isMarathon)
            {
                prevLevel = MarathonHandler.levelDifficulty;
                gameResult.text = "You made" + "\n" + "it through: " + "\n" + (MarathonHandler.marathonRound + 1) + " round(s)!";
                MarathonHandler.isMarathon = false;
            }
            else
            {
                gameResult.text = "oh no! you failed!";
            }
        }
    }

    /** Load start screne */
    public void StartAgain()
    {
        // deletes audio so it doesn't duplicate
        if (GameObject.FindGameObjectWithTag("Audio") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Audio"));
        }
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }

    /** Load game scene again */
    public void PlayAgain()
    {
        if(prevLevel == 0)
        {
            prevLevel = 2;
        }
        switch (prevLevel)
        {
            case 1:
                SceneManager.LoadScene("EasyGameScene", LoadSceneMode.Single);
                break;
            case 2:
                SceneManager.LoadScene("RegularGameScene", LoadSceneMode.Single);
                break;
            case 3:
                SceneManager.LoadScene("HardGameScene", LoadSceneMode.Single);
                break;
            case 4:
                SceneManager.LoadScene("MarathonGameScene", LoadSceneMode.Single);
                break;
            default:
                break;
        }
    }
}
