using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVirtualObject : MonoBehaviour
{
    [SerializeField] GameObject obj;

    public void changeColor(int color)
    {
        switch (color)
        {
            case 1: obj.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                break;
            case 2: obj.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(0, 255, 0);
                break;
            case 3: obj.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(0, 0, 255);
                break;
            case 4: obj.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(0, 255, 255);
                break;
        }
    }

    public void changeShape(int shape)
    {
        Color currentColor = obj.transform.GetChild(4).GetComponent<Renderer>().material.color;
        Destroy(obj.transform.GetChild(4).gameObject);
        
        GameObject GShape = null;
        switch (shape)
        {
            case 1: GShape = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
            case 2: GShape = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            case 3: GShape = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                break;
        }

        GShape.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        GShape.GetComponent<Renderer>().material.color = currentColor;
        GShape.transform.parent = obj.transform;
        GShape.transform.position = obj.transform.position;
    }
}
