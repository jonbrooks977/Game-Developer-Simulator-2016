using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{
	void Update () 
	{
		//Camera Movement
		if(Input.GetKey("a"))
		{
			transform.Translate(Vector3.left / 5);
		}
		if(Input.GetKey("d"))
		{
			transform.Translate(Vector3.right / 5);
		}
		if(Input.GetKey("w"))
		{
			transform.Translate(Vector3.forward / 5);
		}
		if(Input.GetKey("s"))
		{
			transform.Translate (Vector3.back / 5);
		}

		//Camera Rotation
		if(Input.GetKey("q"))
		{
			transform.Translate(Vector3.down / 5);
		}
		if(Input.GetKey("e"))
		{
			transform.Translate(Vector3.up / 5);
		}

	}
}
