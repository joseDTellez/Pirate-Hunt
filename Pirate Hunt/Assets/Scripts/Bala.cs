using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bala : MonoBehaviour
{
    public float masa = 3.8f, c = 1.5f, g = 9.81f, angulo;//Valores iniciales
    public float anguloRadianes; public float velInicial;
    public float vx, vy, tInicial, tFinal;
    public Vector2 movimiento = Vector2.zero;
    private bool disparado = false;

    [SerializeField] private float daño;
    void Start()
    {
        tInicial = Time.time;                       //Tiempo inicial
        anguloRadianes = angulo * Mathf.PI / 180f;  //pasar el angulo a radianes
        float velInicial = 0;                     //velocidad inicial
        vx = velInicial * Mathf.Cos(anguloRadianes);//velocidad en eje x
        vy = velInicial * Mathf.Sin(anguloRadianes);//velocidad en eje y
        movimiento = transform.position;            //posicion en Unity
    }
    void Update()                                   //Metodo de runge kutta 
    {
        if (!disparado && Input.GetKeyDown(KeyCode.Return))
        {
            IniciarTiro();
            disparado = true;
        }
        if (disparado)
        {
            tFinal = Time.time - tInicial;
            float k1y = Time.deltaTime * ACY(vy);
            float k2y = Time.deltaTime * ACY(vy + k1y / 2);
            float k3y = Time.deltaTime * ACY(vy - k1y + 2 * k2y); vy += (k1y + 4 * k2y + k3y) / 6;
            float k1x = Time.deltaTime * ACX(vx);
            float k2x = Time.deltaTime * ACX(vx + k1x / 2);
            float k3x = Time.deltaTime * ACX(vx - k1x + 2 * k2x); vx += (k1x + 4 * k2x + k3x) / 6;
            movimiento.x += vx * Time.deltaTime;
            movimiento.y += vy * Time.deltaTime;
        }

        /*if (movimiento.y <= 0)
        {
            movimiento.y = 0;
            enabled = false;
        }*/
        this.transform.position = new Vector2(movimiento.x, movimiento.y);// transformacion de posicion en Unity
    }
    void IniciarTiro()
    {
        float rad = angulo * Mathf.Deg2Rad;
        vx = velInicial * Mathf.Cos(rad);
        vy = velInicial * Mathf.Sin(rad);
        movimiento = transform.position;
        tInicial = Time.time;
    }
    float ACX(float v)     //razon de cambio en x
    {
        return -(c / masa) * v;     //ecuancion diferencial del movimiento con fuerza de arrastre
    }
    float ACY(float v)     //razon de cambio en y
    {
        return -g - (c / masa) * v; //ecuancion diferencial del movimiento con fuerza de arrastre y gravitacional
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo")){
            other.GetComponent<Enemigo>().quitaDaño(daño);
            Destroy(gameObject);
        }

    }
}
