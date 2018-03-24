using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour {


    public Transform cp1;
    public Transform cp2;
    public Transform cp3;
    public Transform cp4;
    public Transform cp5;
    public Transform cp6;
    public Transform barcoIni;
    private int Controle = 0;
    private Transform novaP;
    private float moveSpeed = 2f;
    private float distMinima = 0.1f;
    private float distMaxima = 0.3f;


    // Use this for initialization
    void Start () {

        getTransform(0);

    }
	
	// Update is called once per frame
	void Update () {



        Vector3 dir = novaP.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 75);
        

        if (Vector3.Distance(transform.position, barcoIni.position) <= 1.5f)
        {


            transform.position = Vector2.MoveTowards(transform.position, barcoIni.transform.position, 0f);

        }


        else
        {

            if (Vector3.Distance(transform.position, novaP.position) >= distMinima)
            {

                transform.position = Vector2.MoveTowards(transform.position, novaP.position, moveSpeed * Time.deltaTime);



                if (Vector3.Distance(transform.position, novaP.position) <= distMaxima)
                {
                    if (Controle < 6)
                    {
                        getTransform(Controle++);
                    }
                    else
                    {

                        Controle = 0;
                    }
                }

            }

        }

    }

    private Transform getTransform(int i)
    {

        switch (i){

            case 0:

                novaP = cp1;

                break;

            case 1:

                novaP = cp2;
            break;

            case 2:

                novaP = cp3;
                break;

            case 3:


                novaP = cp4;

                break;

            case 4:

                novaP = cp5;

                break;

            case 5:

                novaP = cp6;

                break;

            
        }
        

        return novaP;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider != null) { 
        avoidObs(collision.collider.tag);
        }
        

    }

    private void avoidObs(string s)
    {

        Debug.Log(s);

        switch (s)
        {

            case "Player":


                transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 0f);
                
                break;

            case "Finish":

                transform.position = Vector2.MoveTowards(transform.position, Vector2.Reflect(transform.position - novaP.position, (GameObject.FindGameObjectWithTag("Finish").transform.position).normalized), moveSpeed * Time.deltaTime);
                break;

        }


    }

}
