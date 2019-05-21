using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverHeadCloser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("MoveDown"); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator MoveDown ()
	{
		while (true)
		{
			if (transform.position.y >= 7)
			{
				transform.Translate(Vector3.down * Time.deltaTime, Space.World);
				yield return new WaitForEndOfFrame();
			}else
			{
				yield return null; 
			}
			
		}
	}
}
