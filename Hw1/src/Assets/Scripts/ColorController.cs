using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    string buttonName;
    
    void Start()
    {}
    
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                buttonName = hit.transform.name;
                //Debug.Log(hit.transform.name);

     //           if (hit.collider != null)
       //         {
         //           GameObject touchedObject = hit.transform.gameObject;
           //     }

                switch (buttonName)
                {
                    case "Red":
                        this.transform.GetChild(4).GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                        break;
                    case "Blue":
                        this.transform.GetChild(4).GetComponent<Renderer>().material.color = new Color(0, 255, 0);
                        break;
                    case "Green":
                        this.transform.GetChild(4).GetComponent<Renderer>().material.color = new Color(0, 0, 255);
                        break;
                    case "Turkuaz":
                        this.transform.GetChild(4).GetComponent<Renderer>().material.color = new Color(0, 255, 255);
                        break;
                }
            }
        }
    }
}
