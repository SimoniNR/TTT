using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour
{
    [SerializeField]
    int _maxUsernameInput = 10;
    [SerializeField]   
    int _maxPasswordInput = 10;
    
    private Transform _loginButton;
    private TextMeshProUGUI _loginText;
    private TMP_InputField _usernameInput;
    private TMP_InputField _passwordInput;

    private string _username = string.Empty;
    private string _password = string.Empty;

    private void Start()
    {
        _loginButton = transform.Find("LoginBtn");
        _loginButton.GetComponent<Button>().onClick.AddListener(Login);

        _loginText = _loginButton.transform.Find("Text").GetComponent<TextMeshProUGUI>();

        _usernameInput = transform.Find("UsernameInput").GetComponent<TMP_InputField>();
        _usernameInput.onValueChanged.AddListener(UpdateUsername);

        _passwordInput = transform.Find("PasswordInput").GetComponent<TMP_InputField>();
        _passwordInput.onValueChanged.AddListener(UpdatePassword);
    }

    private void UpdatePassword(string value)
    {
        _password = value;
        //Debug.Log($"Password value = {value}");
        ValidateAndUpdateUI();
    }

    private void UpdateUsername(string value)
    {
       _username = value;
        //Debug.Log($"Username value = {value}");
    }

    private void ValidateAndUpdateUI()
    {
        var usernameRegex = Regex.Match(_username, "^[a-zA-Z0-9]+$");

        var interactable = 
            (!string.IsNullOrWhiteSpace(_username) && 
            !string.IsNullOrWhiteSpace(_password)) &&
            (_username.Length <= _maxUsernameInput && _password.Length <= _maxPasswordInput) && 
            usernameRegex.Success;

        EnableLoginButton(interactable);
        
    }
    private void EnableLoginButton(bool interactable)
    {
        _loginButton.GetComponent<Button>().interactable = interactable;
       
        var color = _loginButton.GetComponent<Button>().interactable ? Color.white : Color.gray;
        _loginText.color = color;

    }

    private void Login()
    {
        Debug.Log("Logging in");
    }

   
}
