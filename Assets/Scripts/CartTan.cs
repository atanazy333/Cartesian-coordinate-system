using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartTan : MonoBehaviour
{

    public LineRenderer Tanrender;
    Material material;
    Color Tancolor;
    public string Tancolorhex;


    public void CreateTan(Vector2 xlimits, float amplitude, float frequency, string name)
    {
        BornTan(name);

        float xstart = xlimits.x;
        float xend = xlimits.y;

        Tanrender.positionCount = 100;
        for (int i = 0; i < Tanrender.positionCount; i++)
        {
            float progress = (float)i / (Tanrender.positionCount - 1);
            float x = Mathf.Lerp(xstart, xend, progress);
            float y = amplitude * Mathf.Tan(frequency * x);
            Tanrender.SetPosition(i, new Vector2(x, y));

        }

    }
    public Vector2 GetPoint(int position)
    {
        return Tanrender.GetPosition(position);
    }
    public void SetPoint(Vector2 point, int index)
    {
        Tanrender.SetPosition(index, point);
    }
    public void UpdateTan(Vector2 xlimits, float speed, float amplitude, float frequency, string name)
    {
        float xstart = xlimits.x;
        float xend = xlimits.y;

        Tanrender.positionCount = 100;
        for (int i = 0; i < Tanrender.positionCount; i++)
        {
            float progress = (float)i / (Tanrender.positionCount - 1);
            float x = Mathf.Lerp(xstart, xend, progress);
            float y = amplitude * Mathf.Tan((frequency * x) + (Time.timeSinceLevelLoad * speed));
            Tanrender.SetPosition(i, new Vector2(x, y));

        }
    }
    private LineRenderer SetTanrenderParams(LineRenderer Tanrenderer)
    {
        Tancolorhex = "#9F549B";
        ColorUtility.TryParseHtmlString(Tancolorhex, out Tancolor);
        material = Tanrenderer.GetComponent<Renderer>().material;
        material.color = Tancolor;
        material.shader = Shader.Find("UI/Default");
        Tanrender.SetWidth(0.08f, 0.08f);

        return Tanrenderer;
    }

    private void BornTan(string name)
    {
        GameObject Tan = new GameObject(name);
        Tanrender = Tan.AddComponent<LineRenderer>();
        Tanrender = SetTanrenderParams(Tanrender);
        Tanrender.positionCount = 0;
    }


}


