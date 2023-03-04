using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 0.5f;

    void Start()
    {}

    void Update()
    {}

    public void MoveLeft()
    {
        GameObject.FindWithTag("Player").transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
    }

    public void MoveRight()
    {
        GameObject.FindWithTag("Player").transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
    }

    public void MoveUp()
    {
        GameObject.FindWithTag("Player").transform.Translate(0, 0, MoveSpeed * Time.deltaTime);
        Debug.Log("UP");
    }

    public void MoveDown()
    {
        GameObject.FindWithTag("Player").transform.Translate(0, 0, -MoveSpeed * Time.deltaTime);
        Debug.Log("DOWN");
    }
}
