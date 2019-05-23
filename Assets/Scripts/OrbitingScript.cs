using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingScript : MonoBehaviour
{
	public int MultiplierRight;
	public int MultiplierUp;
	float SPDIncreas = 0;
	float TimeMultiplier;

	// Use this for initialization
	void Start()
	{
		MultiplierRight = Random.Range(1, 3);
		MultiplierUp = Random.Range(1, 3);
		TimeMultiplier = Random.Range(0.2f, 1f);
	}

	// Update is called once per frame
	void Update()
	{
		transform.RotateAround(Vector3.forward, Vector3.up, TimeMultiplier * Time.deltaTime);
		transform.Rotate(Vector3.right, MultiplierRight * Time.deltaTime);
		transform.Rotate(Vector3.up, MultiplierUp * Time.deltaTime);


		SPDIncreas += Time.deltaTime;
		if (SPDIncreas >= 40)
		{

			MultiplierRight = Random.Range(3, 20);
			MultiplierUp = Random.Range(3, 20);
			TimeMultiplier = Random.Range(0.5f, 5);
			SPDIncreas = 0;
			return;
		}


	}
	IEnumerator SpeedIncrease()
	{





		yield return null;
	}

}
