using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartCircle : MonoBehaviour
{
    public LineRenderer Circlerender;
    Material material;
    Color Circlecolor;
    public string Circlecolorhex;


    public void CreateCircle(Vector2 hk,float r,string name)
    {
        BornCircle(name);

        Circlerender.positionCount = 100;
        for (int i = 0; i < Circlerender.positionCount; i++)
        {
            float circumferenceProggress = (float)i / (Circlerender.positionCount - 1);
            float currentRadian = circumferenceProggress * 2 * Mathf.PI;
            float x = Mathf.Cos(currentRadian);
            float y = Mathf.Sin(currentRadian);
            x = (x - hk.x);
            x = x * r;
            y = (y - hk.y);
            y = y * r;
            Circlerender.SetPosition(i, new Vector2(x, y));

        }

    }
    public Vector2 GetPoint(int position)
    {
        return Circlerender.GetPosition(position);
    }
    public void SetPoint(Vector2 point, int index)
    {
        Circlerender.SetPosition(index, point);
    }

    private LineRenderer SetCirclerenderParams(LineRenderer Circlerenderer)
    {
        Circlecolorhex = "#9F549B";
        ColorUtility.TryParseHtmlString(Circlecolorhex, out Circlecolor);
        material = Circlerenderer.GetComponent<Renderer>().material;
        material.color = Circlecolor;
        material.shader = Shader.Find("UI/Default");
        Circlerender.SetWidth(0.08f, 0.08f);

        return Circlerenderer;
    }

    private void BornCircle(string name)
    {
        GameObject Circle = new GameObject(name);
        Circlerender = Circle.AddComponent<LineRenderer>();
        Circlerender = SetCirclerenderParams(Circlerender);
        Circlerender.positionCount = 0;
    }


}

