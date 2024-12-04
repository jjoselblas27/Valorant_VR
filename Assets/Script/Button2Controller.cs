using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2Controller : MonoBehaviour
{
    public DoorTwo doorTwo; // La puerta que queremos abrir
    public DoorOne doorOne; // La puerta que queremos abrir
    // Start is called before the first frame update
    public AudioSource audioSource;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorTwo.PresionarBoton();
            doorOne.PresionarBoton();
            audioSource.Play();
        }
    }
}
