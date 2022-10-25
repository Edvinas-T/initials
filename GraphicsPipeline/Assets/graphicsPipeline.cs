using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graphicsPipeline : MonoBehaviour
{
    
    Model d;
    Outcode A = new Outcode(new Vector2(-2, -2));
    Outcode B = new Outcode(new Vector2(2, -2));
    Outcode C = new Outcode(new Vector2(0.2f, 0.1f));



    void Start()
    {
        d = new Model();

      //  A.print(A);
      //  B.print(B);
      //  C.print(C);
        Vector2 start = new Vector2(-1, -2);
        Vector2 end = new Vector2(3, 4);

        LineClip(ref start,ref end);
        
    }


    bool LineClip(ref Vector2 start, ref Vector2 end)
    {

        Outcode startOutcode = new Outcode(start);
        Outcode endOutcode = new Outcode(end);

        Outcode inView = new Outcode();
        if ((startOutcode + endOutcode) == inView)
        {
            print("inview");
            return true;
        }
        if ((startOutcode * endOutcode) != inView)
        {
            print("outofview");
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
}
