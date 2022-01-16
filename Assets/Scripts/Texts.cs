using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Texts : MonoBehaviour
{
    public Text scoretext;
    public Text geartext;
    public Text timertext;
   // public Text speedtext;
   private float startTime;
//    private bool finished=false;

    // Update is called once per frame
    private void Start()
    {
      startTime=Time.time;
    }

    void Update()
    {
        scoretext.text = GameObject.Find("PlayerCar").GetComponent<CarController>().current.ToString();
        geartext.text = GameObject.Find("PlayerCar").GetComponent<CarController>().gear.ToString();
      //  speedtext.text = GameObject.Find("PlayerCar").GetComponent<CarController>().speedtext.ToString();
      float t=Time.time - startTime;

      //string minutes=((int) t/60).ToString();
      string secounds =(t%60).ToString("f2");

      timertext.text=secounds;

      if(t%60 > 25){
        geartext.text="TimeOver";
        FindObjectOfType<GameManager>().EndGame();
      }
    }
    // public void Finished(){
    //   finished=true;
    //   timertext.color=Color.Yellow;
    // }
}
