﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class placar : NetworkBehaviour
{
    public TextMesh Texto;
    [SyncVar] 
    Text placarText;
    
   
    
    public static int playerpoints, enemypoints;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer)
        {
            placarTxt(placarText);
        }
       


    }

   void placarTxt(Text placarText)
    {
        placarText.text = playerpoints + "x" + enemypoints;
    }


}
