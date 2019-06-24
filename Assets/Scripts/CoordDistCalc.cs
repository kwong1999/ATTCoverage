﻿using UnityEngine;
using UnityEditor;
using System;
public class CoordDistCalc : MonoBehaviour
{
    public const double EarthRadiusInMiles = 3956.0;
    public const double EarthRadiusInKilometers = 6367.0;
    public const double EarthRadiusInMetres = 6371000;
    
    public static double ToRadian(double val) { return val * (Math.PI / 180); }
    public static double DiffRadian(double val1, double val2) { return ToRadian(val2) - ToRadian(val1); }

    public static double CalcDistance(double lat1, double lng1, double lat2, double lng2)
    {
        return CalcDistance(lat1, lng1, lat2, lng2, GeoCodeCalcMeasurement.Miles);
    }

    public static double CalcDistance(double lat1, double lng1, double lat2, double lng2, GeoCodeCalcMeasurement m)
    {
        double radius = CoordDistCalc.EarthRadiusInMiles;

        if (m == GeoCodeCalcMeasurement.Kilometers) { radius = CoordDistCalc.EarthRadiusInKilometers; }
        if (m == GeoCodeCalcMeasurement.Metre) { radius = CoordDistCalc.EarthRadiusInMetres; }
        return radius * 2 * Math.Asin(Math.Min(1, Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2)) / 2.0), 2.0) + Math.Cos(ToRadian(lat1)) * Math.Cos(ToRadian(lat2)) * Math.Pow(Math.Sin((DiffRadian(lng1, lng2)) / 2.0), 2.0)))));
    }
}

public enum GeoCodeCalcMeasurement : int
{
    Miles = 0,
    Kilometers = 1,
    Metre = 2
}

