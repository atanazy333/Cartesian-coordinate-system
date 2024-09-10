using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cmd : MonoBehaviour
{
    [SerializeField] private GameObject CmdField;
    [SerializeField] private TMP_InputField InField;
    [SerializeField] private GameObject HistoryField;
    [SerializeField] private TMP_InputField InHistoryField;

    private string[] history;
    int histCount = 0;
    int histArrowCount = 0;
    bool run = false;

    [SerializeField] private CartObjects CartObjts;
    private Queue<string> args;
    private float[] Registers = new float[5];

    void Start()
    {
        CmdField  = GameObject.Find("InputField");
        InField   = CmdField.GetComponent<TMP_InputField>();
        HistoryField = GameObject.Find("history");
        InHistoryField = CmdField.GetComponent<TMP_InputField>();
        CartObjts = new CartObjects();
        history   = new string[700];
    }



    void Update()
    {
        if (run == true)
        {
            UpdatesOn();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && InField.isFocused)
        {
            if (histCount > 0)
            {
                if (histArrowCount+1 <= histCount)
                {
                   InField.text = history[histArrowCount++];
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && InField.isFocused)
        {
            if (histCount > 0)
            {
                if (histArrowCount > 0)
                {
                   InField.text = history[histArrowCount--];
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Return) && InField.text != String.Empty)
        {
            ParseOneLine();
        }
    }

    public void ParseOneLine(string linetoparse = "None")
    {
        if (linetoparse != "None")
            InField.text = linetoparse;

        if (InField.text == String.Empty)
            return;

        history[histCount++] = InField.text;
        InHistoryField.text = InField.text + "\n";

        string currentword = "";
        int all = 0;
        args = new Queue<string>();
        //0 element is always a keyword

        for (int i = 0; i < InField.text.Length; i++)
        {
            if (InField.text[i] == ' ')
            {
                InField.text.Remove(i);
                continue;
            }

            if (InField.text[i] == '(' || InField.text[i] == ')')
            {

                if (currentword != String.Empty)
                    args.Enqueue(currentword);

                currentword = String.Empty;
                continue;
            }

            currentword += InField.text[i];
        }

        InField.text = String.Empty;


        switch (args.Dequeue())
        {
            case "point":
                if (args.Count == 2)
                    point(args.Dequeue(), args.Dequeue());
                break;
            case "vec":
                if (args.Count < 3)
                {
                    Debug.Log("ERROR");
                    break;
                }
                if(args.Count == 3)
                    vec(args.Dequeue(), args.Dequeue(), args.Dequeue());
                break;
            case "line":
                if(args.Count == 2)
                    line(args.Dequeue(),args.Dequeue());
                break;
            case "triangle":
                if(args.Count == 4)
                    triangle(args.Dequeue(), args.Dequeue(), args.Dequeue(), args.Dequeue());
                break;
            case "rectangle":
                break;
            case "circle":
                if (args.Count == 3)
                    circle(args.Dequeue(), args.Dequeue(), args.Dequeue());
                break;
            case "sin":
                if (args.Count == 4)
                    sin(args.Dequeue(), args.Dequeue(), args.Dequeue(), args.Dequeue());
                break;
            case "cos":
                if (args.Count == 4)
                    cos(args.Dequeue(), args.Dequeue(), args.Dequeue(), args.Dequeue());
                break;
            case "tan":
                if (args.Count == 4)
                    tan(args.Dequeue(), args.Dequeue(), args.Dequeue(), args.Dequeue());
                break;
            case "figure":
                if (args.Count == 4)
                    figure(args.Dequeue(), args.Dequeue(), args.Dequeue(), args.Dequeue());
                break;
            case "angle":
                if (args.Count == 5)
                    angle(args.Dequeue(), args.Dequeue(), args.Dequeue(), args.Dequeue(), args.Dequeue());
                break;
            case "f":
                if (args.Count == 2)
                    func(args.Dequeue(),args.Dequeue());
                break;
            case "add":
                if (args.Count == 2)
                    add(args.Dequeue(), args.Dequeue());
                break;
            case "sub":
                if (args.Count == 2)
                    sub(args.Dequeue(), args.Dequeue());
                break;
            case "mul":
                if (args.Count == 2)
                    mul(args.Dequeue(), args.Dequeue());
                break;
            case "mov":
                if (args.Count == 2)
                    mov(args.Dequeue(), args.Dequeue());
                break;
            case "cmp":
                if (args.Count == 3)
                    cmp(args.Dequeue(), args.Dequeue(), args.Dequeue());
                break;
            case "inc":
                if (args.Count == 1)
                    inc(args.Dequeue());
                break;
            case "dec":
                if (args.Count == 1)
                    dec(args.Dequeue());
                break;
            case "read":
                if (args.Count == 1)
                    read(args.Dequeue());
                break;
            case "write":
                if (args.Count == 1)
                    write(args.Dequeue());
                break;
            case "delete":
                if (args.Count == 1)
                    delete(args.Dequeue());
                break;
            default:
                //Error
                break;
        }
    }

    public void UpdatesCheck()
    {
        run = !run;
    }
    public void UpdatesOn()
    {

        string readText = GameObject.Find("Main Camera/Console/Canvas/Roll/UpdateField").GetComponent<TMP_InputField>().text;
        string[] cmds = readText.Split('\n');
        foreach (string item in cmds)
        {
            if (item[0] == '#')
            {
                continue;
            }
            else
            {
                ParseOneLine(item);
            }
        }

        
    }

    private float[] BracketParser(string bracket)
    {
        float[] result = new float[8];

        if (bracket == null)
            return result;

        int i = 0;
        string[] args = bracket.Split(',');
        float value;

        foreach (var item in args)
        {

            if (float.TryParse(item, out value))
            {
                result[i++] = value;
            }
            else
            {
                switch (item)
                {
                    case "cax":
                        result[i++] = Registers[0];
                        break;
                    case "cbx ":
                        result[i++] = Registers[1];
                        break;
                    case "cdx":
                        result[i++] = Registers[2];
                        break;
                    case "cbh":
                        result[i++] = Registers[3];
                        break;
                    case "cex":
                        result[i++] = Registers[4];
                        break;
                    default:
                        break;
                }
            }
           
          

        }


        return result;
    }

    private int whichreg(string reg)
    {
        switch (reg)
        {
            case "cax":
                return 0;
            case "cbx":
                return 1;
            case "cdx":
                return 2;
            case "cbh":
                return 3;
            case "cex":
                return 4;
            default:
                return -1;
        }
    }


    private void add(string val1, string reg0)
    {
        float[] result = new float[8];
        result = BracketParser(val1);
        for (int i = 1; i < result.Length; i++)
        {
            result[0] += result[i];
        }
        int regnum = whichreg(reg0);
        if (regnum != -1)
        {
            Registers[regnum] = result[0];
        }
        else
        {
            //error
        }

    }

    private void write(string path)
    {
        File.WriteAllLines(path, history);
    }
    private void read(string path)
    {
        string readText = File.ReadAllText(path);
        string[] cmds = readText.Split('\n');
        foreach (string item in cmds)
        {
            //coments
            if (item[0] == '#')
            {
                continue;
            }
            else
            {
                ParseOneLine(item);
            }
        }
    }

    private void sub(string val1, string reg0)
    {
        float[] result = new float[8];
        result = BracketParser(val1);
        for (int i = 1; i < result.Length; i++)
        {
            result[0] -= result[i];
        }
        int regnum = whichreg(reg0);
        if (regnum != -1)
        {
            Registers[regnum] = result[0];
        }
        else
        {
            //error
        }

    }
    private void mul(string val1, string reg0)
    {
        float[] result = new float[8];
        result = BracketParser(val1);
        for (int i = 1; i < result.Length; i++)
        {
            result[0] *= result[i];
        }
        int regnum = whichreg(reg0);
        if (regnum != -1)
        {
            Registers[regnum] = result[0];
        }
        else
        {
            //error
        }

    }
    private void mov(string reg0, string reg1)
    {
        int regnum0 = whichreg(reg0);
        int regnum1 = whichreg(reg1);

        if (regnum0 != -1 && regnum1 != -1)
        {
            Registers[regnum0] = Registers[regnum1];
        }
        else
        {
            //error
        }

    }
    private void cmp(string val1, string reg0, string reg1)
    {
        float result = 0;
        result = BracketParser(val1)[0];

        int regnum0 = whichreg(reg0);
        if (regnum0 != -1)
        {
            if (Registers[regnum0] == result)
            {
                int regnum1 = whichreg(reg1);
                if (regnum0 != -1)
                {
                    Registers[regnum1] = 1;
                }
                else
                {
                    //error
                }
            }
            else
            {
                int regnum1 = whichreg(reg1);
                if (regnum0 != -1)
                {
                    Registers[regnum1] = 0;
                }
                else
                {
                    //error
                }
            }

        }
    }
        private void inc(string reg0)
    {
        int regnum = whichreg(reg0);
        if (regnum != -1)
        {
            Registers[regnum] = Registers[regnum] - 1;
        }
        else
        {
            //error
        }

    }
    private void dec(string reg0)
    {
        int regnum = whichreg(reg0);
        if (regnum != -1)
        {
            Registers[regnum] = Registers[regnum] + 1;
        }
        else
        {
            //error
        }

    }


    private float view(string reg0)
    {
        int regnum = whichreg(reg0);
        if (regnum != -1)
        {
            return Registers[regnum];
        }
        else
        {
            //error
        }
        return 0;

    }

    private void vec(string vec1, string vec2, string name)
    {
        Vector2 ParsedVec1;
        Vector2 ParsedVec2;
        float[] result = new float[8];


        CartVector vector = new CartVector();
        result = BracketParser(vec1);
        ParsedVec1 = new Vector2(result[0], result[1]);
        result = BracketParser(vec2);
        ParsedVec2 = new Vector2(result[0], result[1]);

        vector.CreateVec(new Vector2(ParsedVec1.x, ParsedVec1.y), new Vector2(ParsedVec2.x, ParsedVec2.y), name);
    }
    private void line(string args, string name)
    {
        CartLine line = new CartLine();
        float[] result = new float[8];

        result = BracketParser(args);

        line.CreateLine(result[0], result[1], name);
    }
    private void point(string vec0, string name)
    {
        CartPoint point0 = new CartPoint();
        float[] result = new float[8];
        Vector2 p0;

        result = BracketParser(vec0);
        p0 = new Vector2(result[0], result[1]);

        point0.CreatePoint(p0, name);
    }
    private void triangle(string vec0, string vec1, string vec2, string name)
    {
        CartTriangle triangle = new CartTriangle();
        float[] result = new float[8];
        Vector2 p0;
        Vector2 p1;
        Vector2 p2;

        result = BracketParser(vec0);
        p0 = new Vector2(result[0], result[1]);
        result = BracketParser(vec1);
        p1 = new Vector2(result[0], result[1]);
        result = BracketParser(vec2);
        p2 = new Vector2(result[0], result[1]);

        triangle.CreateTriangle(p0,p1,p2,name);
    }
    private void sin(string vec0, string val2, string val3, string name)
    {
        CartSin sin = new CartSin();
        float[] result = new float[8];
        Vector2 xlimits; float amplitude; float frequency;
        result = BracketParser(vec0);
        xlimits = new Vector2(result[0], result[1]);
        result = BracketParser(val2);
        amplitude = result[0];
        result = BracketParser(val3);
        frequency = result[0];

        sin.CreateSin(xlimits,amplitude,frequency, name);
    }
    private void cos(string vec0, string val2, string val3, string name)
    {
        CartCos cos = new CartCos();
        float[] result = new float[8];
        Vector2 xlimits; float amplitude; float frequency;
        result = BracketParser(vec0);
        xlimits = new Vector2(result[0], result[1]);
        result = BracketParser(val2);
        amplitude = result[0];
        result = BracketParser(val3);
        frequency = result[0];

        cos.CreateCos(xlimits, amplitude, frequency, name);
    }
    private void tan(string vec0, string val2, string val3, string name)
    {
        CartTan tan = new CartTan();
        float[] result = new float[8];
        Vector2 xlimits; float amplitude; float frequency;
        result = BracketParser(vec0);
        xlimits = new Vector2(result[0], result[1]);
        result = BracketParser(val2);
        amplitude = result[0];
        result = BracketParser(val3);
        frequency = result[0];

        tan.CreateTan(xlimits, amplitude, frequency, name);
    }
    private void figure(string vec0, string val1, string val2, string name)
    {
        CartFigures figure = new CartFigures();
        float[] result = new float[8];
        Vector2 hk; int step; float size;

        result = BracketParser(vec0);
        hk = new Vector2(result[0], result[1]);
        result = BracketParser(val1);
        step = (int)result[0];
        result = BracketParser(val2);
        size = result[0];
        figure.CreateFigures(hk,step,size, name);
    }
    private void angle(string vec0, string vec1, string vec2, string vec3,string name)
    {
        CartAngle angle = new CartAngle();
        float[] result = new float[8];
        Vector2 p0; Vector2 p1; Vector2 p2; Vector2 pos;
        result = BracketParser(vec0);
        p0 = new Vector2(result[0], result[1]);
        result = BracketParser(vec1);
        p1 = new Vector2(result[0], result[1]);
        result = BracketParser(vec2);
        p2 = new Vector2(result[0], result[1]);
        result = BracketParser(vec3);
        pos = new Vector2(result[0], result[1]);

        angle.CreateAngle(p0, p1, p2, pos, name);
    }
    private void circle(string vec0, string val1,string name)
    {
        CartCircle circle = new CartCircle();
        float[] result = new float[8];
        Vector2 hk; float r;

        result = BracketParser(vec0);
        hk = new Vector2(result[0], result[1]);
        result = BracketParser(val1);
        r = result[0];
        circle.CreateCircle(hk, r, name);
    }

    private void func(string val0,string name)
    {
        CartFunc func = new CartFunc();
        func.DrawFunc(val0,name);
    }
    private void delete(string name)
    {
        Destroy(GameObject.Find(name));
    }

}
