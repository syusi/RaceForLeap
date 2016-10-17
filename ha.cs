using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Leap;

public class ha : MonoBehaviour {

    Controller controller;
    public Text text;
	// Use this for initialization
	void Start () {
        controller = new Controller();
	}
	
	// Update is called once per frame
	void Update () {
        Frame frame = controller.Frame();
        string info;
        List<Hand> hands = frame.Hands;
        foreach(Hand hand in hands){
            info = "handID" + hand.Id +" isright"+hand.IsRight+"\n";
            info += "Palm info (position:"+hand.PalmPosition+"\nVelocity:"+hand.PalmVelocity+"\n";
            info += "GrabStrenght:" + hand.GrabStrength + "  pinchStrength:" + hand.PinchStrength+"\n";
            List<Finger> fingers = hand.Fingers;
            foreach (Finger finger in fingers)
            {
                info += "finger " + finger.Type + " dirction" + finger.Direction + " extends is"+finger.IsExtended+"\n";
            }
            text.text = info;
        }
        
	}
}
