using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
   
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, 500 * Time.deltaTime); // destro splash in the background
	}
}
