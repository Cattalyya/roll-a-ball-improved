using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


	public float speed;
	public Text countText;
	public Text winText;
	public GameObject trace;

	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);

		if(Time.time%2==0){
			Instantiate (trace, transform.position-5*movement, transform.rotation);
		}



	}




	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
		
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("Trace")) {

			other.gameObject.SetActive (false);
			count = count - 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count:" + count.ToString ();
		if(count >= 7)
		{
			winText.text="You win!!";

		}
	}
}

