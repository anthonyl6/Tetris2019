using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    //input field variables
    [SerializeField] InputField email;
    [SerializeField] InputField password;

    //check variables
    bool EC = false;
    bool PC = false;
    public void buttonPress()
    {
        IsValidEmail();
        passwordCheck();
        if(EC && PC)
        {
            databaseRegister();
        }
    }

    bool IsValidEmail()
    {
        try 
        {
            var check = new System.Net.Mail.MailAddress(email.text);
            Debug.Log("Email is valid.");
            EC = true;
            return check.Address == email.text;
        }
        catch 
        {
            Debug.Log("Email is not valid.");
            return false;
        }

    }

    void passwordCheck()
    {
        if(password.text.Length < 8)
        {
            Debug.Log("Password must be longer than 8 characters.");
        }
        else
        {
            PC = true;
        }
    }

    void databaseRegister()
    {

        




        Debug.Log("Registered");
    }
}
