using UnityEngine;
using System.Collections;

public class CarDrive : MonoBehaviour {
    public drivehand driver;
    Rigidbody rigid;
    public bool engine;
    public int speed=1;
    public int angledivide=1;
    // Use this for initialization
    void Start () {
        driver = GetComponentInChildren<drivehand>();
        rigid = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (driver.readyOK)
        {
            engine = true;
            var v3 = new Vector3(-driver.sin * speed, 0, 1 * speed);
            Debug.Log(v3.ToString());
            transform.Rotate(0f,0f,driver.handsAngle/angledivide);
            rigid.AddForce(-transform.up*speed);
        }
	}
}
