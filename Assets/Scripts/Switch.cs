using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool isPresent;
    public float switchAmount = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        isPresent = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.right * (isPresent ? -switchAmount : switchAmount));
            isPresent = !isPresent;
        }
    }
}
