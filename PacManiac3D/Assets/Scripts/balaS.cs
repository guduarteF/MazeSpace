using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class balaS : MonoBehaviour
{

    public float veloc;
    

    private void Start()
    {
      //  transform.rotation = final.f.transform.rotation;
        
        
       

    }
   
       
        
    

    // Update is called once per frame
    void Update()
    {
        
        
            transform.Translate(Vector3.back * veloc * Time.deltaTime);
        
        
        
        

    }
  

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.transform.name);
        if (other.gameObject.CompareTag("parede"))
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);


        }
    }


}
