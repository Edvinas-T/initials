using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    List<Vector3> vertices;
    List<Vector3Int> faces;


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

                    coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3);// text_coords.Add(_texture_coordinates[_texture_index_list[i].x]); normalz.Add(normal_for_face);

                    coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 1);// text_coords.Add(_texture_coordinates[_texture_index_list[i].y]); normalz.Add(normal_for_face);

                    coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 2); //text_coords.Add(_texture_coordinates[_texture_index_list[i].z]); normalz.Add(normal_for_face);

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

        //Front
        faces.Add(new Vector3Int(0, 2, 5));
        faces.Add(new Vector3Int(0,5,1));
        faces.Add(new Vector3Int(3,6,7));
        faces.Add(new Vector3Int(3,7,4));
        faces.Add(new Vector3Int(8,9,7));
        faces.Add(new Vector3Int(8,7,6));
        //Back
        faces.Add(new Vector3Int(11,15,12));
        faces.Add(new Vector3Int(11,12,10));
        faces.Add(new Vector3Int(14,17,16));
        faces.Add(new Vector3Int(14,16,13));
        faces.Add(new Vector3Int(19,18,16));
        faces.Add(new Vector3Int(19,16,17));
        //Top
        faces.Add(new Vector3Int(0, 1, 11));
        faces.Add(new Vector3Int(0, 11, 10));
        //Left
        faces.Add(new Vector3Int(0, 10, 12));
        faces.Add(new Vector3Int(0, 12, 2));
        faces.Add(new Vector3Int(6, 16, 18));
        faces.Add(new Vector3Int(6, 18, 8));
        faces.Add(new Vector3Int(3, 13, 16));
        faces.Add(new Vector3Int(3, 16, 6));
        //Right
        faces.Add(new Vector3Int(5, 15, 11));
        faces.Add(new Vector3Int(5, 11, 1));
        faces.Add(new Vector3Int(9, 19, 17));
        faces.Add(new Vector3Int(9, 17, 7));
        faces.Add(new Vector3Int(7, 17, 14));
        faces.Add(new Vector3Int(7, 14, 4));
        //Bottom
        faces.Add(new Vector3Int(8,18,19));
        faces.Add(new Vector3Int(8,19,9));
        faces.Add(new Vector3Int(2,12,13));
        faces.Add(new Vector3Int(2,13,3));
        faces.Add(new Vector3Int(4,14,15));
        faces.Add(new Vector3Int(4,15,5));
         
                 
                

    }

    private void add_vertices()
    {
        vertices = new List<Vector3>();
        vertices.Add(new Vector3(-3,3,1));
        vertices.Add(new Vector3(4,3,1));
        vertices.Add(new Vector3(-3,2,1));
        vertices.Add(new Vector3(-1,2,1));
        vertices.Add(new Vector3(2,2,1));
        vertices.Add(new Vector3(4,2,1));
        vertices.Add(new Vector3(0,1,1));
        vertices.Add(new Vector3(1,1,1));
        vertices.Add(new Vector3(0,-4,1));
        vertices.Add(new Vector3(1,-4,1));
        vertices.Add(new Vector3(-3, 3, -1));
        vertices.Add(new Vector3(4, 3, -1));
        vertices.Add(new Vector3(-3, 2, -1));
        vertices.Add(new Vector3(-1, 2, -1));
        vertices.Add(new Vector3(2, 2, -1));
        vertices.Add(new Vector3(4, 2, -1));
        vertices.Add(new Vector3(0, 1, -1));
        vertices.Add(new Vector3(1, 1, -1));
        vertices.Add(new Vector3(0, -4, -1));
        vertices.Add(new Vector3(1, -4, -1));


    }
}
