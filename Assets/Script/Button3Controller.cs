using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3Controller : MonoBehaviour
{
    public DoorController2 doorController2;
    // La puerta que queremos abrir
    // Start is called before the first frame update
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
            doorController2.OpenDoor();
        }
    }

}
