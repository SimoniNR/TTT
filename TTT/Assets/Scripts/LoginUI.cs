using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour
{
   private Button _loginButton;
   private Button _sendButton;

   private void Start()
   {
      _loginButton = transform.Find("Connect").GetComponent<Button>();
      _loginButton.onClick.AddListener(Connect);

      _sendButton = transform.Find("Send").GetComponent<Button>();
      _sendButton.onClick.AddListener(Send);
   }

   private void Connect()
   {
      //Debug.Log("Connecting to the Server!");
      NetworkClient.Instance.Connect();
   }

   private void Send()
   {
      //Debug.Log("Sending message to the server!");
      NetworkClient.Instance.SendServer("Hello there!");
   }
}
