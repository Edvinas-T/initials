using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outcode
{

    public bool UP, DOWN, LEFT, RIGHT;

    public Outcode(Vector2 v)
    {
        UP = (v.y > 1);
        RIGHT = (v.x > 1);
        DOWN = (v.y < -1);
        LEFT = (v.x < -1);
        
    }
    public Outcode(bool up, bool down, bool left, bool right)
    {
        UP = up;
        DOWN = down;
        RIGHT = right;
        LEFT = left;
    }

    public Outcode()
    {
        UP = false;
        DOWN = false;
        RIGHT = false;
        LEFT = false;
    }

    public static Outcode operator * (Outcode A, Outcode B)
    {
        return new Outcode(A.UP && B.UP, A.DOWN && B.DOWN, A.LEFT && B.LEFT, A.RIGHT && B.RIGHT);
    }
    public static Outcode operator +(Outcode A, Outcode B)
    {
        return new Outcode(A.UP || B.UP, A.DOWN || B.DOWN, A.LEFT || B.LEFT, A.RIGHT || B.RIGHT);
    }
    public static bool operator ==(Outcode A, Outcode B)
    {
        return (A.UP == B.UP)&& (A.DOWN == B.DOWN) && (A.LEFT == B.LEFT) && (A.RIGHT == B.RIGHT);
    }

    public static bool operator !=(Outcode A, Outcode B)
    {
        return !(A == B);
    }
    

    public void print(Outcode A)
    {
        string O = (UP ? "1" : "0") + (DOWN ? "1" : "0") + (LEFT ? "1" : "0") + (RIGHT ? "1" : "0");
        Debug.Log(O);
        
    }



}
