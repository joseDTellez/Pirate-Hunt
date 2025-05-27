using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoCanon : MonoBehaviour
{

    public AudioClip sound; //variable para elegir el sonido del cañon
    void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sound); //cada vez que se dispare con el cañón, esto sonará
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
 