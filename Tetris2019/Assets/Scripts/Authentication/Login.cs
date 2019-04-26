using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

public class Login : MonoBehaviour
{

    [SerializeField] InputField email;
    [SerializeField] InputField password;

    //cached references
    FirebaseAuth auth;

    void Start()
    {
        //firebase authentication
        auth = FirebaseAuth.DefaultInstance;
    }

    public void signIn()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            if(task.IsCanceled) {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled");
                return;
            }
            if(task.IsFaulted) {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            //display displayname
            FirebaseUser user = auth.CurrentUser;
            Debug.Log(user.DisplayName);
        });
    }
}
