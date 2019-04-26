using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;

public class UserStateChange : MonoBehaviour
{


    //cached references
    FirebaseAuth auth;
    FirebaseUser user;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        InitializeFirebase();
        
    }

    void InitializeFirebase()
    {
        auth.StateChanged += AuthStateChange;
        AuthStateChange(this, null);
    }

    public void AuthStateChange(object sender, System.EventArgs eventArgs)
    {
        if(auth.CurrentUser != user) {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if(!signedIn && user != null) {
                Debug.Log("Signed out " + user.UserId);
                SceneManager.LoadScene("Login");
            }
            user = auth.CurrentUser;
            if(signedIn) {
                Debug.Log("Signed in " + user.UserId);
            }
        }
    }
}
