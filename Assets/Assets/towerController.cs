using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class towerController : MonoBehaviour
{
    public RawImage img;
     GameObject t1;
     GameObject t2;
     GameObject t3;
     GameObject t4;
        // OnClick code goes here ...
        



    


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello");
       t1 = GameObject.FindGameObjectWithTag("cell1");
        t2 = GameObject.FindGameObjectWithTag("cell2");
        t3 = GameObject.FindGameObjectWithTag("cell3");
        t4 = GameObject.FindGameObjectWithTag("cell4");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        Debug.Log("hello");
        img.enabled = true;
        t1.GetComponent<Renderer>().enabled = false;
        t2.GetComponent<Renderer>().enabled = false;
        t3.GetComponent<Renderer>().enabled = false;
        t4.GetComponent<Renderer>().enabled = false;
    }
}
