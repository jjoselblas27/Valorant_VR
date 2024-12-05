using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController2 : MonoBehaviour
{
    public Transform pivot; // El punto de pivote de la puerta (colocar un GameObject en la esquina)
    public float openAngle = 90f; // �ngulo de apertura
    public float closeAngle = 0f; // �ngulo de cierre
    public float speed = 2f; // Velocidad de apertura y cierre
    public float autoCloseTime = 5f; // Tiempo para cerrarse autom�ticamente

    private float currentAngle = 0f; // �ngulo actual de la puerta
    private bool isOpening = false; // Indica si est� abriendo
    private bool isClosing = false; // Indica si est� cerrando
    private float timer = 0f; // Temporizador para el cierre autom�tico
    public AudioSource audioSource;
    void Update()
    {
        if (isOpening)
        {
            // Abrir gradualmente
            currentAngle = Mathf.Lerp(currentAngle, openAngle, Time.deltaTime * speed);
            if (Mathf.Abs(currentAngle - openAngle) < 0.1f)
            {
                currentAngle = openAngle;
                isOpening = false;
                timer = 0f; // Reinicia el temporizador
            }
        }
        else if (isClosing)
        {
            // Cerrar gradualmente
            currentAngle = Mathf.Lerp(currentAngle, closeAngle, Time.deltaTime * speed);
            if (Mathf.Abs(currentAngle - closeAngle) < 0.1f)
            {
                currentAngle = closeAngle;
                isClosing = false;
            }
        }
        else
        {
            // Contar el tiempo para el cierre autom�tico
            timer += Time.deltaTime;
            if (timer > autoCloseTime)
            {
                CloseDoor();
            }
        }

        // Aplicar la rotaci�n al transform de la puerta
        pivot.localRotation = Quaternion.Euler(0, currentAngle, 0);
    }

    public void OpenDoor()
    {
        isOpening = true;
        isClosing = false;
        audioSource.Play();
    }

    public void CloseDoor()
    {
        isOpening = false;
        isClosing = true;
    }
}
