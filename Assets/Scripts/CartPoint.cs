using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartPoint : MonoBehaviour
{
    Material material;
    Color Pointcolor;
    public string Pointcolorhex;
    public Sprite sprite0;

    public void CreatePoint(Vector2 p0, string name)
    {
        BornPoint(p0, name);


    }
    public Vector2 GetPoint(int position)
    {
        return new Vector2(0,0);
    }
    public void SetPoint(Vector2 point, int index)
    {
    }

    private GameObject SetPointrenderParams(GameObject point)
    {
        Pointcolorhex = "#9F549B";
        ColorUtility.TryParseHtmlString(Pointcolorhex, out Pointcolor);
        material = point.GetComponent<SpriteRenderer>().material;
        material.color = Pointcolor;
        material.shader = Shader.Find("UI/Default");

        return point;
    }

    private void BornPoint(Vector2 p0,string name)
    {
        GameObject newpoint = new GameObject();
        newpoint.name = name;
        newpoint.transform.position = p0;
        newpoint.transform.localScale = new Vector3(0.3f, 0.3f,0);
        newpoint.AddComponent<SpriteRenderer>(); sprite0 = Resources.Load<Sprite>("Sprites/Circle");
        newpoint.GetComponent<SpriteRenderer>().sprite = sprite0;
        newpoint = SetPointrenderParams(newpoint);


    }


}
