using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTwo : MonoBehaviour
{
    private Transform puerta; // La puerta que queremos abrir
    private Vector3 posicionAbierta = new Vector3(4.1789999f, 7.51463509f, 20.4099998f); // Posición de la puerta abierta
    private Vector3 rotacionAbierta = new Vector3(0f, 8.65643883f, 0f); // Rotación de la puerta abierta
    private Vector3 posicionCerrada = new Vector3(3.97399998f, 7.51463509f, 20.3509998f); // Posición de la puerta cerrada
    private Vector3 rotacionCerrada = new Vector3(0f, 90f, 0f); // Rotación de la puerta cerrada
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

            Debug.Log("Abro la puerta 2\n");
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
