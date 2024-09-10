using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartObjects
{
    public CartObjects()
    {
        VectorObjts = new Dictionary<string, CartVector>();
        LineObjts = new Dictionary<string, CartLine>();

    }
    public enum CartObjTypes
    {
        Line,
        Angle,
        Tringle,
        EMPTY
    }

    public CartObjTypes ContainsKey(string id)
    {
        if (ContainsKeyLine(id))
        {
            return CartObjTypes.Line;
        }
        return CartObjTypes.EMPTY;
    }
    #region VECTOR
    public Dictionary<string, CartVector> VectorObjts;

    public void AddVec(string id, Vector2 p0, Vector2 p1,string name)
    {
        VectorObjts.Add(id, new CartVector());
        VectorObjts[id].CreateVec(p0, p1, name);
    }
    #endregion

    #region LINE
    public Dictionary<string, CartLine> LineObjts;
    public void AddLine(string id, float m, float x, float b, string name)
    {
        LineObjts.Add(id, new CartLine());
        LineObjts[id].CreateLine(m,b,name);
    }
    public void DeleteLine(string id)
    {
        LineObjts.Remove(id);
    }
    public float GetSlope(string id)
    {
        return LineObjts[id].m;
    }
    public float GetIntercept(string id)
    {
        return LineObjts[id].b;
    }
    public Vector2 GetPoint(string id,int index)
    {
        return LineObjts[id].linerender.GetPosition(index);
    }
    public Vector3[] GetPoints(string id, int index)
    {
        Vector3[] allpoints = new Vector3[LineObjts[id].linerender.positionCount];

        LineObjts[id].linerender.GetPositions(allpoints);
        return allpoints;
    }
    public int GetNumberOfPoints(string id )
    {
        return LineObjts[id].linerender.positionCount;
    }
    public bool ContainsKeyLine(string id)
    {
        return LineObjts.ContainsKey(id);
    }
    #endregion

}
