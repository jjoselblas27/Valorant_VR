using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOne : MonoBehaviour
{
    private Transform puerta;
    private Vector3 posicionAbierta = new Vector3(-18.1622295f, 7.51463509f, 18.9008617f); // Posición de la puerta abierta
    private Vector3 rotacionAbierta = new Vector3(0f, 202.806702f, 0f); // Rotación de la puerta abierta
    private Vector3 posicionCerrada = new Vector3(-17.9459991f, 7.51463509f, 18.8260002f); // Posición de la puerta cerrada
    private Vector3 rotacionCerrada = new Vector3(0f, 270f, 0f); // Rotación de la puerta cerrada
    public AudioSource audioSource;

    private float temporizador = 0f;
    private bool botonPresionado = false;

    void Start()
    {
        puerta = GetComponent<Transform>();
    }

    void Update()
    {
        if (botonPresionado)
        {
            // Incrementa el temporizador
            temporizador += Time.deltaTime;

            // Si pasan 5 segundos, regresa la puerta a su estado original
            if (temporizador >= 5f)
            {
                CerrarPuerta();
            }
        }
    }

    public void PresionarBoton()
    {
        // Reinicia el temporizador y abre la puerta
        botonPresionado = true;
        temporizador = 0f;
        AbrirPuerta();
    }

    private void AbrirPuerta()
    {
        if (puerta != null)
        {
            puerta.position = posicionAbierta;
            puerta.eulerAngles = rotacionAbierta;
            Debug.Log("Puerta abierta.");

            audioSource.Play();

            Debug.Log("Abro la puerta 1\n");
        }
    }

    private void CerrarPuerta()
    {
        if (puerta != null)
        {
            puerta.position = posicionCerrada;
            puerta.eulerAngles = rotacionCerrada;
            Debug.Log("Puerta cerrada.");
        }

        // Restablecer estado del botón
        botonPresionado = false;
    }
}
