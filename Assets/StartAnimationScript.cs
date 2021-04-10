using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class StartAnimationScript : MonoBehaviour, IInputClickHandler
{

    [Tooltip("The Name of the animation to play on start")]
    public string animationName = "";

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("StartAnimationScript OnInputClicked()");
        Debug.Log(eventData.selectedObject.name);
        GameObject obj = GameObject.Find(animationName);
        if (obj != null)
        {
            Animation animation = obj.GetComponent<Animation>();
            animation.Play();
        }
    }
}
