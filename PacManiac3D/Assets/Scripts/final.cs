using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject shieldSphere;
    public ParticleSystem speedpart;
    public GameObject textgo;
    public Text textui;
    private bool morreu;
    private bool novenoventaenove;



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
        velocity = 30f;


    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && Time.time > time_between_shoots)
        {
            Atirar();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
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

                transform.position = Vector3.Lerp(gameObject.transform.position, pontoDeColisao1.transform.position, 0.5f * velocity * Time.deltaTime);
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
                transform.position = Vector3.Lerp(gameObject.transform.position, pontoDeColisao4.transform.position, 0.5f * velocity * Time.deltaTime);
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
                transform.position = Vector3.Lerp(gameObject.transform.position, pontoDeColisao2.transform.position, 0.5f *velocity * Time.deltaTime);
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
                transform.position = Vector3.Lerp(gameObject.transform.position, pontoDeColisao3.transform.position, 0.5f * velocity * Time.deltaTime);
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

      

        if(flagcaptured == true)
        {
            flag.transform.position = gameObject.transform.position;
        }




        if (speed == true)
        {
            velocity = 60f;
            textgo.SetActive(true);
            textui.text = "Speed UP";
        }
       

        if (firerate == true)
        {
            fire_rate = 0.5f;
            textgo.SetActive(true);
            textui.text = "Fire-rate Buff";
        }
        else
        {
            fire_rate = 2;


        }
        if (speeddown == true)
        {
            final.f.velocity = 0;
            textgo.SetActive(true);
            textui.text = "Stun Red Player";
        }
        if(morreu == false && speed == false)
        {
            velocity = 30f;


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
            
            if(shield == false)
            {
                Morte();
            }
            else
            {
                shield = false;
                shieldSphere.SetActive(false);
            }
            

        }

        if (other.gameObject.CompareTag("flagV"))
        {
            flagcaptured = true;
        }

        if (other.gameObject.CompareTag("flagA") && flagcaptured == true)
        {
            placar.playerpoints++;
            SceneManager.LoadScene(1);
            part.transform.position = gameObject.transform.position;
            part.Play();
        }

        if (other.gameObject.CompareTag("shieldPU"))
        {
            shield = true;
            shieldSphere.SetActive(true);
            Debug.Log("shield");
            Destroy(other.gameObject);
            part.transform.position = gameObject.transform.position;
            part.Play();

        }

        if (other.gameObject.CompareTag("speedPU"))
        {
            StartCoroutine(speedI());
            Debug.Log("SPEED");
            Destroy(other.gameObject);
            part.transform.position = gameObject.transform.position;
            part.Play();
        }

        if (other.gameObject.CompareTag("fireratePU"))
        {
            StartCoroutine(firerateI());
            Debug.Log("FIRERATE");
            Destroy(other.gameObject);
            part.transform.position = gameObject.transform.position;
            part.Play();
        }

        if(other.gameObject.CompareTag("speedDownPU"))
        {
            StartCoroutine(stun());
            Debug.Log("SPEED DOWN");
            Destroy(other.gameObject);
            part.transform.position = gameObject.transform.position;
            part.Play();
        }
    }

    void Atirar()
    {
       
            time_between_shoots = Time.time + fire_rate;
            GameObject clonebullet = Instantiate(bala, spawnPoint.transform.position, Quaternion.identity);
        
       
    }

   void Morte()
    {
        morreu = true;
        placar.enemypoints++;
        part.transform.position = gameObject.transform.position;
        part.Play();
        velocity = 0;
        StartCoroutine(menuManager.RestartDelay());
        mesh.enabled = false;
        cilindermesh.enabled = false;
        
    }

    IEnumerator speedI()
    {
        speed = true;
        speedpart.Play();
        yield return new WaitForSeconds(3);
        textgo.SetActive(false);
        speedpart.Stop();
        speed = false;
        Debug.Log("speed false");
    }
    IEnumerator firerateI()
    {
        firerate = true;
        yield return new WaitForSeconds(4);
        textgo.SetActive(false);
        firerate = false;
        Debug.Log("firerate false");
    }
    IEnumerator stun()
    {
        speeddown = true;
        yield return new WaitForSeconds(2);
        textgo.SetActive(false);
        speeddown = false;
        Debug.Log("stun false");
    }


}
