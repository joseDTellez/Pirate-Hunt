using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePirates : MonoBehaviour
{
    public GameObject pirata;
    public Transform PuntoA;
    public Transform PuntoB;
    private float Speed = 0.8f;
    private Vector3 move;
    void Start()
    {
        move = PuntoB.position;
    }

    // Update is called once per frame
    void Update()
    {
        pirata.transform.position = Vector3.MoveTowards(pirata.transform.position, move, Speed * Time.deltaTime);

        if (pirata.transform.position == PuntoB.position)
        {
            move = PuntoA.position;
        }

        if (pirata.transform.position == PuntoA.position)
        {
            move = PuntoB.position;
        }
       
    }
}
