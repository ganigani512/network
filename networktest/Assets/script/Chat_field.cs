using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chat_field : MonoBehaviour {

    [SerializeField]
    public Chat chat;
    public  Text chat_field;

    public string[] message_list;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update() {
        if (chat.loginflag)
        {


            chat_field.text = "";


            message_list = chat.message.Split(',');


            //awsを使うといい

            for (int i = 0; i < message_list.Length; i++)
            {
                Debug.Log(i + "番:'" + message_list[i] + "'");
            }


            if (message_list.Length > 1)
            {
                for (int i = 0; i < message_list.Length; i += 3)
                {
                    chat_field.text += " ";
                    chat_field.text += message_list[i + 1];
                    chat_field.text += " : ";
                    chat_field.text += message_list[i + 2];
                    chat_field.text += "\n";
                }

            }

        }
    }
}
