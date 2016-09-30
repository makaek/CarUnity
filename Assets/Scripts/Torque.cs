using UnityEngine;
using System.Collections;

public class Torque : MonoBehaviour {

    public float torque = 100;

    public bool x = false;
    public bool y = false;
    public bool z = false;


	void FixedUpdate () {
        GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(x ? torque : 0f, y ? torque : 0f, z ? torque : 0f));
	}
}
