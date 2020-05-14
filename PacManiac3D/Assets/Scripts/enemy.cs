using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float deploymentHeight;
    public static enemy e;
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

    



    void Start()
    {
        ismovingA = false;
        ismovingD = false;
        ismovingS = false;
        ismovingW = false;
        terminocenter = true;
        var = true;
        disabilita = true;
        e = this;
        deploymentHeight = 45f;

    }

    // Update is called once per frame
    void Update()
    {
        #region input and raycast

        if (terminocenter == true && ismovingA == false && ismovingD == false && ismovingS == false && ismovingW == false)
            {

                if (Input.GetKey(KeyCode.UpArrow) && Physics.Raycast(transform.position, Vector3.forward, out pontoDeColisao1, deploymentHeight, points) && ismovingD == false && ismovingA == false && ismovingS == false && ismovingD == false && ismovingW == false)
                {
                    if (pontoDeColisao1.transform.name != "parede")
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        ismovingW = true;
                    }


                }



                if (Input.GetKey(KeyCode.RightArrow) && Physics.Raycast(transform.position, Vector3.right, out pontoDeColisao3, deploymentHeight, points) && ismovingW == false && ismovingA == false && ismovingS == false && ismovingD == false)
                {
                    if (pontoDeColisao3.transform.name != "parede")
                    {
                        transform.rotation = Quaternion.Euler(0, -90, 0);
                        ismovingD = true;
                    }

                }


                if (Input.GetKey(KeyCode.LeftArrow) && Physics.Raycast(transform.position, -Vector3.right, out pontoDeColisao2, deploymentHeight, points) && ismovingW == false && ismovingS == false && ismovingD == false && ismovingA == false)
                {

                    if (pontoDeColisao2.transform.name != "parede")
                    {
                        transform.rotation = Quaternion.Euler(0, 90, 0);
                        ismovingA = true;
                    }
                }


                if (Input.GetKey(KeyCode.DownArrow) && Physics.Raycast(transform.position, -Vector3.forward, out pontoDeColisao4, deploymentHeight, points) && ismovingW == false && ismovingA == false && ismovingD == false && ismovingS == false)
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
            if (gameObject.transform.position != pontoDeColisao4.transform.position)
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
            if (gameObject.transform.position != pontoDeColisao2.transform.position)
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
            if (gameObject.transform.position != pontoDeColisao3.transform.position)
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
        

            if (Input.GetKeyUp(KeyCode.RightControl) && Time.time > time_between_shoots)
            {
                Atirar();
            }
        
    }


    private void OnTriggerEnter(Collider other)
    {



        if (other.gameObject.CompareTag("center"))
        {
            terminocenter = true;

        }
        if (other.gameObject.CompareTag("bala"))
        {
            Destroy(gameObject);
        }
    }

    void Atirar()
    {

        time_between_shoots = Time.time + fire_rate;
        GameObject clonebullet = Instantiate(bala, spawnPoint.transform.position, Quaternion.identity);


    }
}
