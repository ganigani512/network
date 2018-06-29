using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserName_Input : MonoBehaviour {

    public string username;
    //[SerializeField]
    public InputField inputField;
    public Chat chat;
    public GameObject name_field;
    public GameObject nameinput_button;
    public Text text;

    private void Start()
    {
        
    }


    public void _SaveText()
    {

        chat.username = inputField.text;

        username = "UserName : " + inputField.text;

        text.text = username;

        inputField.text = "";

        chat.login_send();
        chat.message_receive();

        name_field.SetActive(false);
        nameinput_button.SetActive(false);
    }
}
