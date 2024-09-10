using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CartAngle : MonoBehaviour
{
    public LineRenderer Anglerender;
    Material material;
    Color Anglecolor;
    //TextMeshPro textmeshpro;
    public string Anglecolorhex;


    public void CreateAngle(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 pos, string name)
    {
        BornAngle(name);
        Anglerender.positionCount = 3;

        Anglerender.SetPosition(0, new Vector2(p0.x, p0.y));
        Anglerender.SetPosition(1, new Vector2(p1.x, p1.y));
        Anglerender.SetPosition(2, new Vector2(p2.x, p2.y));
        float cosangle = Vector2.Dot(p0, p2) / (p0.magnitude * p2.magnitude);

        Debug.Log(Mathf.Acos(cosangle));

        //textmeshpro = gameObject.AddComponent<TextMeshPro>();

        //textmeshpro.text = angle.ToString();




    }
    public Vector2 GetPoint(int position)
    {
        return Anglerender.GetPosition(position);
    }
    public void SetPoint(Vector2 point, int index)
    {
        Anglerender.SetPosition(index, point);
    }

    private LineRenderer SetAnglerenderParams(LineRenderer Anglerenderer)
    {
        Anglecolorhex = "#9F549B";
        ColorUtility.TryParseHtmlString(Anglecolorhex, out Anglecolor);
        material = Anglerenderer.GetComponent<Renderer>().material;
        material.color = Anglecolor;
        material.shader = Shader.Find("UI/Default");
        Anglerender.SetWidth(0.08f, 0.08f);

        return Anglerenderer;
    }

    private void BornAngle(string name)
    {
        GameObject Angle = new GameObject(name);
        Anglerender = Angle.AddComponent<LineRenderer>();
        Anglerender = SetAnglerenderParams(Anglerender);
        Anglerender.positionCount = 0;
    }


}


