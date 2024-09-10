using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartTriangle : MonoBehaviour
{
    public LineRenderer Trianglerender;
    Material material;
    Color Trianglecolor;
    public string Trianglecolorhex;

    public void CreateTriangle(Vector2 p0, Vector2 p1, Vector2 p2, string name)
    {
        BornTriangle(name);
        Trianglerender.positionCount = 4;
        Trianglerender.SetPosition(0, p0);
        Trianglerender.SetPosition(1, p1);
        Trianglerender.SetPosition(2, p2);
        Trianglerender.SetPosition(3, p0);
        /*
                CartVector vector0 = new CartVector();
                vector0.CreateVec(new Vector2(p0.x, p0.y), new Vector2(p1.x, p1.y), name + "partLine0");


                CartVector vector1 = new CartVector();
                vector1.CreateVec(new Vector2(p0.x, p0.y), new Vector2(p2.x, p2.y), name + "partLine1");

                CartVector vector2 = new CartVector();
                vector2.CreateVec(new Vector2(p2.x, p2.y), new Vector2(p1.x, p1.y), name + "partLine2");
        */

    }
    public Vector2 GetPoint(int position)
    {
        return Trianglerender.GetPosition(position);
    }
    public void SetPoint(Vector2 point, int index)
    {
        Trianglerender.SetPosition(index, point);
    }

    private LineRenderer SetCartTriangleParams(LineRenderer CartTriangleer)
    {
        Trianglecolorhex = "#9F549B";
        ColorUtility.TryParseHtmlString(Trianglecolorhex, out Trianglecolor);
        material = CartTriangleer.GetComponent<Renderer>().material;
        material.color = Trianglecolor;
        material.shader = Shader.Find("UI/Default");
        Trianglerender.SetWidth(0.08f, 0.08f);

        return CartTriangleer;
    }

    private void BornTriangle(string name)
    {
        GameObject Circle = new GameObject(name);
        Trianglerender = Circle.AddComponent<LineRenderer>();
        Trianglerender = SetCartTriangleParams(Trianglerender);
        Trianglerender.positionCount = 0;
    }


}

