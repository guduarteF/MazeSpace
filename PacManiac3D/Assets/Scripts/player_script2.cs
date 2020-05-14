using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script2 : MonoBehaviour
{
      public float veloc; 
    private float x, y, z;
    public bool virado_direita;
    public bool virado_esquerda;
    public bool virado_baixo;
    public bool virado_cima;
    public GameObject spawnbala;
    public GameObject bala;
    public static player_script plyrscrpt;
    public float fire_rate;
    private float proximo_tiro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x * veloc * Time.deltaTime, y, z * veloc * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && virado_esquerda == false)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            virado_direita = true;
            virado_esquerda = false;
            virado_baixo = false;
            virado_cima = false;
            x = 0.5f; y = 0; z = 0;



        }
       

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && virado_direita == false)
        {
            virado_direita = false;
            virado_esquerda = true;
            virado_cima = false;
            virado_baixo = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);   
            x = -0.5f; y = 0; z = 0;



        }


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && virado_baixo == false)
        {
            virado_direita = false;
            virado_cima = true;
            virado_esquerda = false;
            virado_baixo = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);          
             x = 0; y = 0; z = 0.5f;


            



        }


        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && virado_cima == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            virado_direita = false;
            virado_esquerda = false;
            virado_cima = false;
            virado_baixo = true;
            x = 0; y = 0; z = -0.5f;          
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > proximo_tiro)
        {
            Atirar();

        }
        //if 
        //{
        //    

        //}
    }
    public void Atirar()
    {
        proximo_tiro = Time.time + fire_rate;
        GameObject clonebala = Instantiate(bala, spawnbala.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("intercessao"))
        {
            x = 0; y = 0; z = 0;
            Debug.Log("parou");
        }
    }
}
