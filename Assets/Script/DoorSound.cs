using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioSource audioSource; // Arrastra el AudioSource aquí desde el inspector.
    public HingeJoint doorHingeJoint;   // Arrastra el Hinge Joint de la puerta.
    private float previousAngle;   // Ángulo previo de la puerta.
    private float soundThreshold = 2f; // Diferencia de ángulo mínima para reproducir sonido.

    void Start()
    {
        if (doorHingeJoint == null) doorHingeJoint = GetComponent<HingeJoint>();
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        previousAngle = doorHingeJoint.angle; // Inicializa con el ángulo actual.
    }

    void Update()
    {
        // Detecta el movimiento de la puerta
        float currentAngle = doorHingeJoint.angle;
        float angleDelta = Mathf.Abs(currentAngle - previousAngle);

        // Si la puerta se mueve más que el umbral, reproduce el sonido
        if (angleDelta > soundThreshold && !audioSource.isPlaying)
        {
            audioSource.Play();
            Debug.Log("Abro puerta con llave\n");
        }

        // Actualiza el ángulo previo
        previousAngle = currentAngle;
    }
}
