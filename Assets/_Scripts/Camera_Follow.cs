using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public GameObject follow_target;
    public float z_offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(follow_target.GetComponent<Transform>().position.x, follow_target.transform.position.y, z_offset);
    }
}
