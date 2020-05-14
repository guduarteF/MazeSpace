using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class placar : MonoBehaviour
{
    public TextMesh Texto;
    public Text placarText;
    public static int playerpoints, enemypoints;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        placarText.text = playerpoints + "x" + enemypoints;



    }

   


}
