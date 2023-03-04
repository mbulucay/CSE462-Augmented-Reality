using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Vector3 p1;  
    public Vector3 p2;
    public Vector3 p3;
    
    public float vertexCount = 256;
    public float lineWidth = 0.01f;    
    
    LineRenderer lineRenderer;
    void Start()
    {

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        List<Vector3> points = new List<Vector3>();

        for(float i=0; i<=1; i+=1/vertexCount){
            Vector3 p1_ = Vector3.Lerp(p1, p2, i);
            Vector3 p2_ = Vector3.Lerp(p2, p3, i);

            Vector3 p = Vector3.Lerp(p1_, p2_, i);
            points.Add(p);
        }

        lineRenderer.positionCount = points.Count + 1;
        points.Add(p3);
        lineRenderer.SetPositions(points.ToArray());
    }

    void Update()
    {
        
    }
}
