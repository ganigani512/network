using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour {
    string adress = "http://";
    string receive_adress;
    string send_adress;
    string login_adress;
    string logincount_adress;
    public string ip = "10.22.2.29:10080";
    public string dir = "/gp17op17/networktest/";

    public string message;
    public string username;
    public List<string> messages = new List<string>();
    public Queue<string> str = new Queue<string>();

    public string num;


    //public string[] message_list;
    public string[] loginmember_list;
    public RectTransform rect;
    public Text receive_text;

    public bool loginflag = false;
    

    private void OnDestroy()
    {
        if (!loginflag)
            return;
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        WWW _send = new WWW(login_adress, form);
        Debug.Log("ちゃんとログアウトしといたよ？");

    }

    //int[] array; 
    // Use this for initialization
    void Start() {
        adress += ip;  //ipアドレスとポート番号
        adress += dir; //ディレクトリ    
       
        //-----------ファイル名-------------------------
        send_adress = adress + "NetworkServerSend.php";       
        receive_adress = adress + "NetworkServerReceive.php";
        login_adress = adress + "loginfo.php";
        logincount_adress = adress + "Loginmember.php";
        //-----------------------------------------------

  

    }

    public void message_send(string str)
    {
        StartCoroutine(cliant_send(str,username));
    }


    
    IEnumerator cliant_send(string str_message,string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("Message", str_message);
        form.AddField("username", name);

        //DESKTOP - 64RHGVB
        WWW _send = new WWW(receive_adress, form);

        yield return _send;



        Debug.Log("send : " + _send.text);
    }

    public void message_receive()
    {
        StartCoroutine(cliant_receive());
    }

    IEnumerator cliant_receive()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            int size = receive_text.text.Length;

           
           
            WWW www = new WWW(send_adress);
            yield return www;
            //if (www == null)
            //{
            //    Debug.Log("接続失敗");
            //}

            message = www.text;
            //// カンマ区切りで分割して配列に格納する

            //Debug.Log("チャット用："+www.text);
    

            //message_list = message.Split(',');

            
            ////awsを使うといい

            //for (int i = 0; i < message_list.Length; i++)
            //{
            //    Debug.Log(i + "番:'" + message_list[i] + "'");
            //}


            //if (message_list.Length > 1)
            //{
            //    for (int i = 0; i < message_list.Length; i += 3)
            //    {
            //        receive_text.text += " ";
            //        receive_text.text += message_list[i + 1];
            //        receive_text.text += " : ";
            //        receive_text.text += message_list[i + 2];
            //        receive_text.text += "\n";
            //    }
                
            //}


        }

    }

    public void login_send()
    {
        StartCoroutine(login());
    }

    IEnumerator login()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("login", "false");

        WWW _send = new WWW(login_adress, form);
        yield return _send;
        loginflag = true;
        Debug.Log(_send.text);

    }

    public void membercount()
    {
        StartCoroutine(loginmember());
    }

    IEnumerator loginmember()
    {
        while (true)
        {
            WWW _send = new WWW(logincount_adress);
            yield return _send;

            Debug.Log("ログイン："+_send.text);

            loginmember_list = _send.text.Split(',');
            yield return new WaitForSeconds(5.0f);
        }

    }


    public void logout_send()
    {
        StartCoroutine(logout());
    }

    IEnumerator logout()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        WWW _send = new WWW(login_adress,form);

        yield return _send;

        Debug.Log(_send.text);

        yield return new WaitForSeconds(1.0f);

        Application.Quit();

        yield return null;

    }


    // Update is called once per frame
    void Update () {
        
    }


    
}
