using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    public float deploymentHeight;
    public static final f;
    private RaycastHit pontoDeColisao1;
    private RaycastHit pontoDeColisao2;
    private RaycastHit pontoDeColisao3;
    private RaycastHit pontoDeColisao4;

    public LayerMask points;
    public LayerMask parede;

    public bool ismovingW;
    public bool ismovingS;
    public bool ismovingA;
    public bool ismovingD;

    
    public bool terminocenter;
    public bool var;


    public static bool disabilita;

    public GameObject bala;
    public GameObject spawnPoint;

    public float fire_rate = 2f;
    public float time_between_shoots;

    public ParticleSystem part;
    public MeshRenderer mesh;
    public MeshRenderer cilindermesh;

    private bool flagcaptured;
    public GameObject flag;

    private bool shield;
    private bool speed;
    private bool firerate;
    private bool speeddown;
    public float velocity;



    void Start()
    {       
        ismovingA = false;
        ismovingD = false;
        ismovingS = false;
        ismovingW = false;
        terminocenter = true;
        var = true;
        disabilita = true;
        f = this;
        deploymentHeight = 45f;
        velocity = 2.5f;


    }

    // Update is called once per frame
    void Update()
    {
        #region Input e Raycast
        if (terminocenter == true && ismovingA == false && ismovingD == false && ismovingS == false && ismovingW == false)
        {

            if (Input.GetKey(KeyCode.W) && Physics.Raycast(transform.position, Vector3.forward, out pontoDeColisao1, deploymentHeight, points) && ismovingD == false && ismovingA == false && ismovingS == false && ismovingD == false && ismovingW == false)
            {
                if (pontoDeColisao1.transform.name != "parede")
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    ismovingW = true;
                }


            }



            if (Input.GetKey(KeyCode.D) && Physics.Raycast(transform.position, Vector3.right, out pontoDeColisao3, deploymentHeight, points) && ismovingW == false && ismovingA == false && ismovingS == false && ismovingD == false)
            {
                if (pontoDeColisao3.transform.name != "parede")
                {
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                    ismovingD = true;
                }

            }


            if (Input.GetKey(KeyCode.A) && Physics.Raycast(transform.position, -Vector3.right, out pontoDeColisao2, deploymentHeight, points) && ismovingW == false && ismovingS == false && ismovingD == false && ismovingA == false)
            {

                if (pontoDeColisao2.transform.name != "parede")
                {
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    ismovingA = true;
                }
            }


            if (Input.GetKey(KeyCode.S) && Physics.Raycast(transform.position, -Vector3.forward, out pontoDeColisao4, deploymentHeight, points) && ismovingW == false && ismovingA == false && ismovingD == false && ismovingS == false)
            {
                if (pontoDeColisao4.transform.name != "parede")
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    ismovingS = true;
                }
            }


        }

        #endregion

        #region movement


        //XXXXXXXXXXXXXXXXXXXX MOVING XXXXXXXXXXXXXXXXXXXXXX
        if (ismovingW == true)
        {
            if (gameObject.transform.position != pontoDeColisao1.transform.position)
            {

                transform.position = Vector3.Lerp(gameObject.transform.position, pontoDeColisao1.transform.position, 0.1f * velocity);
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
            if (gameObject.transform.position != pontoDeColisao4.transform.position)
            {
                transform.position = Vector3.Lerp(gameObject.transform.position, pontoDeColisao4.transform.position, 0.1f * velocity);
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
            if (gameObject.transform.position != pontoDeColisao2.transform.position)
            {
                transform.position = Vector3.Lerp(gameObject.transform.position, pontoDeColisao2.transform.position, 0.1f *velocity);
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
            if (gameObject.transform.position != pontoDeColisao3.transform.position)
            {
                transform.position = Vector3.Lerp(gameObject.transform.position, pontoDeColisao3.transform.position, 0.1f * velocity);
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

        if (Input.GetKeyUp(KeyCode.E) && Time.time > time_between_shoots)
        {
            Atirar();
        }

        if(flagcaptured == true)
        {
            flag.transform.position = gameObject.transform.position;
        }

       

        
        if (speed == true)
        {
            velocity = 5f;
        }
        if (firerate == true)
        {
            fire_rate = 0.5f;
        }
        if(speeddown == true)
        {
            enemy.e.velocity = 1.3f;
        }



    }


    private void OnTriggerEnter(Collider other)
    {


        
        if (other.gameObject.CompareTag("center"))
        {
            terminocenter = true;
           
        }

        if(other.gameObject.CompareTag("balaE"))
        {
            shield = false;
            if(shield == false)
            {
                Morte();
            }
           
        }

        if (other.gameObject.CompareTag("flagV"))
        {
            flagcaptured = true;
        }

        if (other.gameObject.CompareTag("flagA") && flagcaptured == true)
        {
            placar.playerpoints++;
            SceneManager.LoadScene(0);
        }

        if (other.gameObject.CompareTag("shieldPU"))
        {
            shield = true;
            Debug.Log("shield");

        }

        if (other.gameObject.CompareTag("speedPU"))
        {
            speed = true;
            Debug.Log("SPEED");
        }

        if (other.gameObject.CompareTag("fireratePU"))
        {
            firerate = true;
            Debug.Log("FIRERATE");
        }

        if(other.gameObject.CompareTag("speedDownPU"))
        {
            speeddown = true;
            Debug.Log("SPEED DOWN");
        }
    }

    void Atirar()
    {
       
            time_between_shoots = Time.time + fire_rate;
            GameObject clonebullet = Instantiate(bala, spawnPoint.transform.position, Quaternion.identity);
        
       
    }

   void Morte()
    {
        placar.enemypoints++;
        part.transform.position = gameObject.transform.position;
        part.Play();
        StartCoroutine(menuManager.RestartDelay());
        mesh.enabled = false;
        cilindermesh.enabled = false;
        
    }

    


}
