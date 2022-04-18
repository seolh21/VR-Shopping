using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using SimpleJSON;
using Newtonsoft.Json;

public class Cart : MonoBehaviour
{   
    public DependencyStatus dependencyStatus;    
    public DatabaseReference DBreference;
    private string user_id;
    private Dictionary<string, int>[] item_list;

    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");

        DBreference = FirebaseDatabase.DefaultInstance.RootReference;

    }
    // Start is called before the first frame update
    
    void Start()
    {
        user_id = "user1";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Event");

        if (other.tag == "Item") {
            
            var item_name = other.gameObject.GetComponent<Item>().name;
            var item_price = other.gameObject.GetComponent<Item>().price;
            var item_count = other.gameObject.GetComponent<Item>().count;

            var DBTask = DBreference.Child("user").Child(this.user_id).Child("cart")
            .GetValueAsync()
            .ContinueWith(task => {
                if (task.IsFaulted) {
                    print("ERROR");
                }
                else if (task.IsCompleted) {
                DataSnapshot snapshot = task.Result;
                    if(snapshot.HasChild(item_name))
                    {
                        var count = int.Parse(snapshot.Child(item_name).Child("count").Value.ToString()) + item_count;

                        DBreference.Child("user").Child(this.user_id).Child("cart").Child(item_name).Child("count").SetValueAsync(count);

                        print(count);
                    }
                    else
                    {
                        var dict_entry =  new Dictionary<string, float>
                        {
                            {"price", item_price},
                            {"count", item_count}
                        };

                        string upload_json = JsonConvert.SerializeObject(dict_entry);
                        print(upload_json);
                        var uploadTask = DBreference.Child("user").Child(this.user_id).Child("cart").Child(item_name).SetRawJsonValueAsync(upload_json);
                        if (uploadTask.Exception != null)
                        {
                            Debug.LogWarning(message: $"Failed to register task with {uploadTask.Exception}");
                        }
                    }
                }
            });

            if (DBTask.Exception != null)
            {
                Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit Event");

        if (other.tag == "Item") {
            
            var item_name = other.gameObject.GetComponent<Item>().name;
            var item_price = other.gameObject.GetComponent<Item>().price;
            var item_count = other.gameObject.GetComponent<Item>().count;

            var DBTask = DBreference.Child("user").Child(this.user_id).Child("cart")
            .GetValueAsync()
            .ContinueWith(task => {
                if (task.IsFaulted) {
                    print("ERROR");
                }
                else if (task.IsCompleted) {
                DataSnapshot snapshot = task.Result;
                    if(snapshot.HasChild(item_name))
                    {
                        var count = int.Parse(snapshot.Child(item_name).Child("count").Value.ToString()) - item_count;
                        if(count > 0)
                            DBreference.Child("user").Child(this.user_id).Child("cart").Child(item_name).Child("count").SetValueAsync(count);
                        else
                            DBreference.Child("user").Child(this.user_id).Child("cart").Child(item_name).SetValueAsync(null);

                        print(count);
                    }
                }
            });

            if (DBTask.Exception != null)
            {
                Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
            }
        }


    }

}
