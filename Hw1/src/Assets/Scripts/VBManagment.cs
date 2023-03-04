/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBManagment : MonoBehaviour
{
    VirtualButtonBehaviour[] VBB;

    void Start()
    {
        VBB = GetComponentsInChildren<VirtualButtonBehaviour>();

        for(int i=0; i<VBB.Length; ++i)
        {
            VBB[i].RegisterOnButtonPressed(OnButtonPressed);
            VBB[i].RegisterOnButtonReleased(OnButtonReleased);
        }
    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        string name = vb.VirtualButtonName;
        Debug.Log(name);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        string name = vb.VirtualButtonName;
        Debug.Log(name);
    }
}
*/

using UnityEngine;
using UnityEngine.Events;
using Vuforia;
     
public class VBManagment : MonoBehaviour
{
    public GameObject vbBtnObj;
    public GameObject Cube;

    void Start()
    {
        vbBtnObj = GameObject.Find("VButton1");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Cube.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Cube.GetComponent<Renderer>().material.color = new Color(255, 255, 0);

    }
}

