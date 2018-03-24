using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour {

    private float vertical;
    private float horizontal;
    private float speed = 20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        horizontal = Input.GetAxis("Horizontal") * speed *  Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
        {

            transform.Translate(0, vertical + speed * Time.deltaTime, 0);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {

            transform.Translate(0, vertical - speed * Time.deltaTime, 0);

        }


        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.Rotate(0, 0, horizontal - 4f);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Rotate(0, 0, horizontal + 4f);


        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Enemy")
        {

            SceneManager.LoadScene("Hide");


        }

    }
}
