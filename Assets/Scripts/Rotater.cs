using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour
{


	
	// Update is called once per frame, not using physics so don't have to use fixed update
	void Update ()
	{
		
		//spin by rotate transform every frame (the 45 45 45), dont want to set transform rotation but rotate transform
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime); //action needs be smooth/frame rate indep, so multiply frame rate value by change in time
		//prefab is an asset that contains a template or blueprint of gameobject or object family. created from existing gameobject
		//updates with all changes when cahnge 1 prefab
	}
}
