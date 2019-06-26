using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using Firebase.Extensions;
public class FBTest : MonoBehaviour
{
    FirebaseApp app;
    // Start is called before the first frame update
    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //   app = Firebase.FirebaseApp.DefaultInstance;
                app = Firebase.FirebaseApp.DefaultInstance;
                app.SetEditorDatabaseUrl("https://newprojectforwork.firebaseio.com/");
                DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
                // Set a flag here to indicate whether Firebase is ready to use by your app.
                Debug.Log("Hello World, this may not work....");
                printData();

            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                Debug.Log(System.String.Format(
                                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

        printData();
    }

    // Update is called once per frame
    void Update()
    {
        printData();
        
    }
    private void printData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("newCollection").Child("United States").Child("Washington").Child("King County").Child("Bothell")
            .Child("98011").Child("North Creek Parkway").Child("0").Child("Bars").GetValueAsync().ContinueWith(task => {
                if (task.IsFaulted)
                {
                    // Handle the error...
                    Debug.Log("ERROR Loading data");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    Debug.Log("Success?>?>?>?");
                    Debug.Log(snapshot.GetRawJsonValue());

                    // Do something with snapshot...
                }
            });


    }
}
