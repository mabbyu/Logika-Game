using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    void Update()
    {
        print (Time.deltaTime);
        transform.Rotate(new Vector3(50, 0, 0) * Time.deltaTime);
    }
}
