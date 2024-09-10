using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMax : MonoBehaviour
{
    public static float CamMaxX;

    public static float CamMaxY;

    void Update()
    {
        CamMaxX = Camera.main.orthographicSize * 2;
        CamMaxY = Camera.main.orthographicSize;
    }
}
