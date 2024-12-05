using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioSource audioSource; // Arrastra el AudioSource aqu� desde el inspector.
    public HingeJoint doorHingeJoint;   // Arrastra el Hinge Joint de la puerta.
    private float previousAngle;   // �ngulo previo de la puerta.
    private float soundThreshold = 2f; // Diferencia de �ngulo m�nima para reproducir sonido.

    void Start()
    {
        if (doorHingeJoint == null) doorHingeJoint = GetComponent<HingeJoint>();
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        previousAngle = doorHingeJoint.angle; // Inicializa con el �ngulo actual.
    }

    void Update()
    {
        // Detecta el movimiento de la puerta
        float currentAngle = doorHingeJoint.angle;
        float angleDelta = Mathf.Abs(currentAngle - previousAngle);

        // Si la puerta se mueve m�s que el umbral, reproduce el sonido
        if (angleDelta > soundThreshold && !audioSource.isPlaying)
        {
            audioSource.Play();
            Debug.Log("Abro puerta con llave\n");
        }

        // Actualiza el �ngulo previo
        previousAngle = currentAngle;
    }
}
