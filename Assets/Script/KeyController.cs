using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Editor;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private float velocity_rot = 120f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, velocity_rot * Time.deltaTime, Space.World);
    }
}
