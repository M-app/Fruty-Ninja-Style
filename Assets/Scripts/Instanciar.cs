using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class Instanciar : MonoBehaviour {

    public Slider slider;  // life slider 
    public float minSpawnTime; // minimum time to shoot objects
    public float maxSpawnTime; // maximum time to shoot objects
    public float spawnItem; 

    public GameObject[] Items; // Array of meal 
    private GameObject item;

    private int index;

    public float upForce = 400f; // force 
    public float leftForce = 200f; // left force 
    public static float minX, maxX;
	// Use this for initialization
	void Start () {
        minX = GerenciarCamara.MinX();
        maxX = GerenciarCamara.MaxX();
        StartCoroutine("Instanciador");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    bool RandomItem()
    {
        if(Items.Length > 0)
        {
            index = Random.Range(0, Items.Length); // instantiate objects see array.length
            return true; 
        }
        return false; 
    }

    private IEnumerator Instanciador()
    {
        spawnItem = Random.Range(minSpawnTime, maxSpawnTime);
        yield return new WaitForSeconds(spawnItem);

        if (slider.value > 0) //when you lose objects stop firing
        {
            if (RandomItem()) // if array is not void 
            {
                item = Instantiate(Items[index], new Vector2(Random.Range(-5, 5), transform.position.y), Quaternion.Euler(0, 0, Random.Range(-60, 60))) as GameObject;

                if (item.transform.position.x > 0) // if you shoot right
                {
                    item.rigidbody2D.AddForce(new Vector2(-leftForce, upForce));
                }
                else
                {
                    item.rigidbody2D.AddForce(new Vector2(leftForce, upForce));
                }

                StartCoroutine("Instanciador");
            }
        }
    }

    

   
}
