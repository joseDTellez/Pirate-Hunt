using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class DisparoManager : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo; // lugar desde donde se dispara
    public float velInicial;
    public float angulo;
    //public Slider sliderAngulo;
    //public Slider sliderVelocidad;
    private int disparosRealizados = 0;
    private int disparosMaximos = 20;
    public TextMeshProUGUI textoBombas;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && disparosRealizados < disparosMaximos)
        {
            //velInicial = sliderVelocidad.value;
            //angulo = sliderAngulo.value;
            Disparar();
        }
    }
    void Disparar()
    {
        GameObject nuevaBala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
        Bala scriptBala = nuevaBala.GetComponent<Bala>();
        scriptBala.velInicial = velInicial;
        scriptBala.angulo = angulo;
        disparosRealizados++;
        textoBombas.text = "Balas"+(disparosMaximos-disparosRealizados).ToString();

    }
}
