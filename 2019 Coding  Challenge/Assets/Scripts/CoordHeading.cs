using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;

public class CoordHeading : MonoBehaviour
{
    public GameObject arrow;
    public double Bearing(double lat1, double lon1, double lat2, double lon2)
    {
        var dLon = ToRad(lon2 - lon1);
        var dPhi = System.Math.Log(
            System.Math.Tan(ToRad(lat2) / 2 + System.Math.PI / 4) / System.Math.Tan(ToRad(lat1) / 2 + System.Math.PI / 4));
        if (System.Math.Abs(dLon) > System.Math.PI)
            dLon = dLon > 0 ? -(2 * System.Math.PI - dLon) : (2 * System.Math.PI + dLon);
        return ToBearing(System.Math.Atan2(dLon, dPhi));
    }

    private double ToRad(double degrees)
    {
        return degrees * (System.Math.PI / 180);
    }

    public static double ToDegrees(double radians)
    {
        return radians * 180 / System.Math.PI;
    }

    public static double ToBearing(double radians)
    {
        // convert radians to degrees (as bearing: 0...360)
        return (ToDegrees(radians) + 360) % 360;
    }


    public void Start()
    {
        Debug.Log(Bearing(39.099912, -94.581213, 38.627089, -90.200203));
    }
    public void Update()
    {
        double bear = Bearing(39.099912, -94.581213, Input.location.lastData.latitude, Input.location.lastData.longitude);
        double head = Input.compass.magneticHeading;
        double diff = ((bear+360) - head)% 360;
        if (diff <= 30 && diff >= 0 || diff >=360 && diff <=330)
        {
            Vector3 direct = new Vector3(0, 0, 0);
            if(!(arrow.transform.eulerAngles.z == 0))
            {
                arrow.transform.eulerAngles = direct;
            }
        }
        if (diff > 30 && diff <= 60)
        {
            Vector3 direct = new Vector3(0, 0, -45);
            if (!(arrow.transform.eulerAngles.z == 45))
            {
                arrow.transform.eulerAngles = direct;
            }
        }
        if (diff > 60 && diff <= 120)
        {
            Vector3 direct = new Vector3(0, 0, -90);
            if (!(arrow.transform.eulerAngles.z == 90))
            {
                arrow.transform.eulerAngles = direct;
            }
        }
        if (diff > 120 && diff <= 150)
        {
            Vector3 direct = new Vector3(0, 0, -135);
            if (!(arrow.transform.eulerAngles.z == 135))
            {
                arrow.transform.eulerAngles = direct;
            }
        }
        if (diff > 150 && diff <= 210)
        {
            Vector3 direct = new Vector3(0, 0, -180);
            if (!(arrow.transform.eulerAngles.z == 180))
            {
                arrow.transform.eulerAngles = direct;
            }
        }
        if (diff > 210 && diff <= 240)
        {
            Vector3 direct = new Vector3(0, 0, -225);
            if (!(arrow.transform.eulerAngles.z == 225))
            {
                arrow.transform.eulerAngles = direct;
            }
        }
        if (diff > 240 && diff <= 300)
        {
            Vector3 direct = new Vector3(0, 0, -270);
            if (!(arrow.transform.eulerAngles.z == 270))
            {
                arrow.transform.eulerAngles = direct;
            }
        }
        if (diff > 300 && diff < 330)
        {
            Vector3 direct = new Vector3(0, 0, -315);
            if (!(arrow.transform.eulerAngles.z == 315))
            {
                arrow.transform.eulerAngles = direct;
            }
        }
    }
}
