using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphicsPipeline : MonoBehaviour
{
    
    Model d;
    Outcode A = new Outcode(new Vector2(-2, -2));
    Outcode B = new Outcode(new Vector2(2, -2));
    Outcode C = new Outcode(new Vector2(0.2f, 0.1f));
    Outcode D = new Outcode(new Vector2(0,0));
    Outcode E = new Outcode(new Vector2(2, -2));
    Outcode F = new Outcode(new Vector2(2, -2));

    Texture2D ourScreen;


    void Start()
    {
       // d = new Model();

      //  A.print(A);
      //  B.print(B);
      //  C.print(C);
        Vector2 start = new Vector2(0.5f, 0.5f);
        Vector2 end = new Vector2(0.0f, 0.0f);

        // LineClip(ref start,ref end);

        ourScreen = new Texture2D(512, 512);
        Renderer screenPlane = FindObjectOfType<Renderer>();
        screenPlane.material.mainTexture = ourScreen;

        if(LineClip(ref start, ref end))
        {
            plot(bresh(Convert(start), Convert(end)));
        }

        

        //bresh(start, end);
        
    }

    private void plot(List<Vector2Int> vList)
    {
        foreach(Vector2Int v in vList)
        {
            ourScreen.SetPixel(v.x, v.y, Color.red);
        }
        ourScreen.Apply();
    }

    private Vector2Int Convert(Vector2 v)
    {
        return new Vector2Int((int)(511 * (v.x + 1) / 2), (int)(511 * (v.y + 1) / 2));
    }

    

    bool LineClip(ref Vector2 start, ref Vector2 end)
    {

        Outcode startOutcode = new Outcode(start);
        Outcode endOutcode = new Outcode(end);

        Outcode inView = new Outcode();
        if ((startOutcode * endOutcode) == inView)
        {
            print("Trivial accept");
            return true;
        }
        if ((startOutcode * endOutcode) != inView)
        {
            print("Trivial reject");
            return false;
        }

        if(startOutcode == inView)
        {
            
            return LineClip(ref end, ref start);
        }

        List<Vector2> points = intersectEdge(start, end, startOutcode);

        foreach(Vector2 v in points)
        {
            Outcode VO = new Outcode(v);
            if(VO == inView)
            {
                start = v;
                return LineClip(ref start, ref end);

            }
        }
        
        return false;
        
    }
    List<Vector2> intersectEdge(Vector2 start, Vector2 end, Outcode pointOutcode)
    {
        float m = (end.y - start.y) / (end.x - start.x);
        List<Vector2> intersections = new List<Vector2>();

        if (pointOutcode.UP)
        {
            intersections.Add(new Vector2(start.x + (1 / m) * (1 - start.y), 1));
        }
        if (pointOutcode.DOWN)
        {
            intersections.Add(new Vector2(start.x + (1 / m) * (-1 - start.y), -1));

        }
        if (pointOutcode.LEFT)
        {
            intersections.Add(new Vector2(-1, start.y + m * (-1 - start.x)));

        }
        if (pointOutcode.RIGHT)
        {
            intersections.Add(new Vector2(1, start.y + m * (1 - start.x)));
        }
        return intersections;
    }

    List<Vector2Int> bresh(Vector2Int start, Vector2Int end)
    {
        List<Vector2Int> hold = new List<Vector2Int>();

        int dx = end.x - start.x;
        if (dx < 0)
            return bresh(end, start);
        int dy = end.y - start.y;
        if (dy < 0)
            return NegY(bresh(NegY(start), NegY(end)));

        if (dy > dx)
            return SwapXY(bresh(SwapXY(start), SwapXY(end)));

        int twodxdy = 2*(dy - dx);
        int twody = 2*(dy);

        int P = twody - dx;

        int y = start.y;

        for(int x = start.x; x <= end.x; x++)
        {
            hold.Add(new Vector2Int(x, y));
            if (P<=0)
            {
                P += twody;
            }
            else
            {
                P += twodxdy;
                y++;
            }
        }

        return hold;

    }

    private List<Vector2Int> SwapXY(List<Vector2Int> vector2Ints)
    {
        List<Vector2Int> hold = new List<Vector2Int>();

        foreach (Vector2Int v in vector2Ints)
        {
            hold.Add(SwapXY(v));
        }
        return hold;
    }

    private Vector2Int SwapXY(Vector2Int v)
    {
        return new Vector2Int(v.y, v.x);
    }

    private List<Vector2Int> NegY(List<Vector2Int> vector2Ints)
    {
        List<Vector2Int> hold = new List<Vector2Int>();

        foreach(Vector2Int v in vector2Ints)
        {
            hold.Add(NegY(v));
        }
        return hold;

    }

    private Vector2Int NegY(Vector2Int v)
    {
        return new Vector2Int(v.x, -v.y);
    }
}
