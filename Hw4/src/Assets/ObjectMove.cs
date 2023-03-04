using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{

    public GameObject target;

    public float speed = 1.0f;

    public void up(){
        target.gameObject.transform.position = new Vector3(target.gameObject.transform.position.x, target.gameObject.transform.position.y + 1, target.gameObject.transform.position.z);
    }

    public void down(){
        target.gameObject.transform.position = new Vector3(target.gameObject.transform.position.x, target.gameObject.transform.position.y - 1, target.gameObject.transform.position.z);
    }

    public void left(){
        target.gameObject.transform.position = new Vector3(target.gameObject.transform.position.x - 1, target.gameObject.transform.position.y, target.gameObject.transform.position.z);
    }

    public void right(){
        target.gameObject.transform.position = new Vector3(target.gameObject.transform.position.x + 1, target.gameObject.transform.position.y, target.gameObject.transform.position.z);
    }

    public void _in(){
        target.gameObject.transform.position = new Vector3(target.gameObject.transform.position.x, target.gameObject.transform.position.y, target.gameObject.transform.position.z + 1);
    }

    public void _out(){
        target.gameObject.transform.position = new Vector3(target.gameObject.transform.position.x, target.gameObject.transform.position.y, target.gameObject.transform.position.z - 1);
    }

    void Update(){
        target = GameObject.Find("BlackHole");
        if(target == null){
            target = GameObject.Find("BlackHole(Clone)");
        }
    }

}
