using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_Path : MonoBehaviour
{
    public static follow_Path pat;
    public float deploymentHeight;

    private RaycastHit pontoDeColisao1;
    private RaycastHit pontoDeColisao2;
    private RaycastHit pontoDeColisao3;
    private RaycastHit pontoDeColisao4;

    public LayerMask center;
    public LayerMask points;
   
    public bool ismovingW;
    public bool ismovingS;
    public bool ismovingA;
    public bool ismovingD;

    public bool terminointer;
    public bool terminocenter;

    private int numb;
    public bool var;

    
    public bool disabilita;

    public GameObject bala;
    public GameObject spawnPoint;

    public float fire_rate = 2f;
    public float time_between_shoots;

   



    
  
    void Start()
    {
        pat = this;
        ismovingA = false;
        ismovingD = false;
        ismovingS = false;
        ismovingW = false;
        terminointer = false;        
        terminocenter = false;
        var = true;
        disabilita = true;
       


    }

    // Update is called once per frame
    void Update()
    {
        #region movement

        // XXXXXXXXXXXXXXXXXXXX TERMINOCENTER XXXXXXXXXXXXXXXXXXXXXX
        if (terminocenter == true && ismovingA == false && ismovingD == false && ismovingS == false && ismovingW==false)
        {
            if (Input.GetKeyUp(KeyCode.W) && Physics.Raycast(transform.position, Vector3.forward, out pontoDeColisao1, deploymentHeight, points) && ismovingD == false && ismovingA == false && ismovingS == false && ismovingD == false && ismovingW == false)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                ismovingW = true;

            }

            if (Input.GetKeyUp(KeyCode.D) && Physics.Raycast(transform.position, Vector3.right, out pontoDeColisao3, deploymentHeight, points) && ismovingW == false && ismovingA == false && ismovingS == false && ismovingD == false)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                ismovingD = true;
             
            }

            if (Input.GetKeyUp(KeyCode.A) && Physics.Raycast(transform.position, -Vector3.right, out pontoDeColisao2, deploymentHeight, points) && ismovingW == false && ismovingS == false && ismovingD == false && ismovingA == false)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                ismovingA = true;
               

            }
            if (Input.GetKeyUp(KeyCode.S) && Physics.Raycast(transform.position, -Vector3.forward, out pontoDeColisao4, deploymentHeight, points) && ismovingW == false && ismovingA == false && ismovingD == false && ismovingS == false)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                ismovingS = true;

            }
        }

        //XXXXXXXXXXXXXXXXXXXX TERMINOINTER XXXXXXXXXXXXXXXXXXXXXX
        if (terminointer == true && ismovingA == false && ismovingD == false && ismovingS == false && ismovingW == false)
        {
            if (Input.GetKeyUp(KeyCode.W) && Physics.Raycast(transform.position, Vector3.forward, out pontoDeColisao1, deploymentHeight, center) && ismovingA == false && ismovingS == false && ismovingD == false && ismovingW == false)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                ismovingW = true;
              

            }

            if (Input.GetKeyUp(KeyCode.D) && Physics.Raycast(transform.position, Vector3.right, out pontoDeColisao3, deploymentHeight, center) && ismovingA == false && ismovingS == false && ismovingW == false && ismovingD == false)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                ismovingD = true;

            }
            if (Input.GetKeyUp(KeyCode.A) && Physics.Raycast(transform.position, -Vector3.right, out pontoDeColisao2, deploymentHeight, center) && ismovingW == false && ismovingS == false && ismovingD == false && ismovingA == false)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                ismovingA = true;
               

            }
            if (Input.GetKeyUp(KeyCode.S) && Physics.Raycast(transform.position, -Vector3.forward, out pontoDeColisao4, deploymentHeight, center) && ismovingA == false && ismovingW == false && ismovingD == false && ismovingS == false)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                ismovingS = true;
               


            }
        }





        //XXXXXXXXXXXXXXXXXXXX MOVING XXXXXXXXXXXXXXXXXXXXXX
        if (ismovingW == true)
        {
            if(gameObject.transform.position != pontoDeColisao1.transform.position)
            {

                transform.position = Vector3.Lerp(gameObject.transform.position, pontoDeColisao1.transform.position, 0.1f * 2.5f);
                var = false;
            }
            else
            {
                var = true;
                ismovingW = false;
                ismovingA = false;
                ismovingS = false;
                ismovingD = false;
            }
            

        }

        if (ismovingS == true)
        {
           if(gameObject.transform.position != pontoDeColisao4.transform.position)
            {
                transform.position = Vector3.Lerp(gameObject.transform.position, pontoDeColisao4.transform.position, 0.1f * 2.5f);
                var = false;
            }
           else
            {
                var = true;
                ismovingW = false;
                ismovingA = false;
                ismovingS = false;
                ismovingD = false;
            }

            

        }

        if (ismovingA == true)
        {
            if(gameObject.transform.position != pontoDeColisao2.transform.position)
            {
                transform.position = Vector3.Lerp(gameObject.transform.position, pontoDeColisao2.transform.position, 0.1f * 2.5f);
                var = false;
            }
            else
            {
                var = true;
                ismovingW = false;
                ismovingA = false;
                ismovingS = false;
                ismovingD = false;
            }
            
           
        }

        if (ismovingD == true)
        {
            if(gameObject.transform.position != pontoDeColisao3.transform.position)
            {
                transform.position = Vector3.Lerp(gameObject.transform.position, pontoDeColisao3.transform.position, 0.1f * 2.5F);
                var = false;
            }
            else
            {
                var = true;
                ismovingW = false;
                ismovingA = false;
                ismovingS = false;
                ismovingD = false;
            }

            
        }

        if (var == true)
        {
            disabilita = false;
        }
        if (var == false)
        {
            disabilita = true;
        }
        #endregion

        if(Input.GetKeyUp(KeyCode.E) && Time.time > time_between_shoots)
        {
            Atirar();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
     
       
      if(other.gameObject.CompareTag("intercessao") )
      {
            terminointer = true;        
            terminocenter = false; 
      }
      if (other.gameObject.CompareTag("center"))
      {
          terminocenter = true;
          terminointer = false;

      }
    }
   
   void Atirar()
    {
        time_between_shoots = Time.time + fire_rate;
        GameObject cloneBullet = Instantiate(bala, spawnPoint.transform.position, Quaternion.identity);
        

    }

    


}
