using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMarginMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, character.transform.position.y, transform.position.z);
    }
}
