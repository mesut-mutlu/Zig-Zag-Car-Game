using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 10f, 0) * Time.deltaTime);     //platform doner
    }
}
