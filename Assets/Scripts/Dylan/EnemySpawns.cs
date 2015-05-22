using UnityEngine;
using System.Collections;

public class EnemySpawns : MonoBehaviour 
{
    public  GameObject[] enemy;
    public int numSpawms = 3;
    public bool spawn = false;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "player")
        {
            spawn = true;  
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "player")
        {
            spawn = false;
        }
    }

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () 
    {
        if (spawn == true)
        {
            for (int i = 1; i < numSpawms; i++)
            {
                if (i <= numSpawms)
                {
                    Vector3 push = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));

                    switch (i % 3)
                    {
                        case 1: push.x += Random.Range(-3.0f, 3.0f); break;
                        case 2: push.z += Random.Range(-3.0f, 3.0f); break;
                    }

                    push.Normalize();

                    push *= Random.Range(.7f * i, i * 2.3f);


                    Instantiate(enemy[i], transform.position + push, transform.rotation);
                    print("I spawned");
                }
            }
        }
        //spawn = false;
    }
}
