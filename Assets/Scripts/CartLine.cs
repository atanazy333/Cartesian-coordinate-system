using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartLine : MonoBehaviour
{
    public LineRenderer linerender;
    Material material;
    Color linecolor;
    public string linecolorhex;

    public float m { get; set; }
    public float b { get; set; }

    public void CreateLine(float m, float b,string name)
    {
        BornLine(name);

        linerender.positionCount = 0;

        for (float loopx = -CameraMax.CamMaxX; loopx < CameraMax.CamMaxX; loopx += 0.1f)
        {
            float y = m * loopx + b;
            linerender.SetPosition(linerender.positionCount++, new Vector2(loopx, y));
                

        }

        this.m = m;
        this.b = b;

    }
    public Vector2 GetPoint(int position)
    {
        return linerender.GetPosition(position);
    }
    public void SetPoint(Vector2 point,int index)
    {
         linerender.SetPosition(index,point);
    }

    private LineRenderer SetLinerenderParams(LineRenderer linerenderer)
    {
        linecolorhex = "#9F549B";
        ColorUtility.TryParseHtmlString(linecolorhex, out linecolor);
        material = linerenderer.GetComponent<Renderer>().material;
        material.color = linecolor;
        material.shader = Shader.Find("UI/Default");
        linerender.SetWidth(0.08f, 0.08f);

        return linerenderer;
    }

    private void BornLine(string name)
    {
        GameObject line = new GameObject(name);
        linerender = line.AddComponent<LineRenderer>();
        linerender = SetLinerenderParams(linerender);
        linerender.positionCount = 0;
    }

    protected void Swap(ref Vector2 p0, ref Vector2 p1)
    {
        float tmp = p0.x;
        p0.x = p1.x;
        p1.x = tmp;
        tmp = p0.y;
        p0.y = p1.y;
        p1.y = tmp;

        return;
    }

}
