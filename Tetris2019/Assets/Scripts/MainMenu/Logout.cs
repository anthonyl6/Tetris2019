using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;

public class Logout : MonoBehaviour
{
    //cached references
    FirebaseAuth auth;
    FirebaseUser user;
    public void FirebaseLogout()
    {
        auth = FirebaseAuth.DefaultInstance;
        user = auth.CurrentUser;

        auth.SignOut();
        Debug.LogWarning(user.DisplayName);
    }
}
