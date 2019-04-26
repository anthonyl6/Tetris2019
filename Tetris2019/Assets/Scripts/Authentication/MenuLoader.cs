using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Auth;

public class MenuLoader : MonoBehaviour
{
    FirebaseUser user;
    FirebaseAuth auth;
    public void LoadMenuScene()
    {
        auth = FirebaseAuth.DefaultInstance;
        user = auth.CurrentUser;
        if(user.DisplayName != "") {
            SceneManager.LoadScene("MainMenu");
        }  else {
            Debug.LogError("Error: Please enter a username.");
        }
    }
}
