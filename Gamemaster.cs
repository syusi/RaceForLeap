using UnityEngine;
using System.Collections;
using Leap;

public class Gamemaster : MonoBehaviour {

    public GameObject beacle;
    public Camera backcamera;
    public Camera seatcamera;
    bool first = false;
    public bool GamemodeBike;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        beacle.GetComponent<CarDrive>().bikemode = GamemodeBike;
        if (beacle.GetComponent<CarDrive>().engine && !first)
        {
            changeCamera();
            first = true;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            changeCamera();
        }
	}
    void changeCamera()
    {
        backcamera.enabled = !backcamera.enabled;
        seatcamera.enabled = !seatcamera.enabled;
    }
}
