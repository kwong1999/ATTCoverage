using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class towerController : MonoBehaviour, IPointerClickHandler
{
    public RawImage img;
    public RawImage t1;
    public RawImage t2;
    public RawImage t3;
    public RawImage t4;
    public void OnPointerClick(PointerEventData eventData)
    {
        // OnClick code goes here ...
        Debug.Log("hello");
        img.enabled = true;
        t1.enabled = false;
        t2.enabled = false;
        t3.enabled = false;
        t4.enabled = false;



    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
