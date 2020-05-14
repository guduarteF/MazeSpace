using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    public GameObject canvasfinal;
    public static bool empate;
   
    

    // Start is called before the first frame update
    void Start()
    {
        canvasfinal.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
        if(placar.playerpoints >= 5 && empate == false)
        {
            canvasfinal.SetActive(true);
            


        }
        if (placar.enemypoints >= 5 &&  empate == false)
        {
            canvasfinal.SetActive(true);
            

        }

        if (placar.enemypoints >= 5 && placar.playerpoints >= 5)
        {
            empate = true;
            
        }

        if (empate == true)
        {
            canvasfinal.SetActive(true);
            
        }

        if (placar.enemypoints >= 5 && placar.playerpoints >= 5)
        {
            empate = true;
        }
    }
}
