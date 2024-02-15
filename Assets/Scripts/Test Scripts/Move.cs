using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //float moveSpeed = 2.0f;
        //float move = Input.GetAxisRaw("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
          float moveSpeed = 2.0f;
        float move = Input.GetAxisRaw("Horizontal");
        transform.localPosition += new Vector3(move, 0.0f) * Time.deltaTime * moveSpeed;
    }
}
