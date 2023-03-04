using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalChange : MonoBehaviour
{

    [SerializeField] public GameObject obj;

    public GameObject Dragon;
    public GameObject Snake;
    public GameObject Tiger;
    public GameObject Crane;


    public void changeAnimal(int shape)
    {
        Destroy(obj.transform.GetChild(0).gameObject);

        GameObject GShape = null;
        switch (shape)
        {
            case 0:
                GShape = Instantiate(Dragon, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case 1:
                GShape = Instantiate(Snake, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case 2:
                GShape = Instantiate(Tiger, new Vector3(0, 0, 0), Quaternion.identity);
                break;
            case 3:
                GShape = Instantiate(Crane, new Vector3(0, 0, 0), Quaternion.identity);
                break;
        }

        GShape.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        GShape.transform.parent = obj.transform;
        GShape.transform.position = obj.transform.position;
    }
}
