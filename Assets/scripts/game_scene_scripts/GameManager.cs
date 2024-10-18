using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int points1;
    private int points2;

    //Ui references

    //Game Ui

    [SerializeField] private TextMeshProUGUI score1;
    [SerializeField] private TextMeshProUGUI score2;

    [SerializeField] private TextMeshProUGUI namePlayer1;
    [SerializeField] private TextMeshProUGUI namePlayer2;

    // Win panel ui

    [SerializeField] private GameObject winPanel1;
    [SerializeField] private GameObject winPanel2;
    [SerializeField] private TextMeshProUGUI player1WinText;
    [SerializeField] private TextMeshProUGUI player2WinText;

    //Script references

    private DataPersistance persistance;


  

    void Start()
    {

        //Reference of scripts

        persistance = FindObjectOfType<DataPersistance>();

        //Seting time to 1 and points to 0 at the start of the game

        points1 = 0;
        points2 = 0;
        Time.timeScale = 1;

        // Hiding the win panles

        HideWinPanel1();
        HideWinPanel2();

        // With this function I load the names of the players

        persistance.Load();
    }

    
    //Functions fot show and hide the win panels

    private void ShowWinPanel1()
    {
        winPanel1.SetActive(true);
        Time.timeScale = 0;
    }
    private void HideWinPanel1()
    {
        winPanel1.SetActive(false);
    }
    private void ShowWinPanel2()
    {
        winPanel2.SetActive(true);
        Time.timeScale = 0;
    }
    private void HideWinPanel2()
    {
        winPanel2.SetActive(false);
    }

    //Functions for add points to the players when someone scores

    public void AddPointsTo1()
    {
        points1++;
        score1.text = $"{points1}";

        if (points1 == 2)
        {
            ShowWinPanel1();
            player1WinText.text = $"{persistance.name1} Win";
        }
    }
    public void AddPointsTo2()
    {
        points2++;
        score2.text = $"{points2}";


        if (points2 == 2)
        {
            ShowWinPanel2();
            player2WinText.text = $"{persistance.name2} Win";
        }
    }

    // Functions for the buttons of both win panels

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Function for set the names of the players

    public void SetNames(string name1, string name2)
    {
        namePlayer1.text = name1;
        namePlayer2.text = name2;
       
        
    } 
  
}
