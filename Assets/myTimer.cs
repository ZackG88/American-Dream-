using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class myTimer : MonoBehaviour {
	
	public int timeLeft = 60; //Seconds Overall
	public Text textTimer; //UI Text Object

	void Start () {
		StartCoroutine("LoseTime");
		Time.timeScale = 1; 
	}

	void Update () {
		textTimer.text = ("" + timeLeft); //Showing the Score on the Canvas
	}

	IEnumerator LoseTime()
	{
		while (true) {
			yield return new WaitForSeconds (1);
			timeLeft--; 
		}

	}}