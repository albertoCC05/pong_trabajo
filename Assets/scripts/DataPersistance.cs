using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistance : MonoBehaviour
{
    //Script references

    private UiManager uiManager;
    private GameManager gameManager;

    // Name for the saving files for save the names of both players

    private string NAME1 = "name1";
    private string NAME2 = "name2";

    // Varibles that saves the name of the players

    public string name1;
    public string name2;




    private void Start()
    {
        uiManager = FindObjectOfType<UiManager>();
        
        
    }

    //Function for save the names when you click the button of start in main menu scene

    public void Save()
    {
        string name1 = uiManager.GetName1();
        string name2 = uiManager.GetName2();

        PlayerPrefs.SetString(NAME1, name1);
        PlayerPrefs.SetString(NAME2, name2);

        Debug.Log($"  {PlayerPrefs.GetString(NAME1)} ");
 
    }

    // Functio for load and set the names of the players

    public void Load()
    {
        if (PlayerPrefs.HasKey(NAME1))
        {
            string namePlayer1 = PlayerPrefs.GetString(NAME1);
            string namePlayer2 = PlayerPrefs.GetString(NAME2);

            name1 = PlayerPrefs.GetString(NAME1);
            name2 = PlayerPrefs.GetString(NAME2);

            gameManager = FindObjectOfType<GameManager>();
            gameManager.SetNames(namePlayer1, namePlayer2);

        }

    }
}
