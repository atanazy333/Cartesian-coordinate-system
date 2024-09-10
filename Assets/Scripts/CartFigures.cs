using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CartFigures : MonoBehaviour
{
    public LineRenderer Figuresrender;
    Material material;
    Color Figurescolor;
    public string Figurescolorhex;


    public void CreateFigures(Vector2 hk, int step,float size, string name)
    {
        BornFigures(name);

        Figuresrender.positionCount = step+1;
        for (int i = 0; i < Figuresrender.positionCount; i++)
        {
            float circumferenceProggress = (float)i / (Figuresrender.positionCount - 1);
            float currentRadian = circumferenceProggress * 2 * Mathf.PI;
            float x = Mathf.Cos(currentRadian);
            float y = Mathf.Sin(currentRadian);
            x = (x - hk.x);
            x = x * size;
            y = (y - hk.y);
            y = y * size;
            Figuresrender.SetPosition(i, new Vector2(x, y));

        }

    }
    public Vector2 GetPoint(int position)
    {
        return Figuresrender.GetPosition(position);
    }
    public void SetPoint(Vector2 point, int index)
    {
        Figuresrender.SetPosition(index, point);
    }

    private LineRenderer SetFiguresrenderParams(LineRenderer Figuresrenderer)
    {
        Figurescolorhex = "#9F549B";
        ColorUtility.TryParseHtmlString(Figurescolorhex, out Figurescolor);
        material = Figuresrenderer.GetComponent<Renderer>().material;
        material.color = Figurescolor;
        material.shader = Shader.Find("UI/Default");
        Figuresrender.SetWidth(0.08f, 0.08f);

        return Figuresrenderer;
    }

    private void BornFigures(string name)
    {
        GameObject Figures = new GameObject(name);
        Figuresrender = Figures.AddComponent<LineRenderer>();
        Figuresrender = SetFiguresrenderParams(Figuresrender);
        Figuresrender.positionCount = 0;
    }


}

