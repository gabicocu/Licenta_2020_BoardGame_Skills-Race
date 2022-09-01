using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuScript : MonoBehaviour
{
    public static string player2Name = "Computer";
    public static string player1Name = "Player1";
    public static string color1Name;
    public static string color2Name = "yellow";
    public static bool computer = true;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }
}
