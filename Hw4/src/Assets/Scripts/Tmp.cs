using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
public class Tmp : MonoBehaviour
{
    LineRenderer lineRenderer;
    public int rayCount = 12;

    public int powerLight = 6;
    public GameObject prefab;
    GameObject blackHole;

    void Start()
    {
        // mesh = GetComponent<MeshFilter>().mesh;
        lineRenderer = GetComponent<LineRenderer>();

        blackHole = GameObject.Find("BlackHole");

        // triangles = mesh.triangles;
        // normals = mesh.normals;
        // numLines = triangles.Length;

        // lineRenderer.positionCount = numLines * 2;
        // lineRenderer.startColor = Color.yellow;
        

        // for (int i = 0; i < numLines; i += 3)
        // {
        //     Vector3 center = (mesh.vertices[triangles[i]] + mesh.vertices[triangles[i + 1]] + mesh.vertices[triangles[i + 2]]) / 3;
        //     lineRenderer.SetPosition(i, center);
        //     lineRenderer.SetPosition(i + 1, center + normals[i / 3]);
        // }


        // mesh = this.transform.GetComponent<MeshFilter>().mesh;

        // int[] triangles = mesh.triangles;
        // Vector3[] normals = mesh.normals;
        // int numLines = triangles.Length;

        // for (int i = 0; i < numLines; i += 3)
        // {
        //     Vector3 center = (mesh.vertices[triangles[i]] + mesh.vertices[triangles[i + 1]] + mesh.vertices[triangles[i + 2]]) / 3;
        //     // Debug.DrawLine(center, center + normals[i / 3], Color.yellow, Mathf.Infinity);
        //     // Debug.DrawLine(center + normals[i / 3], Vector3.zero, Color.yellow, Mathf.Infinity);
        //     Debug.DrawLine(center, Vector3.zero, Color.yellow, Mathf.Infinity);
        // }


        // draw lines 360 * 360 deegre as sphere around the center of the cube
        // for (int i = 0; i < 45; i++)
        // {
        //     for (int j = 0; j < 45; j++)
        //     {
        //         float x = Mathf.Sin(i) * Mathf.Cos(j);
        //         float y = Mathf.Sin(i) * Mathf.Sin(j);
        //         float z = Mathf.Cos(i);
        //         Vector3 point = new Vector3(x, y, z);
        //         Debug.DrawLine(this.transform.position, point, Color.yellow, Mathf.Infinity);
        //     }
        // }

        for (int i = 0; i < rayCount; i++)
        {
            for (int j = 0; j < rayCount; j++)
            {
                float x = Mathf.Sin(i) * Mathf.Cos(j);
                float y = Mathf.Sin(i) * Mathf.Sin(j);
                float z = Mathf.Cos(i);
                Vector3 point = new Vector3(x*powerLight, y*powerLight, z*powerLight);

                GameObject obj = Instantiate(prefab) as GameObject;
                obj.transform.parent = transform;

                // obj.GetComponent<LineRenderer>().positionCount = 3;
                // obj.GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
                // obj.GetComponent<LineRenderer>().SetPosition(1, point);
                
                // // increase the length of the line
                // obj.GetComponent<LineRenderer>().startWidth = 0.01f;
                // obj.GetComponent<LineRenderer>().endWidth = 0.01f;
                // obj.GetComponent<LineRenderer>().SetPosition(2, new Vector3(10, 10, 10));

                obj.GetComponent<Line>().p1 = this.transform.position;
                obj.GetComponent<Line>().p2 = point;
                obj.GetComponent<Line>().p3 = point;
                obj.GetComponent<Line>().p3 = blackHole.transform.position;

                // lineRenderer.SetPosition((i * num) + j + 1, point);
            }
        }

    }

    void Update()
    {
        // for (int i = 0; i < numLines; i += 3)
        // {
        //     Vector3 center = (mesh.vertices[triangles[i]] + mesh.vertices[triangles[i + 1]] + mesh.vertices[triangles[i + 2]]) / 3;
        //     Debug.DrawLine(center, center + normals[i / 3], Color.yellow, 1000f);
            
            
        //     lineRenderer.SetPosition(i, center);
        //     lineRenderer.SetPosition(i + 1, center + normals[i / 3]);
        // }
    }
}
