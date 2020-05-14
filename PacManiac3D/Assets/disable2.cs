using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable2 : MonoBehaviour
{
    public SphereCollider[] sphere;

  void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        metodo();
    }

    void metodo()
    {
        for (int i = 0; i < sphere.Length; i++)
        {
            if (enemy.disabilita == true)
            {
                sphere[i].enabled = false;
            }
            else
            {
                sphere[i].enabled = true;
            }

        }
    }
}
