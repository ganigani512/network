using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Main_Player : MonoBehaviour {
    public GameObject mycharactor;

    GameObject obj;
        
	// Use this for initialization
	void Start () {
        obj = Instantiate(mycharactor);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
