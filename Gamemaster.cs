using UnityEngine;
using System.Collections;
using Leap;

public class Gamemaster : MonoBehaviour {

    public GameObject car;
    public Camera backcamera;
    public Camera seatcamera;
    public bool first = false;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (car.GetComponent<CarDrive>().engine && !first)
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
