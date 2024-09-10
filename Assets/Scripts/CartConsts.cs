using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartConsts
{
    public readonly char[] ARITHSIGNS = { '+', '-', '*', '/', '^', '%'};
    enum ARITHSIGNSEnum
    {
        PLUS = 0,
        MINUS = 1,
        MULTIPLICATION = 2,
        DIVISION = 3,
        POWER = 4,
        MODULO = 5
    }
    public CartConsts()
    {
        FUNCKEYWORDS = new string[34];
        FUNCKEYWORDS[0] = "LINE";
    }
    public string ContainsKey(string id)
    {
        foreach (string item in FUNCKEYWORDS)
        {
            if (item == id)
            {
                return item;
            }
        }
        return "NAF";
        // Not a function
    }




    public string[] FUNCKEYWORDS;

}
