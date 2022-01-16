using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    public Vector3 position;
    public float speed;
    public string speedtext="0";
    public string current="";
    public string gear="P";
    private bool check=false;
    private bool winFlag=false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float ft = Time.deltaTime;

        // if(Input.GetKey("d"))
        //     check=true;

        if(check){
            this.transform.position += transform.forward * speed * ft;
            speedtext=(speed * ft).ToString();
        }

        if (Input.GetKey("p"))
        {
            check=false;
            this.transform.position =  this.transform.position;
            gear="P";

        }
        
        if (Input.GetKey("d"))
        {
            check=true;
            gear="D";


        }

        if(Input.GetKey("r")){
            check=false;
            this.transform.position =  this.transform.position;
            gear="R";}
        if (Input.GetKey("down")&&gear=="R")
        {
             this.transform.position -= transform.forward * speed * ft;

            this.transform.position -= transform.forward * speed * ft* 0.5f;
            
        }
           if (Input.GetKey("up")&&gear=="D")
             this.transform.position += transform.forward * speed * ft;

       if (Input.GetKey("right")&&(gear=="D"||gear=="R"))
        {
            var v3 = new Vector3(0, 90, 0.0f);
            transform.Rotate(v3 * Time.deltaTime);
            
        }
        if (Input.GetKey("left")&&(gear=="D"||gear=="R"))
        {
            var v3 = new Vector3(0, -90, 0.0f);
            transform.Rotate(v3 * Time.deltaTime);
            
        }
            if(winFlag &&Input.GetKey("p")){
            Debug.Log("You Win");       
            current = "Win";
            FindObjectOfType<GameManager>().EndGame();

        }

}
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Building" || collision.gameObject.name == "Tree"|| collision.gameObject.name == "FCar")
        {
            Debug.Log("You Lost");
            current = "Lost";
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collision.gameObject.name == "WinParkingSpot")
        {
            winFlag=true;
        }


    }
}