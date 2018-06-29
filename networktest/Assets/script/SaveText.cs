using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SaveText : MonoBehaviour {

    string str;
    //[SerializeField]
    public InputField inputField;
    public GameObject obj;
    Chat chat_text;

    public Text text;

    private void Start()
    {
       
        chat_text = obj.GetComponent<Chat>();
    }


    public void _SaveText()
    {

        str = inputField.text;

        

        chat_text.message_send(str);
        

        inputField.text = "";

    }
}
