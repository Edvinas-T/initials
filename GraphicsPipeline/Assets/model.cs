using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Model
{
    internal object renderer;
    List<Vector3> vertices;
    List<Vector3Int> faces;
    List<Vector2> textureVertices;
    List<Vector3Int> textureFaces;


    public Model()
    {
        add_vertices();
        add_faces();

        CreateUnityGameObject();
    }

            public GameObject CreateUnityGameObject()

            {

                Mesh mesh = new Mesh();

                GameObject newGO = new GameObject();

                MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();

                MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();


                List<Vector3> coords = new List<Vector3>();

                List<int> dummy_indices = new List<int>();

                List<Vector2> text_coords = new List<Vector2>();

                List<Vector3> normalz = new List<Vector3>();



                for (int i = 0; i < faces.Count; i++)

                {

                    //Vector3 normal_for_face = normals[i / 3];

                   // normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

                    coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3); text_coords.Add(textureVertices[textureFaces[i].x]); //normalz.Add(normal_for_face);

                    coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 1); text_coords.Add(textureVertices[textureFaces[i].y]); //normalz.Add(normal_for_face);

                    coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 2); text_coords.Add(textureVertices[textureFaces[i].z]);// normalz.Add(normal_for_face);

                }



                mesh.vertices = coords.ToArray();

                mesh.triangles = dummy_indices.ToArray();

                mesh.uv = text_coords.ToArray();

                mesh.normals = normalz.ToArray(); ;



                mesh_filter.mesh = mesh;

                return newGO;



            }
  

    private void add_faces()
    {
        faces = new List<Vector3Int>();
        textureFaces = new List<Vector3Int>();
/*
        //Front
        faces.Add(new Vector3Int(0,2,5));       
        faces.Add(new Vector3Int(0,5,1));       
        faces.Add(new Vector3Int(3,6,7));   
        faces.Add(new Vector3Int(3,7,4));
        faces.Add(new Vector3Int(8,9,7));
        faces.Add(new Vector3Int(8,7,6));

        textureFaces.Add(new Vector3Int(0, 2, 5));
        textureFaces.Add(new Vector3Int(0, 5, 1));
        textureFaces.Add(new Vector3Int(3, 6, 7));
        textureFaces.Add(new Vector3Int(3, 7, 4));
        textureFaces.Add(new Vector3Int(8, 9, 7));
        textureFaces.Add(new Vector3Int(8, 7, 6));

        //Back
        faces.Add(new Vector3Int(11,15,12));
        faces.Add(new Vector3Int(11,12,10));
        faces.Add(new Vector3Int(14,17,16));
        faces.Add(new Vector3Int(14,16,13));
        faces.Add(new Vector3Int(19,18,16));
        faces.Add(new Vector3Int(19,16,17));

        textureFaces.Add(new Vector3Int(11, 15, 12));
        textureFaces.Add(new Vector3Int(11, 12, 10));
        textureFaces.Add(new Vector3Int(14, 17, 16));
        textureFaces.Add(new Vector3Int(14, 16, 13));
        textureFaces.Add(new Vector3Int(19, 18, 16));
        textureFaces.Add(new Vector3Int(19, 16, 17));
 */
        //Top
        faces.Add(new Vector3Int(0, 1, 11));
        faces.Add(new Vector3Int(0, 11, 10));
        faces.Add(new Vector3Int(10, 0, 11));

        textureFaces.Add(new Vector3Int(0, 1, 11));
        textureFaces.Add(new Vector3Int(0, 11, 10));
        textureFaces.Add(new Vector3Int(10, 0,11));
        /*
                //Left
                faces.Add(new Vector3Int(0, 10, 12));
                faces.Add(new Vector3Int(0, 12, 2));
                faces.Add(new Vector3Int(6, 16, 18));
                faces.Add(new Vector3Int(6, 18, 8));
                faces.Add(new Vector3Int(3, 13, 16));
                faces.Add(new Vector3Int(3, 16, 6));

                textureFaces.Add(new Vector3Int(0, 10, 12));
                textureFaces.Add(new Vector3Int(0, 12, 2));
                textureFaces.Add(new Vector3Int(6, 16, 18));
                textureFaces.Add(new Vector3Int(6, 18, 8));
                textureFaces.Add(new Vector3Int(3, 13, 16));
                textureFaces.Add(new Vector3Int(3, 16, 6));
                //Right
                faces.Add(new Vector3Int(5, 15, 11));
                faces.Add(new Vector3Int(5, 11, 1));
                faces.Add(new Vector3Int(9, 19, 17));
                faces.Add(new Vector3Int(9, 17, 7));
                faces.Add(new Vector3Int(7, 17, 14));
                faces.Add(new Vector3Int(7, 14, 4));

                textureFaces.Add(new Vector3Int(5, 15, 11));
                textureFaces.Add(new Vector3Int(5, 11, 1));
                textureFaces.Add(new Vector3Int(9, 19, 17));
                textureFaces.Add(new Vector3Int(9, 17, 7));
                textureFaces.Add(new Vector3Int(7, 17, 14));
                textureFaces.Add(new Vector3Int(7, 14, 4));
                //Bottom
                faces.Add(new Vector3Int(8,18,19));
                faces.Add(new Vector3Int(8,19,9));
                faces.Add(new Vector3Int(2,12,13));
                faces.Add(new Vector3Int(2,13,3));
                faces.Add(new Vector3Int(4,14,15));
                faces.Add(new Vector3Int(4,15,5));

                textureFaces.Add(new Vector3Int(8, 18, 19));
                textureFaces.Add(new Vector3Int(8, 19, 9));
                textureFaces.Add(new Vector3Int(2, 12, 13));
                textureFaces.Add(new Vector3Int(2, 13, 3));
                textureFaces.Add(new Vector3Int(4, 14, 15));
                textureFaces.Add(new Vector3Int(4, 15, 5));


            */


    }

    private void add_vertices()
    {
        vertices = new List<Vector3>();
        textureVertices = new List<Vector2>();
        vertices.Add(new Vector3(-3, 3, 1)); textureVertices.Add(new Vector2(51, 51));
        vertices.Add(new Vector3(4, 3, 1)); textureVertices.Add(new Vector2(237, 51));
        vertices.Add(new Vector3(-3, 2, 1)); textureVertices.Add(new Vector2(51, 82));
        vertices.Add(new Vector3(-1, 2, 1)); textureVertices.Add(new Vector2(114, 82));
        vertices.Add(new Vector3(2, 2, 1)); textureVertices.Add(new Vector2(172, 82));
        vertices.Add(new Vector3(4, 2, 1)); textureVertices.Add(new Vector2(238, 82));
        vertices.Add(new Vector3(0, 1, 1)); textureVertices.Add(new Vector2(128, 110));
        vertices.Add(new Vector3(1, 1, 1)); textureVertices.Add(new Vector2(158, 110));
        vertices.Add(new Vector3(0, -4, 1)); textureVertices.Add(new Vector2(128, 285));
        vertices.Add(new Vector3(1, -4, 1)); textureVertices.Add(new Vector2(156, 285));
        vertices.Add(new Vector3(-3, 3 - 1)); textureVertices.Add(new Vector2(51, 51));
        vertices.Add(new Vector3(4, 3, -1)); textureVertices.Add(new Vector2(237, 51));
        vertices.Add(new Vector3(-3, 2, -1)); textureVertices.Add(new Vector2(51, 82));
        vertices.Add(new Vector3(-1, 2, -1)); textureVertices.Add(new Vector2(114, 82));
        vertices.Add(new Vector3(2, 2, -1)); textureVertices.Add(new Vector2(172, 82));
        vertices.Add(new Vector3(4, 2, -1)); textureVertices.Add(new Vector2(238, 82));
        vertices.Add(new Vector3(0, 1, -1)); textureVertices.Add(new Vector2(128, 110));
        vertices.Add(new Vector3(1, 1, -1)); textureVertices.Add(new Vector2(158, 110));
        vertices.Add(new Vector3(0, -4, -1)); textureVertices.Add(new Vector2(128, 285));
        vertices.Add(new Vector3(1, -4, -1)); textureVertices.Add(new Vector2(156, 285));

        textureVertices = getRelativeValues(textureVertices, 512, 512);

        Vector3 axis = new Vector3(16, 2, 2);
            axis.Normalize();

        Matrix4x4 rotationMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(-36, axis), Vector3.one);
      //  print_matrix(rotationMatrix);

        Matrix4x4 scaleMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,new Vector3(16,2,2));
        print_matrix(scaleMatrix);
        List<Vector3> image_after_rotation = get_image(vertices, rotationMatrix);
      //  print_verts(image_after_rotation);
        
    }
    private void print_verts(List<Vector3> v_list)
    {
        string path = "Assets/test.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        foreach (Vector3 v in v_list)
        {
            writer.WriteLine(v.x.ToString() + "   ,   " + v.y.ToString() + "   ,   " + v.z.ToString() + "   ,   ");

        }
        writer.Close();
    }

    private List<Vector3> get_image(List<Vector3> vertices, Matrix4x4 rotationMatrix)
    {
        List<Vector3> hold = new List<Vector3>();
        foreach(Vector3 v in vertices)
        {
            hold.Add(rotationMatrix * v);
        }
        return hold;
    }
    private void print_matrix(Matrix4x4 matrix)
    {
        string path = "Assets/test.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        for (int i = 0; i < 4; i++)
        {
            Vector4 row = matrix.GetRow(i);
            writer.WriteLine(row.x.ToString() + "   ,   " + row.y.ToString() + "   ,   " + row.z.ToString() + "   ,   " + row.w.ToString());


        }

        writer.Close();

    }

    private List<Vector2> getRelativeValues(List<Vector2> textureVertices, int resolutionX, int resolutionY)
    {
        List<Vector2> hold = new List<Vector2>();
        foreach(Vector2 v in textureVertices)
        {
            hold.Add(new Vector2(v.x / resolutionX, 1-v.y / resolutionY));
        }
        return hold;
    }
}
