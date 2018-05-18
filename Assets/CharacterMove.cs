using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(CharacterController))]

public class CharacterMove : MonoBehaviour{
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public Text countText;
	public Text winText;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	private Animator anim;

	private int count;


	public float rotSpeed = 90;

	void Start (){
		controller = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();

		count = 0;
		SetCountText ();
		winText.text = "";
	}


	void Update (){
		if (controller.isGrounded) {
			moveDirection = new Vector3 (0, 0, Input.GetAxis ("Vertical"));
			transform.Rotate (0, Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime, 0);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;

		if (Input.GetButton ("Jump")) {
			moveDirection.y = jumpSpeed;
		}
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
		Animating ();
//		Debug.Log (moveDirection.z);
	}

	void Animating(){
		bool walking = moveDirection.z != 0f;
		anim.SetBool ("isWalking", walking);
		Debug.Log (walking);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 100;
			SetCountText ();
		}

		if (other.gameObject.CompareTag("Pick Up 2")) 
		{
			other.gameObject.SetActive (false);
			winText.text = "You Followed Your Heart! Congratulations! YOU WIN!";
		}
	}
		
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
	}
} 

