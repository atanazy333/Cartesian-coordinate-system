using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xylines : MonoBehaviour
{
    private float x;
    private float y;
    CartVector xax;
    CartVector yax;
    private void Awake()
    {


        xax = new CartVector();
        yax = new CartVector();
        x = 2f * Camera.main.orthographicSize;
        y = x * Camera.main.aspect;
        y = y / 2;


        xax.CreateVec(new Vector2(x, 0), new Vector2(-x, 0),"x");
        yax.CreateVec(new Vector2(0, y), new Vector2(0, -y),"y");

        
        //Vector3[] points = new Vector3[xax.VectorPointsNum];
        //xax.vecrender.GetPositions(points);

    }
    private void Update()
    {
        x = 2f * Camera.main.orthographicSize;
        y = x * Camera.main.aspect;
        y = y / 2;
        xax.ReCreateVec(new Vector2(Camera.main.transform.position.x + x, 0), new Vector2(Camera.main.transform.position.x + -x, 0));
        yax.ReCreateVec(new Vector2(0, Camera.main.transform.position.y + y), new Vector2(0, Camera.main.transform.position.y + -y));

    }
}
