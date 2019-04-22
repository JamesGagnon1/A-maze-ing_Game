using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	float PlaceX;
	float PlaceY;
	public float MoveSpeed;
	float ActlMoveSpeed;
	public GameObject WinScreen;
	public GameObject GameScreen;
	void Start () {
		
	}
	

	void Update () {
		PlaceX = (this.gameObject.transform.position.x);
		PlaceY = (this.gameObject.transform.position.y);

		if (gameObject.tag == "P1") {

			if (Input.GetKey (KeyCode.W)) {
				transform.position += new Vector3(0, ActlMoveSpeed, 0);
			}
			if (Input.GetKey (KeyCode.S)) {
				transform.position += new Vector3(0, -ActlMoveSpeed, 0);
			}
			if (Input.GetKey (KeyCode.A)) {
				transform.position += new Vector3(-ActlMoveSpeed, 0, 0);
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.position += new Vector3(ActlMoveSpeed, 0, 0);
			}
		} else if (gameObject.tag == "P2") {

			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.position += new Vector3(0, ActlMoveSpeed, 0);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.position += new Vector3(0, -ActlMoveSpeed, 0);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.position += new Vector3(-ActlMoveSpeed, 0, 0);
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.position += new Vector3(ActlMoveSpeed, 0, 0);
			}
		}
	}

	void LateUpdate () {

		if (PlaceX != this.gameObject.transform.position.x) {
			if (PlaceY != this.gameObject.transform.position.y) {
				ActlMoveSpeed = (Mathf.Sqrt (Mathf.Pow(MoveSpeed, 2) * 2) / 2);
				if (PlaceX < this.gameObject.transform.position.x) {
					if (PlaceY < this.gameObject.transform.position.y){
						this.gameObject.transform.rotation = Quaternion.Euler(0,0,-45);  //up right
					} else {
						this.gameObject.transform.rotation = Quaternion.Euler(0,0,-135);//down right
					}
				} else {
					if (PlaceY < this.gameObject.transform.position.y){
						this.gameObject.transform.rotation = Quaternion.Euler(0,0,45);//up left
					} else {
						this.gameObject.transform.rotation = Quaternion.Euler(0,0,135);//down left
					}
				}
			} else {
				ActlMoveSpeed = MoveSpeed;
				if (PlaceX < this.gameObject.transform.position.x) {
					this.gameObject.transform.rotation = Quaternion.Euler(0,0,-90);//right
				} else {
					this.gameObject.transform.rotation = Quaternion.Euler(0,0,90);//left
				}
			}
		} else {
			ActlMoveSpeed = MoveSpeed;
			if (PlaceY != this.gameObject.transform.position.y) {
				if (PlaceY < this.gameObject.transform.position.y){
					this.gameObject.transform.rotation = Quaternion.Euler(0,0,-0);//up
				} else {
					this.gameObject.transform.rotation = Quaternion.Euler(0,0,180);//down
				}
			}
		}
	}

	void OnCollisionEnter2D (Collision2D Hit) { 
		if (Hit.gameObject.tag == "P1" || Hit.gameObject.tag == "P2") {
			GameScreen.SetActive(false);
			WinScreen.SetActive(true);
		}
	}
}
