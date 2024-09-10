using AngouriMath;
using static AngouriMath.MathS;
using static AngouriMath.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CartFunc : MonoBehaviour
{
    public LineRenderer funcrender;
    Material material;
    Color linecolor;
    public string linecolorhex;

    public void DrawFunc(string val0,string name)
    {
        BornFunc(name);
        val0 = val0.Replace('[', '(');
        val0 = val0.Replace(']', ')');

        Entity x = FromString(val0);


        funcrender.positionCount = 0;

        for (float loopx = -CameraMax.CamMaxX; loopx < CameraMax.CamMaxX; loopx += 0.1f)
        {
            Func<float, float> func = x.Compile<float, float>("x");
            funcrender.SetPosition(funcrender.positionCount++, new Vector2(loopx, func(loopx)));


        }
    }
    private LineRenderer SetfuncrenderParams(LineRenderer funcrenderer)
    {
        linecolorhex = "#a8d0c5";
        ColorUtility.TryParseHtmlString(linecolorhex, out linecolor);
        material = funcrenderer.GetComponent<Renderer>().material;
        material.color = linecolor;
        material.shader = Shader.Find("UI/Default");
        funcrender.SetWidth(0.08f, 0.08f);

        return funcrenderer;
    }

    private void BornFunc(string name)
    {
        GameObject line = new GameObject(name);
        funcrender = line.AddComponent<LineRenderer>();
        funcrender = SetfuncrenderParams(funcrender);
        funcrender.positionCount = 0;
    }

}
