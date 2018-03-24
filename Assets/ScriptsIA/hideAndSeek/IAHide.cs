using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAHide : MonoBehaviour
{

    public Transform inimigo;
    private float moveSpeed = 30f;
    private float distMinima = 2f;
    private float distMaxima = 20f;
    private float novaVel = 10f;
    private bool isPerto = false;
    private bool perdi = true;
    private Vector3 previsao;
    private Vector3 tpPoint;
    private RaycastHit hit;
    private RaycastHit parede;
    private float xis;
    private float ipsilon;
    private float tempoRest = 4f;

    // Use this for initialization
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {


        isPerto = achei();
        

        if(isPerto == true)
        {

            transform.LookAt(inimigo.position);
            perdi = false;

        }else
        {

            perdi = true;

        }
        
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, 30)){
        

            if(hit.transform.tag == "Untagged" && perdi == true)
            {
                
                transform.Rotate(Random.Range(-15,30), 0, 0);

            }

        }
        
        if (Vector3.Distance(transform.position, inimigo.position) >= distMinima)
        {

            transform.position += transform.forward * moveSpeed * Time.deltaTime;

           


        }

        

    }

    private bool achei()
    {
        bool mira = false;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        
        if(Physics.SphereCast(transform.position, 2f, fwd, out hit))
        {



            if (hit.transform.tag != "Untagged")
            {

                mira = true;
                

            }
           
            


        }

        return mira;
    }


    


}
