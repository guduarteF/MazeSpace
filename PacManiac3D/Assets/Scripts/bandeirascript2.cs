using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class bandeirascript2 : NetworkBehaviour
{
    //                                xXX BANDEIRA AZUL XXx
    private bool isready;
    private Collider otherref;
    private bool pegou;

    void Start()
    {
        StartCoroutine(espera());

    }

    // Update is called once per frame
    void Update()
    {
        pegouBandeira();

    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(1f);
        isready = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isready == true)
        {
            if (other.gameObject.CompareTag("Player2"))
            {

                otherref = other;
                pegou = true;
               



            }


        }
    }

    void pegouBandeira()
    {
        if(pegou == true)
            {
                GetComponent<Rigidbody>().MovePosition(otherref.gameObject.transform.position);
            }
        
    }


}
