using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountSetting : MonoBehaviour
{

    public GameObject vertexCount;

    public List<GameObject> rayCount;


    public void increaseVertexCount(){
        vertexCount.GetComponent<Line>().vertexCount *= 2;
    }

    public void decreaseVertexCount(){
        if(vertexCount.GetComponent<Line>().vertexCount > 6)
            vertexCount.GetComponent<Line>().vertexCount /= 2;
    }

    public void increaseRayCount(){
        foreach(GameObject ray in rayCount){
            ray.GetComponent<DrawNormals>().rayCount += 2;
        }
    }

    public void decreaseRayCount(){
        foreach(GameObject ray in rayCount){
            if(ray.GetComponent<DrawNormals>().rayCount > 4)
                ray.GetComponent<DrawNormals>().rayCount -= 2;
        }
    }

}
