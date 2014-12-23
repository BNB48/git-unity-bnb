using UnityEngine;
using System.Collections;

public class Players : MonoBehaviour {
	public float speed = 6;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				rigidbody.MovePosition (transform.position + transform.forward * Time.deltaTime * speed);

				if (Input.GetButtonDown ("Fire1")) {
						GetComponent<Animator> ().SetTrigger ("JUMP");
				}

				if (Input.GetButtonDown ("Fire2")) {
						GetComponent<Animator> ().SetTrigger ("SLIDE");
				}
		}
		void OnTriggerEnter (Collider colider){

		var stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo (0);
		bool isRun = stateInfo.IsName("Base Layer.RUN00_F");

		bool isHigh = colider.CompareTag("High");
		bool isLow = colider.CompareTag("Low");
		
		bool isJump = stateInfo.IsName("Base Layer.JUMP00");
		bool isSlide = stateInfo.IsName("Base Layer.SLIDE00");

		if ( (isRun == true) ||
		    (isJump == true && isHigh == true) ||
		    (isSlide == true && isLow == true)){
						GetComponent<Animator> ().SetTrigger ("DEAD");
						speed = 0;
				}

	}
}
