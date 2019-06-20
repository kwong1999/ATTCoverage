using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lat : MonoBehaviour {
    Text txt;
	// Use this for initialization
	void Start () {
        txt = gameObject.GetComponent<Text>();
        //Input.location.Start();
        //Input.compass.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("fail");
            return;
        }
        Input.location.Start(5,1);
        Input.compass.enabled = true;
        txt.text = "Lat: " + Input.location.lastData.latitude.ToString() + "     Lon: " + Input.location.lastData.longitude.ToString();
        Debug.Log(Input.location.lastData.latitude.ToString());

    }
}
