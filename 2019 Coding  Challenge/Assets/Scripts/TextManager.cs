using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class TextManager : MonoBehaviour
{
    public Text Lat, Lon, Dir;

    GameObject dialog = null;
    //public Text gpsinfo;
    void StartLocationCheck()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
#endif
    }

    void Checks()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            // The user denied permission to use the microphone. 
            // Display a message explaining why you need it with Yes/No buttons. 
            // If the user says yes then present the request again 
            // Display a dialog here. 
            dialog.AddComponent<PermissionsRationaleDialog>();
            return;
        }
        else if (dialog != null)
        {
            Destroy(dialog);
        }
#endif
        // Now you can do things with the microphone 
    }

    void UpdateLocation()
    {

    }
    // Start is called before the first frame update 
    IEnumerator Start()
    {
        StartLocationCheck();

        Input.compass.enabled = true;

        // First, check if user has location service enabled 
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location 
        Input.location.Start(10, 0.01f);

        // Wait until service initializes 
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds 
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed 
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved 
            Lat.text = "LAT: " + (Input.location.lastData.latitude).ToString();
            Lon.text = "LON: " + (Input.location.lastData.longitude).ToString();
            Dir.text = "Heading: " + Input.compass.magneticHeading.ToString();
        }

        Checks();

        // Connection has failed 
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved 
            Lat.text = "LAT: " + (Input.location.lastData.latitude).ToString();
            Lon.text = "LON: " + (Input.location.lastData.longitude).ToString();
            Dir.text = "Heading: " + Input.compass.magneticHeading.ToString();
        }
    }

    // Update is called three times per Second 
    void FixedUpdate()
    {
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location inside Update");
        }
        else
        {
            // Access granted and location value could be retrieved 
            Lat.text = "LAT: " + (Input.location.lastData.latitude).ToString();
            Lon.text = "LON: " + (Input.location.lastData.longitude).ToString();
            Dir.text = "Heading: " + Input.compass.magneticHeading.ToString();
        }
    }
}