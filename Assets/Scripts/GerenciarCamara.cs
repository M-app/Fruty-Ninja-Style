using UnityEngine;
using System.Collections;

public class GerenciarCamara : MonoBehaviour {

    public Camera camera;
    private static float minX;
    private static float maxX;
    private static float minY;
    private static float maxY;

    private float distanciaZ; 
    
    // Use this for initialization
	void Start () {
        distanciaZ = transform.position.z - camera.transform.position.z; // distance came to screen
        minX = camera.ScreenToWorldPoint (new Vector3 (0, 0, distanciaZ)).x; 
        maxX = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, distanciaZ)).x;
        minY = camera.ScreenToWorldPoint(new Vector3(0, 0, distanciaZ)).y;
        maxY = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, distanciaZ)).y;
	}
	
	// Update is called once per frame
	public static float MinX()
    {
        return minX; 
    }
    public static float MaxX()
    {
        return maxX;
    }
    public static float MinY()
    {
        return minY; 
    }
    public static float MaxY()
    {
        return maxY; 
    }
}
