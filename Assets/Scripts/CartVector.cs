using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CartVector : MonoBehaviour
{
    public LineRenderer vecrender;
    Material material;
    Color vecolor;
    public string veccolorhex;

    public long VectorPointsNum {get;set;}
    public float m { get; set; }
    public float b { get; set; }

    public void CreateVec(Vector2 p0, Vector2 p1,string name)
    {
        BornVec(name,p0,p1);
        float m;
        float b;


        if (p1.x == 0 || p0.x == 0)
        {
            if (p0.y > p1.y)
            {
                Swap(ref p0, ref p1);
            }

            m = (p1.x - p0.x) / (p1.y - p0.y);
            b = p0.x - m * p0.y;

            for (float y = p0.y; y < p1.y; y += 0.1f)
            {
                float x = m * y + b;
                vecrender.SetPosition(vecrender.positionCount++, new Vector2(x, y));
                this.VectorPointsNum += 1;
            }
            
            this.m = m;
            this.b = b;
            return;
        }

        if (p0.x > p1.x)
        {
            Swap(ref p0, ref p1);
        }
        m = (p1.y - p0.y) / (p1.x - p0.x);
         b = m * p0.x - p0.y;

        for (float x = p0.x; x < p1.x; x += 0.1f)
        {
            float y = m * x + b;
            vecrender.SetPosition(vecrender.positionCount++, new Vector2(x, y));
            this.VectorPointsNum += 1;
        }
        this.m = m;
        this.b = b;
    }
    public void ReCreateVec(Vector2 p0, Vector2 p1)
    {
        float m;
        float b;
        vecrender.positionCount = 0;

        if (p1.x == 0 || p0.x == 0)
        {
            if (p0.y > p1.y)
            {
                Swap(ref p0, ref p1);
            }

            m = (p1.x - p0.x) / (p1.y - p0.y);
            b = p0.x - m * p0.y;

            for (float y = p0.y; y < p1.y; y += 0.1f)
            {
                float x = m * y + b;
                vecrender.SetPosition(vecrender.positionCount++, new Vector2(x, y));
                this.VectorPointsNum += 1;
            }
            this.m = m;
            this.b = b;
            return;
        }

        if (p0.x > p1.x)
        {
            Swap(ref p0, ref p1);
        }
        m = (p1.y - p0.y) / (p1.x - p0.x);
        b = m * p0.x - p0.y;

        for (float x = p0.x; x < p1.x; x += 0.1f)
        {
            float y = m * x + b;
            vecrender.SetPosition(vecrender.positionCount++, new Vector2(x, y));
            this.VectorPointsNum += 1;
        }
        vecrender.colorGradient.mode = GradientMode.Fixed;
        this.m = m;
        this.b = b;
    }

    public Vector2 GetPoint(int position)
    {
        return vecrender.GetPosition(position);
    }
    public void SetPoint(Vector2 point, int index)
    {
        vecrender.SetPosition(index, point);
    }

    private LineRenderer SetVecrenderParams(LineRenderer linerenderer, string name,Vector2 p0, Vector2 p1)
    {
        veccolorhex = "#9F549B";
        ColorUtility.TryParseHtmlString(veccolorhex, out vecolor);
        material = linerenderer.GetComponent<Renderer>().material;
        material.color = vecolor;
        material.shader = Shader.Find("UI/Default");
        vecrender.SetWidth(0.08f, 0.08f);
        if (name != "x" && name != "y"){
            if (p1.y >= 0 && p0.x <= p1.x && p0.y <= p1.y)
            {
                //Gradient Color  represent vector direction
                Gradient g = new Gradient();
                GradientColorKey[] gck = new GradientColorKey[2];
                GradientAlphaKey[] gak = new GradientAlphaKey[2];
                gak[0].alpha = 255F;
                gak[1].alpha = 255F;
                gck[0].color = vecolor;
                gck[1].time = 0.93F;
                gck[0].time = 0.75F;
                gck[1].color = Color.red;

                g.SetKeys(gck, gak);

                vecrender.colorGradient = g;
            }
            else
            {
                //Gradient Color  represent vector direction
                Gradient g = new Gradient();
                GradientColorKey[] gck = new GradientColorKey[2];
                GradientAlphaKey[] gak = new GradientAlphaKey[2];
                gak[0].alpha = 255F;
                gak[1].alpha = 255F;
                gck[0].color = Color.red;
                gck[1].time = 0.20F;
                gck[0].time = 0.15F;
                gck[1].color = vecolor;

                g.SetKeys(gck, gak);

                vecrender.colorGradient = g;
            }
        }

        return linerenderer;
    }

    private void BornVec(string name, Vector2 p0,Vector2 p1)
    {
        GameObject line = new GameObject(name);
        vecrender = line.AddComponent<LineRenderer>();
        vecrender = SetVecrenderParams(vecrender,name,p0,p1);
        vecrender.positionCount = 0;
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
