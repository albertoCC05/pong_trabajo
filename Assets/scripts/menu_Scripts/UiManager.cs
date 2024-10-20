using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class UiManager : MonoBehaviour
{
    //Reference for the inputField

    [SerializeField] private TMP_InputField player1Name;
    [SerializeField] private TMP_InputField player2Name;
    

    //Script reference

    private DataPersistance dataP;

    private void Start()
    {
        dataP = FindObjectOfType<DataPersistance>();    
    }

    // Function for get the names of the input fields

    public string GetName1()
    {
        string name1 = player1Name.text;
        return name1;
       
    }
    public string GetName2()
    {
       
        string name2 = player2Name.text;
        return name2;


    }

    // Function for go to the game, first I save the names of both imputFields and then I load game scene

    public void GoToGame()
    {
        dataP.Save();
        SceneManager.LoadScene(1);

    }

}

