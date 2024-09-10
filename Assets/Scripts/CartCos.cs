using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CartCos : MonoBehaviour
{
    public LineRenderer Cosrender;
    Material material;
    Color Coscolor;
    public string Coscolorhex;


    public void CreateCos(Vector2 xlimits, float amplitude, float frequency, string name)
    {
        BornCos(name);

        float xstart = xlimits.x;
        float xend = xlimits.y;

        Cosrender.positionCount = 100;
        for (int i = 0; i < Cosrender.positionCount; i++)
        {
            float progress = (float)i / (Cosrender.positionCount - 1);
            float x = Mathf.Lerp(xstart, xend, progress);
            float y = amplitude * Mathf.Cos(frequency * x);
            Cosrender.SetPosition(i, new Vector2(x, y));

        }

    }
    public Vector2 GetPoint(int position)
    {
        return Cosrender.GetPosition(position);
    }
    public void SetPoint(Vector2 point, int index)
    {
        Cosrender.SetPosition(index, point);
    }
    public void UpdateCos(Vector2 xlimits, float speed, float amplitude, float frequency, string name)
    {
        float xstart = xlimits.x;
        float xend = xlimits.y;

        Cosrender.positionCount = 100;
        for (int i = 0; i < Cosrender.positionCount; i++)
        {
            float progress = (float)i / (Cosrender.positionCount - 1);
            float x = Mathf.Lerp(xstart, xend, progress);
            float y = amplitude * Mathf.Cos((frequency * x) + (Time.timeSinceLevelLoad * speed));
            Cosrender.SetPosition(i, new Vector2(x, y));

        }
    }
    private LineRenderer SetCosrenderParams(LineRenderer Cosrenderer)
    {
        Coscolorhex = "#9F549B";
        ColorUtility.TryParseHtmlString(Coscolorhex, out Coscolor);
        material = Cosrenderer.GetComponent<Renderer>().material;
        material.color = Coscolor;
        material.shader = Shader.Find("UI/Default");
        Cosrender.SetWidth(0.08f, 0.08f);

        return Cosrenderer;
    }

    private void BornCos(string name)
    {
        GameObject Cos = new GameObject(name);
        Cosrender = Cos.AddComponent<LineRenderer>();
        Cosrender = SetCosrenderParams(Cosrender);
        Cosrender.positionCount = 0;
    }


}


