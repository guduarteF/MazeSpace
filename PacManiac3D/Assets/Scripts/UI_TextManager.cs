using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TextManager : MonoBehaviour
{
    [SerializeField]
    public  GameObject textgo;
    public  Text textui;
    public static UI_TextManager ui;
    void Start()
    {
        ui = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
