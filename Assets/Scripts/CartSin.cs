using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartSin : MonoBehaviour
{
    public LineRenderer Sinrender;
    Material material;
    Color Sincolor;
    public string Sincolorhex;


    public void CreateSin(Vector2 xlimits,float amplitude,float frequency,string name)
    {
        BornSin(name);

        float xstart = xlimits.x;
        float xend = xlimits.y;

        Sinrender.positionCount = 100;
        for (int i = 0; i < Sinrender.positionCount; i++)
        {
            float progress = (float)i / (Sinrender.positionCount - 1);
            float x = Mathf.Lerp(xstart, xend, progress);
            float y = amplitude * Mathf.Sin(frequency*x);
            Sinrender.SetPosition(i, new Vector2(x, y));

        }

    }
    public Vector2 GetPoint(int position)
    {
        return Sinrender.GetPosition(position);
    }
    public void SetPoint(Vector2 point, int index)
    {
        Sinrender.SetPosition(index, point);
    }
    public void UpdateSin(Vector2 xlimits,float speed, float amplitude, float frequency, string name)
    {
        float xstart = xlimits.x;
        float xend = xlimits.y;

        Sinrender.positionCount = 100;
        for (int i = 0; i < Sinrender.positionCount; i++)
        {
            float progress = (float)i / (Sinrender.positionCount - 1);
            float x = Mathf.Lerp(xstart, xend, progress);
            float y = amplitude * Mathf.Sin((frequency * x) + (Time.timeSinceLevelLoad * speed));
            Sinrender.SetPosition(i, new Vector2(x, y));

        }
    }
    private LineRenderer SetSinrenderParams(LineRenderer Sinrenderer)
    {
        Sincolorhex = "#9F549B";
        ColorUtility.TryParseHtmlString(Sincolorhex, out Sincolor);
        material = Sinrenderer.GetComponent<Renderer>().material;
        material.color = Sincolor;
        material.shader = Shader.Find("UI/Default");
        Sinrender.SetWidth(0.08f, 0.08f);

        return Sinrenderer;
    }

    private void BornSin(string name)
    {
        GameObject Sin = new GameObject(name);
        Sinrender = Sin.AddComponent<LineRenderer>();
        Sinrender = SetSinrenderParams(Sinrender);
        Sinrender.positionCount = 0;
    }


}


