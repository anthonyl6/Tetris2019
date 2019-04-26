using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
public class Register : MonoBehaviour
{
    //input field variables
    [SerializeField] InputField email;
    [SerializeField] InputField password;

    //check variables
    bool EC = false;
    bool PC = false;
    
    //cached references
    FirebaseAuth auth;
    void Start()
    {
        //firebase authentication
        auth = FirebaseAuth.DefaultInstance;
    }

    public void buttonPress()
    {
        IsValidEmail();
        passwordCheck();
        if(EC && PC) {
            databaseRegister();
        }
    }
    bool IsValidEmail()
    {
        try {
            var check = new System.Net.Mail.MailAddress(email.text);
            EC = true;
            return check.Address == email.text;
        }
        catch {
            Debug.Log("Email is not valid.");
            return false;
        }

    }

    void passwordCheck()
    {
        if(password.text.Length < 8) {
            Debug.Log("Password must be longer than 8 characters.");
        }
        else {
            PC = true;
        }
    }

    void databaseRegister()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            if(task.IsCanceled) {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if(task.IsFaulted) {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            //Firebase user has been created
            FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });

        Debug.Log("Registered");
        
    }
}
