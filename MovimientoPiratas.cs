using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPiratas : MonoBehaviour
{

    public Transform PuntoA;
    public Transform PuntoB;
    private float Speed = 0.7f; 

    public bool MoveToA = false;
    public bool MoveToB = false;

    private Rigidbody2D MyRb;

    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
        MoveToB = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (MoveToB == true)
        {
            MyRb.transform.position = Vector2.MoveTowards(transform.position, PuntoB.position, Speed * Time.deltaTime);

            if (transform.position == PuntoB.position)
            {
                MoveToA = true;
                MoveToB = false;
            }
        }


        if (MoveToA == true)
        {
            MyRb.transform.position = Vector2.MoveTowards(transform.position, PuntoA.position, Speed * Time.deltaTime);

            if (transform.position == PuntoA.position)
            {
                MoveToA = false;
                MoveToB = true;
            }
        }
    }
}
