using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
public class DrawNormals : MonoBehaviour
{
    LineRenderer lineRenderer;
    public int rayCount = 12;

    public float powerLight = 6;
    public GameObject prefab;
    GameObject blackHole;

    private IEnumerator refresh;
[SerializeField] float frequency = 1f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        blackHole = GameObject.Find("BlackHole");
        if(blackHole == null){
            blackHole = GameObject.Find("BlackHole(Clone)");
        }

        refresh = RefreshRays();
        StartCoroutine(refresh);

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

                obj.GetComponent<Line>().p1 = this.transform.position;
                obj.GetComponent<Line>().p2 = point;
                if(blackHole != null){
                    obj.GetComponent<Line>().p3 = blackHole.transform.position;
                }
                else{
                    obj.GetComponent<Line>().p3 = point;
                }

            }
        }
    }

    void Update()
    {
    }

    private IEnumerator RefreshRays()
    {

        while (true)
        {
            blackHole = GameObject.Find("BlackHole");

            // delete all children
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            
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

                    obj.GetComponent<Line>().p1 = this.transform.position;
                    obj.GetComponent<Line>().p2 = point;
                    if(blackHole != null){
                        obj.GetComponent<Line>().p3 = blackHole.transform.position;
                    }
                    else{
                        obj.GetComponent<Line>().p3 = point;
                    }

                }
            }

            yield return new WaitForSecondsRealtime(frequency);

        }
    }

}
