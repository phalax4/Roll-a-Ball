using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public GameObject player;
	private Vector3 offset;
	//hold offest value

	// Use this for initialization
	void Start ()
	{
		offset = transform.position - player.transform.position;
	
	}
	
	// Update is called once per frame
	//void Update ()
	void LateUpdate ()
	{
		
		transform.position = player.transform.position + offset; //move player, each frame before display camera can see, move camera new pos aligned with player object
		//update not best place for this as follow cameras, procedural animation, last known states use
		//LateUpdate - guranteed to run after all items processed in update, so we know absolutly player has moved for that frame
	}
}
