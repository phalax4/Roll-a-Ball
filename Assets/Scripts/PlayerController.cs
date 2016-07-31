using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	//We want to check every frame for player input, apply input to every frame as movement

	//Called before rendering every frame, game code goes here
	//void Update ()
	//{
	//}

	//hold reference to UI text game obj
	public Text countText;
	public  float speed;
	public Text winText;

	private int count;
	private Rigidbody rb;

	//public so shows up in inspector as editable property

	//called on first frame script is active, often first frame of the game
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	//move ball by applying force to rigibody so use physics
	//done before any physics calculation, this is where physics will go
	void FixedUpdate ()
	{
		//input from horizonatal and vertical axes controlled by keys
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical); //x,y,z
		//add force to rigidbody (player) by input to move
		rb.AddForce (movement * speed);
	}

	//collider with no physics
	//called when playerobject touchs a trigger collider
	void OnTriggerEnter (Collider other)
	{
		//Destroy (other.gameObject); //destroy game obj trigger is attached to, all components and their children are removed from scene
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}


	// physics engien does not allow 2 more more colliders to overlap, detect collision on frame,
	// static colliders - non moving parts (walls, floor)
	// dynamic colliders - player sphere, car
	// static geometry not affected by collision, dynamic objs will be
	// engine can allow overlap of collider volumes, still calc collider overlap and vols but not physically act on overlap
	// make colliders triggers, detect contact of trigger by OnTrigger event, trigger in doorway and player enter, minimap update play msg disovered room
	// spider drop from ceiling when walk through doorway by trigger
	// OnTrigger - change collider volumes into trigger volumes
	// Unity perf, calcs all volumes of all static colliders into a cache  - save recalc every frame
	// by rotating cubes (static colliders) - unity recalcs all static colliders again, can rotate rescale dynamic colliders without recalc
	// rigidbody and collider = dynamic, only collider = expected static
	// isKinematic - rigid body kinematic will not react with physics forces, can be animated and moved by transforms
	//good for objs with colliders ( elevators and moving platforms) and things with triggers (colletibles with animations or moved by transforms)
	// adding will make pickups go through floor due to physics and being trigger so no collide with floor
	// static colliders should not move
	// dynamic colliders can move and have rigit body
	// standard rigid bodies move by physiscs forces
	// kinematic rigit bodies move by transforms


	//UI Tool Set

}
