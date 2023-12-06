using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clef1position : MonoBehaviour
{
    public GameObject object1;
    public int offset;
    public bool isWorld1;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        if (object1 != null && !isWorld1)
        {
            Vector3 newPosition = object1.transform.position;
            newPosition.y = newPosition.y + offset;
            transform.position = newPosition;
        }
        isWorld1 = !isWorld1;
    }
}
