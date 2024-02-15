using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{

    [SerializeField] private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position + new Vector3(0f, 4f, 0f);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + new Vector3(0.0f, Mathf.Sin(Time.time * 0.5f)*4f, 0.0f *4f);  
    }
}
