using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//idk what Im doing, coding is a hell, I cant figure out how to get these to not start in the middle of the course
public class verticalmovin : MonoBehaviour
{
    public float speed = 1.0f;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        transform.position.Set(70, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move the wall from 74.14, -0.012, 0 to 71.49, -0.012, 0
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speed, 8));
    }
}