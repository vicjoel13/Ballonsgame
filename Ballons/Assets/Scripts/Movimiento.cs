using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
   
    public GameObject disparo;
    public Transform lugardisparo;
    public float velocidad = 8f;
    public float targetTime = 50f;
    public float clockTime = 1.0f;
    public UIManager UIMgr;
    public float veldisparo;

    private float nextdisparo; 


    void Start()
    {
        InvokeRepeating("timerEnded", 10.0f, 10.0f);
        UIMgr = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        transform.position = new Vector3 (36,5,1); // aparicion nave
                                                  //Health bar is called
        HealthBarHandler.SetHealthBarValue(1);


    }

    
    private void Update()


    {

        targetTime -= Time.deltaTime;
        clockTime -= Time.deltaTime;
        if (clockTime <=0.0f)
        {
            UIMgr.AddTimer(1);
            clockTime = 1.0f;
        }

       

        //the healthbar lose life test
        
        if (HealthBarHandler.GetHealthBarValue()==0f)
        {

            // SceneManager.LoadScene(2);
            Debug.Log("se murio por vida");
            
        }
        if (Input.GetButton("Fire1") && Time.time > nextdisparo)
        {

            nextdisparo = Time.time + veldisparo+1;
            Instantiate(disparo, lugardisparo.position, lugardisparo.rotation);

        }
        Movement();
     
     
    }
         
          private void Movement()

    { 

        float horizontalInput = Input.GetAxis("Horizontal");

       transform.Translate(Vector3.right * velocidad * horizontalInput * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
       
       
    }
    

   

    void timerEnded()
    {
        HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() - 0.02f);
        UIMgr.AddScore(-5);
        //targetTime = 50f;
    }



}
