using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowDirect : MonoBehaviour
{
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arrow.transform.Rotate(0, 0, 1, Space.Self);
        
    }
}
