using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeKiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube" || other.tag == "Arrow" || other.tag == "RedCube") // when these cubes touches the plane the gameObjects gets destroyed
        {
            // Debug.Log("Inside OnTriggerEnter");
            // Destroy(other.gameObject); // Destroy the cube
            Destroy(other.transform.parent.gameObject);
        }
    }
}
