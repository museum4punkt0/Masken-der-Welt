using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class GlobeClickHandler : MonoBehaviour, IInputClickHandler {

	// Use this for initialization
	void Start () {
        Debug.Log("Start()");
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData) {

        Debug.Log("OnInputClicked()");

        GameObject.Find("Audio Source").GetComponent<AudioSource>().Stop();
        GameObject.Find("Audio Source").GetComponent<AudioSource>().Play();

        GameObject.Find("AR-App-Demo-01_export").GetComponent<Animation>().Stop();
        GameObject.Find("AR-App-Demo-01_export").GetComponent<Animation>().Play();


        //Initiate.Fade("Globus Scene", Color.black, 5.0f);
    }
}
