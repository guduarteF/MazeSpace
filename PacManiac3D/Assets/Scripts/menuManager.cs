using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    public Text winner;
   

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(placar.playerpoints >= 5 && gameover.empate == false)
        {
           
            winner.text = "Player 1 Wins";


        }

        if (placar.enemypoints >= 5 && gameover.empate == false)
        {
          
            winner.text = "Player 2 Wins";
        }



        if (gameover.empate == true)
        {
            
            winner.text = "DRAW";
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        placar.playerpoints = 0;
        placar.enemypoints = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        Time.timeScale = 0;

    }

    public void Controls()
    {
        SceneManager.LoadScene(2);   
    }

    public static IEnumerator RestartDelay()
    {       
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }

   
}

