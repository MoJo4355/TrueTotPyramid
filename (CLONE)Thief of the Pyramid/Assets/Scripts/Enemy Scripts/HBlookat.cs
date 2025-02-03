using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBlookat : MonoBehaviour
{

    public Camera Camera;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(2 * transform.position - Camera.main.transform.position);
    }
}
