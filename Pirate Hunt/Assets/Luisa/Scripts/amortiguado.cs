using UnityEngine;

public class amortiguado : MonoBehaviour
{
    // Variables globales
    public double masa, k, vel_inicial, posicion_inicial, fuerza, posicion_actual_x, posicion_actual_y;
    public double k1_v, k1_x,k2_v, k2_x,k3_v,k3_x,k4_v,k4_x,velocidad,dt;
    public double elongacion_inicial;
    double punto_equilibrio;
    double gravedad = 9.81;
    Vector2 posicion_y = Vector2.zero;
    void Start()
    {
        punto_equilibrio = (fuerza - masa * gravedad) / k;
        //Se lee la posición de la partícula
        posicion_actual_x = this.transform.position.x;

        //Posicion inicial es el punto de equilibrio + elongación inicial
        posicion_actual_y = this.transform.position.y;
        //posicion_inicial = (fuerza-masa * gravedad)/ k; //Punto de equilibrio+elongación inicial
        velocidad = vel_inicial;

        // Mostrar en consola el rango de oscilación
        double max = punto_equilibrio + System.Math.Abs(elongacion_inicial);
        double min = punto_equilibrio - System.Math.Abs(elongacion_inicial);
        Debug.Log("Oscilará entre: " + min + " y " + max);
    }

    // Update is called once per frame
    void Update()
    {
        //EDO: a= (f - bv - kx) / m
        dt = Time.deltaTime; //Paso de tiempo de Unity

        //Runge Kutta . 4to orden - solución EDO
        k1_v = evaluar_funcion(posicion_actual_y);
        k1_x = velocidad;

        k2_v = evaluar_funcion(posicion_actual_y+k1_x*dt/2);
        k2_x = velocidad + k1_v * dt / 2;

        k3_v=evaluar_funcion(posicion_actual_y+k2_x*dt/2);
        k3_x = velocidad + k2_v * dt / 2;

        k4_v = evaluar_funcion(posicion_actual_y + k3_x * dt);
        k4_x = velocidad + k3_v * dt;

        //calculo de velocidad y posición en x
        velocidad += (dt / 6) * (k1_v + 2 * k2_v + 2 * k3_v + k4_v);
        posicion_actual_y += (dt / 6) * (k1_x + 2 * k2_x + 2 * k3_x + k4_x);

        //Actualizar la posición de la partícula
        posicion_y.y = (float)posicion_actual_y;
        this.transform.position = posicion_y;
    }
  
    //Función para evaluar la ecuación diferencial a resolver
    double evaluar_funcion(double pos)
    {
        //return (fuerza - b * vel - k * pos) / masa;
        //double gravedad=9.81;
        return (fuerza-masa*gravedad-k*pos)/masa;//Se tiene en cuenta también el peso
    }
}
