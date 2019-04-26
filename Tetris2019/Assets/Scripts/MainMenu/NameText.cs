using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;

public class NameText : MonoBehaviour
{

    FirebaseAuth auth;
    FirebaseUser user;
    Text text;

    // Update is called once per frame
    void Start()
    {
        text = GetComponent<Text>();
        auth = FirebaseAuth.DefaultInstance;
        user = auth.CurrentUser;

        if(user.DisplayName != "") {
            text.text = user.DisplayName;
        } else {
            text.text = "DisplayName";
        }
    }
}
