using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderManager : MonoBehaviour
{
    
    public GameObject vertexCount;

    public void setVertexCount(float value){
        Debug.Log("Vertex Count: " + value);
    }

    public GameObject rayCount;
    public void setRayCount(float value){
        Debug.Log("Ray Count: " + value);
    }

}
