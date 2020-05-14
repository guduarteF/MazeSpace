using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    public float veloc; 
    private float x, y, z;
    public GameObject intercessao;
    public bool virado_direita;
    public bool virado_esquerda;
    public bool virado_baixo;
    public bool virado_cima;
    public GameObject spawnbala;
    public GameObject bala;
    public static player_script plyrscrpt;
    public float fire_rate;
    private float proximo_tiro;
    private BoxCollider boxcol;
    private LayerMask parede;
    public float deploymentHeight;
    private RaycastHit pontoDeColisao;
    private RaycastHit pontoDeColisao2;
    private RaycastHit pontoDeColisao3;
    private RaycastHit pontoDeColisao4;
    public LayerMask Parede;
    public int count;

    void Start()
    {
        plyrscrpt = this;
        boxcol = GetComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        #region movement
        transform.Translate(x* veloc * Time.deltaTime, y, z * veloc * Time.deltaTime,Space.World);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            virado_direita = true;
            virado_esquerda = false;
            virado_baixo = false;
            virado_cima = false;
            if (virado_esquerda == false && Physics.Raycast(transform.position, transform.right, out pontoDeColisao2, deploymentHeight, Parede) == false)
            {
                x = 0.5f; y = 0; z = 0;
                
            }
   

        }
        else
        {
            count = 0;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            virado_direita = false;
            virado_esquerda = true;
            virado_cima = false;
            virado_baixo = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
            if (virado_direita == false && Physics.Raycast(transform.position, transform.right, out pontoDeColisao3, deploymentHeight, Parede) == false)
            {
                x = -0.5f; y = 0; z = 0;                
            }         
        }
       

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            virado_direita = false;
            virado_cima = true;
            virado_esquerda = false;
            virado_baixo = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            count = 1;
            if (virado_baixo == false && Physics.Raycast(transform.position, -transform.forward, out pontoDeColisao, deploymentHeight, Parede) == false)
            {
                x = 0; y = 0; z = 0.5f;
                

            }
          
           
            
        }
       

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            virado_direita = false;
            virado_esquerda = false;
            virado_cima = false;
            virado_baixo = true;
          

            if (virado_cima == false && Physics.Raycast(transform.position, transform.forward, out pontoDeColisao4, deploymentHeight, Parede) == false)
            {
                x = 0; y = 0; z = -0.5f;
               

            }
        }
       

        if(Input.GetKey(KeyCode.Space) && Time.time > proximo_tiro)
        {
            Atirar();
            
        }
        if (Physics.Raycast(transform.position, -transform.forward, out pontoDeColisao4, deploymentHeight, Parede))
        {
            x = 0; y = 0; z = 0;
           
        }
        

        if (Physics.Raycast(transform.position, -transform.forward, out pontoDeColisao4, deploymentHeight,Parede))
        {
            Debug.DrawLine(transform.position, pontoDeColisao4.point);
            Debug.Log("FRENTE");
        }
        if (Physics.Raycast(transform.position, transform.forward, out pontoDeColisao, deploymentHeight, Parede))
        {
            Debug.DrawLine(transform.position, pontoDeColisao.point);
            Debug.Log("BACK");
        }
        if (Physics.Raycast(transform.position, transform.right, out pontoDeColisao3, deploymentHeight, Parede))
        {
            Debug.DrawLine(transform.position, pontoDeColisao3.point);
            Debug.Log("LEFT");
        }
        if (Physics.Raycast(transform.position, -transform.right, out pontoDeColisao2, deploymentHeight, Parede))
        {
            Debug.DrawLine(transform.position, pontoDeColisao2.point);
            Debug.Log("RIGHT");


        }
        #endregion

       


    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("intercessao"))
    //    {
    //        colisao_inter = true;
    //    }

    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.gameObject.CompareTag("intercessao"))
    //    {
    //        colisao_inter = false;
    //    }

    //}

    public void Atirar()
    {
        proximo_tiro = Time.time + fire_rate;
        GameObject clonebala = Instantiate(bala, spawnbala.transform.position, Quaternion.identity);
    }

   
        
       
           
       
        
     
        
        
        
      
    
    

}
