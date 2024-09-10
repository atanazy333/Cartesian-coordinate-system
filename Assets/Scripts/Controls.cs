using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if (Camera.main.orthographicSize < 100)
            {
                Camera.main.orthographicSize += 0.3f;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (Camera.main.orthographicSize > 0)
            {
                Camera.main.orthographicSize -= 0.3f;
            }
        }
    }
}
