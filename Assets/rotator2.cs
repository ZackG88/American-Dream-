using UnityEngine;
using System.Collections;

public class rotator2 : MonoBehaviour {


	void Update () 
	{
		transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime);
	}
}	