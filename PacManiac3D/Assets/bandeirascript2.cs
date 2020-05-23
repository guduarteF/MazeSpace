using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bandeirascript2 : MonoBehaviour
{
    private bool isready;
    void Start()
    {
        StartCoroutine(espera());

    }

    // Update is called once per frame
    void Update()
    {
        if(isready == true)
        {
            if (final.f.isPlayer2 == true && final.f.flagA_capture == true)
            {
                GetComponent<Rigidbody>().MovePosition(final.f.transform.position);
                Debug.Log("irremediavel neon");
            }
        }
      
    }


    IEnumerator espera()
    {
        yield return new WaitForSeconds(1f);
        isready = true;
    }
}
