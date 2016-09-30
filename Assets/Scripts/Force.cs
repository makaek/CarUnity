using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {

    public float force = 100;

    public bool x = false;
    public bool y = false;
    public bool z = false;

    private Rigidbody rigidbody;


    void Awake ()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

   

	void FixedUpdate () {
            rigidbody.AddRelativeForce(new Vector3(x ? force : 0f, y ? force : 0f, z ? force : 0f));
	}
}
