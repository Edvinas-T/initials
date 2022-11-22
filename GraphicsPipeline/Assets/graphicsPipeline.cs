using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphicsPipeline : MonoBehaviour
{
    float z = 5, angle;
    Model d;
    Outcode A = new Outcode(new Vector2(-2, -2));
    Outcode B = new Outcode(new Vector2(2, -2));
    Outcode C = new Outcode(new Vector2(0.2f, 0.1f));
    Outcode D = new Outcode(new Vector2(0,0));
    Outcode E = new Outcode(new Vector2(2, -2));
    Outcode F = new Outcode(new Vector2(2, -2));

    Texture2D ourScreen;
    Renderer screenPlane;

    void Start()
    {
      
        screenPlane = FindObjectOfType<Renderer>();
        d = new Model();

        //bresh(start, end);

    }


  void Update()
    {
        List<Vector3> verts = d.vertices;

        Matrix4x4 translate = Matrix4x4.TRS(new Vector3(0, 0, 10), Quaternion.identity, Vector3.one);
        Matrix4x4 rotate = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(angle, Vector3.right), Vector3.one);
        Matrix4x4 projection = Matrix4x4.Perspective(90, 1, 1, 1000);
        z += 0.05f;
        angle++;

        Matrix4x4 allTrans = projection *rotate* translate;

        List<Vector3> imageAfter = d.get_image(verts, allTrans);
        if (ourScreen)
            Destroy(ourScreen);
        ourScreen = new Texture2D(512, 512);
        screenPlane.material.mainTexture = ourScreen;

        foreach (Vector3Int face in d.faces)
        {
            drawline(imageAfter[face.x], imageAfter[face.y]);

            drawline(imageAfter[face.y], imageAfter[face.z]);

            drawline(imageAfter[face.z], imageAfter[face.x]);
        }

        ourScreen.Apply();

    }

    private void drawline(Vector3 v13dH, Vector3 v23dH)
    {
        print(v13dH.ToString());

        if ((v13dH.z < 0) && (v23dH.z < 0))
        {
            Vector2 v1 = new Vector2(v13dH.x / v13dH.z, v13dH.y / v13dH.z);
            Vector2 v2 = new Vector2(v23dH.x / v23dH.z, v23dH.y / v23dH.z);
            if (LineClip(ref v1, ref v2))
            {
                print("Line from " + v1.ToString() + " to " + v2.ToString());
                plot(bresh(Convert(v1), Convert(v2)));
            }
        }
    }

    private void plot(List<Vector2Int> vList)
    {
        foreach(Vector2Int v in vList)
        {
            ourScreen.SetPixel(v.x, v.y, Color.red);
        }
     
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
        if ((startOutcode + endOutcode) == inView)
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
