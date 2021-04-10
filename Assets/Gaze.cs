using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour {

    private static double startOffsetSeconds = 3f;
    private static double eps = 0.3f;

    private float currentScale = 1f;

    private List<GameObject> scaledObjects = new List<GameObject>();

    // Mapping from Collider to Object

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void LateUpdate()
    {

        if (Time.time < startOffsetSeconds) return;

        RaycastHit hitInfo;
        if (Physics.Raycast(
                Camera.main.transform.position,
                Camera.main.transform.forward,
                out hitInfo,
                20.0f,
                Physics.DefaultRaycastLayers))
        {
            // If the Raycast has succeeded and hit a hologram
            // hitInfo's point represents the position being gazed at
            // hitInfo's collider GameObject represents the hologram being gazed at

            Debug.Log("Gazing at:" + hitInfo.collider.name + " " + Time.time);

            if (hitInfo.collider.gameObject.name.StartsWith("Maske"))
            {
                GameObject mask = hitInfo.collider.gameObject;

                ScaleAnimated(mask, 4.0f);
                //mask.GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Diffuse");
            }
            else {
                // Gazing at non-active object with collider
                ResetScaledObjects();
            }
        }
        else
        {
            // No collider hit
            ResetScaledObjects();
        }
    }

    void ScaleAnimated(GameObject obj, float endScale)
    {
        //float currentScale = obj.transform.localScale.x;

        if (!scaledObjects.Contains(obj))
        {
            scaledObjects.Add(obj);
        }

        float newScale = currentScale;

        if( currentScale < endScale - eps)
        {
            newScale += 15f * Time.deltaTime; 
        }
        else if( currentScale > endScale + eps)
        {
            newScale -= 15f * Time.deltaTime;
        }

        currentScale = newScale;
        obj.transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    void ResetScaledObjects()
    {
        foreach( GameObject obj in scaledObjects)
        {
            obj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        scaledObjects.Clear();
        currentScale = 1.0f;
    }

    void ResetStateOf(string objects, string exclude = "")
    {
        GameObject mask = GameObject.Find("Face_LR1_2");
        ScaleAnimated(mask, 1f);

        //mask.transform.localScale = new Vector3(1f, 1f, 1f);
        mask.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
        //Behaviour b = (Behaviour)mask.GetComponent("Halo");
        //b.enabled = false;
    }
    
}
