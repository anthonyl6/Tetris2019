using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Auth;

public class SceneLoader : MonoBehaviour
{
    //cached references
    static int n;
    int y;
    FirebaseAuth auth;
    FirebaseUser user;

    void Start()
    {
        DontDestroyOnLoad(this);
    }
  
    public void LoadNextScene()
    {
        auth = FirebaseAuth.DefaultInstance;
        user = auth.CurrentUser;
        int y = SceneManager.GetActiveScene().buildIndex;

        if(y == 1) {
            if(user.DisplayName != "") {
                SceneManager.LoadScene(n);
                n++;
            } else {
                Debug.Log("Error: Please enter a username low iq.");
            }
        } else {
            SceneManager.LoadScene(n);
            n++;
        } 
    }
}
