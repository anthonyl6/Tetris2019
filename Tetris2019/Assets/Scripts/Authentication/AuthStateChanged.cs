using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;

public class AuthStateChanged : MonoBehaviour
{

    //Panel
    [SerializeField] GameObject displayNameGroup;
    [SerializeField] InputField displayNameInputField;

    //caches references
    FirebaseAuth auth;
    FirebaseUser user;
    string displayName;
    string emailAddress;


    
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
                
            }
            user = auth.CurrentUser;
            if(signedIn) {
                Debug.Log("Signed in " + user.UserId);
                displayName = user.DisplayName ?? "";
                emailAddress = user.Email ?? "";
            
                if(displayName == ""){
                    displayNameGroup.SetActive(true);
                } else {
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }

    public void DisplayNameChange()
    {

        if(user != null)
        {
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile {
                DisplayName = displayNameInputField.text
            };
            user.UpdateUserProfileAsync(profile).ContinueWith(task => {
                if(task.IsCanceled) {
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if(task.IsFaulted) {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }
                
                Debug.Log("User profile updated successfully.");
                Debug.Log(user.DisplayName);
            });
        }
    }
}
