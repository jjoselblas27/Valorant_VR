using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Editor;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private float velocity_rot = 150f;
    public HingeJoint hingeJoint;
    public DoorTwo doorTwo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, velocity_rot * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hingeJoint.useMotor = true;
            doorTwo.PresionarBoton();
        }
        
    }
}
