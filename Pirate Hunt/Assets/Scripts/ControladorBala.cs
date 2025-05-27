using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class controladorBala : MonoBehaviour
{
    public Slider sliderAngulo;
    public Slider sliderVelocidad;
    public DisparoManager scriptTiro; // Referencia al script del tiro
    public TextMeshProUGUI textoAngulo, textoVelocidad;

    void Update()
    {
        scriptTiro.angulo = sliderAngulo.value;
        scriptTiro.velInicial = sliderVelocidad.value;

        textoAngulo.text = "Ángulo: " + sliderAngulo.value.ToString("F0") + "°";
        textoVelocidad.text = "Vel: " + sliderVelocidad.value.ToString("F1") + " m/s";
    }

}
