﻿using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {
	float lockPos = 0;
	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;
	//public Rigidbody characterPos;
	private float[] platformWidths;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public int platformSelector;
	public ObjectPooler[] theObjectPools;

	private float minHeight;
	private float maxHeight;
	public Transform maxHeightPoint;

	public float maxHeightChange;
	private float heightChange;

	// Use this for initialization
	void Start () {
		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;

		platformWidths = new float[theObjectPools.Length];


		for (int i = 0; i < theObjectPools.Length; ++i) {
			platformWidths [i] = theObjectPools [i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x < generationPoint.position.x){
			


			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
			platformSelector = Random.Range (0, theObjectPools.Length);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			transform.position = new Vector2 (transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, heightChange);


			//Instantiate (thePlatform, transform.position, transform.rotation);
			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			transform.position = new Vector2 (transform.position.x + (platformWidths[platformSelector]/2), transform.position.y);


	}
}
}