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

        A.print(A);
        B.print(B);
        C.print(C);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
