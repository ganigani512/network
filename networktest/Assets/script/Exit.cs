using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

    Chat chat;

	// Use this for initialization
	void Start () {
        chat = GetComponent<Chat>();
    }
	
    void aaaa()
    {
        StartCoroutine(logout());
    }

    IEnumerator logout()
    {
        chat.logout_send();

        yield return new WaitForSeconds(2.0f);
        Debug.Log("ログアウト完了");

        Application.Quit();
    }

    
}
