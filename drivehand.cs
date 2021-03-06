﻿using UnityEngine;
using System.Collections;
using Leap;

public class drivehand : MonoBehaviour {

    Controller cont;
    public Hand rightHand;
    public Hand leftHand;
    public float handsAngle;
    public float sin;
    public bool readyOK = false;
    public bool bikemode = false;
	// Use this for initialization
	void Start () {
        cont = new Controller();
	}
	
	// Update is called once per frame
	void Update () {
        Frame frame = cont.Frame();
        var hands = frame.Hands;
        foreach(Hand h in hands)
        {
            if (h.IsLeft)
                leftHand = h;
            if (h.IsRight)
                rightHand = h;
        }
        if(leftHand!=null && rightHand != null)
        {
            checkAngle(rightHand, leftHand);
            if (leftHand.GrabStrength>0.7 && rightHand.GrabStrength >0.7)
            {
                readyOK = true;
            }
        }
	}
    void checkAngle(Hand r,Hand l)
    {
        Vector3 handsVector;
        if (bikemode)
        {
            handsVector = new Vector3(r.PalmPosition.x - l.PalmPosition.x, 0,r.PalmPosition.z-l.PalmPosition.z);
        }
        else
        {
            handsVector = new Vector3(r.PalmPosition.x - l.PalmPosition.x, r.PalmPosition.y - l.PalmPosition.y);
        }
        float angle = Vector3.Angle(Vector2.right, handsVector);
        if (handsVector.y > 0)
            angle = -angle;
        handsAngle = angle;
        sin = Mathf.Sin(Mathf.Deg2Rad*angle);
    }
}
