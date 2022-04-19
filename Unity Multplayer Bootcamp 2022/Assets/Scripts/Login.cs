using System;
using PlayerIOClient;
using Project.Network;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_InputField password;

    [SerializeField] private Button registerButton;
    [SerializeField] private Button loginButton;

    private void Awake()
    {
        registerButton.onClick.AddListener(OnClickRegisterUser);
        loginButton.onClick.AddListener(OnClickLogin);
    }

    private void OnClickRegisterUser()
    {
        NetworkClient.RegisterUser(username.text, password.text);
    }

    private void OnClickLogin()
    {
        NetworkClient.LoginUser(username.text, password.text);
    }

    
}