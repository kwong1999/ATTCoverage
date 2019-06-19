using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compassDirection : MonoBehaviour {
    Text txt;
    // Use this for initialization
    void Start() {
        txt = gameObject.GetComponent<Text>();
        Input.location.Start();
        Input.compass.enabled = true;

    }

 





// Update is called once per frame
void Update () {
        //Debug.Log(Input.compass.trueHeading.ToString());
       if (!Input.location.isEnabledByUser)
        {
            Debug.Log("fail");
            return;
        }
        Input.location.Start();
        Input.compass.enabled = true;
        txt.text = (-Input.compass.trueHeading).ToString();
	}
}
