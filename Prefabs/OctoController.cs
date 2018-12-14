using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OctoController : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    private bool moving;
    public float timebetweenmove;
    private float timebetweenmovecounter;
    public float timetomove;
    private float timetomovecounter;
    private Vector3 moveDirection;
    public float waittoreload;
    private bool reloading;
    private GameObject thePlayer;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

        //timebetweenmovecounter = timebetweenmove;
        //timetomovecounter = timetomove;

        timebetweenmovecounter = Random.Range(timebetweenmove * 0.75f, timebetweenmove * 1.25f);
        timetomovecounter = Random.Range(timetomove * 0.75f, timetomove * 1.25f);
    }
	
	// Update is called once per frame
	void Update () {
		if (moving)
        {
            timetomovecounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;
            if(timetomovecounter<0f)
            { moving = false;
                //timebetweenmovecounter = timebetweenmove;
                timebetweenmovecounter = Random.Range(timebetweenmove * 0.75f, timebetweenmove * 1.25f);
            }
        }
        else
        {
            timebetweenmovecounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if (timebetweenmovecounter<0f)
            {
                moving = true;
                //timetomovecounter = timetomove;
                timetomovecounter = Random.Range(timetomove * 0.75f, timetomove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f, 1f)*moveSpeed, Random.Range(-1f, 1f)*moveSpeed, 0f);
            }
        }
        if(reloading)
        {
            waittoreload = Time.deltaTime;
            if(waittoreload<0)
            {
                thePlayer.transform.position = new Vector2(FindObjectOfType<PlayerStartPoint>().transform.position.x, FindObjectOfType<PlayerStartPoint>().transform.position.y);
                thePlayer.SetActive(true);
            }
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        /*if(other.gameObject.name=="Player")
        {
            other.gameObject.SetActive(false);
            reloading = true;
            thePlayer = other.gameObject;

        }
        */
    }
}
