using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaEnemy : MonoBehaviour
{
    public float veloc;
    private RaycastHit ray;
    private LayerMask parede;
    private SphereCollider sph;
    void Start()
    {
        transform.rotation = enemy.e.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Color red = Color.red;
        transform.Translate(Vector3.back * veloc);

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.gameObject.CompareTag("parede"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }

       
    }
}
