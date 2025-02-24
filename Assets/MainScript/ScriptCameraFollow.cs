using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCameraFollow : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    public float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0, 0.5f, -10);
    private Vector3 velocity = Vector3.zero;
    public static ScriptCameraFollow instance { get; private set; }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
            Application.targetFrameRate = 60;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    // Vector3 desiredPosition = target.position + offset;
    // transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

    // }
}
