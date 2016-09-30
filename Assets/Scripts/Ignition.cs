using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ignition : MonoBehaviour {

	public GameObject springPiston1;
	public GameObject springPiston2;
	public GameObject springPiston3;
	public GameObject springPiston4;
	public GameObject springPiston5;
	public GameObject springPiston6;
	public GameObject springPiston7;
	public GameObject springPiston8;

    public GameObject crankShaft;

    public Image piston1Indicator;
    public Image piston2Indicator;
    public Image piston3Indicator;
    public Image piston4Indicator;
    public Image piston5Indicator;
    public Image piston6Indicator;
    public Image piston7Indicator;
    public Image piston8Indicator;

    public Text rpmText;
    public Slider forceSlider;
	public Toggle engineToggle;
	public Toggle starterToggle;

    public Rigidbody engineBox;
	public Material materialExplosionBlue;
	public Material materialExplosionRed;

    private bool flag0;
    private bool flag180 = true;
    private int counter = 0;

    private bool enable = false;
	private bool enableStarter = false;
    private static Queue times = new Queue();

    void FixedUpdate () {
		if (enableStarter) 
		{
			crankShaft.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0f, 0f, 100f));
		}
        if (enable)
        {
            bool flagP1 = false;
            bool flagP2 = false;
            bool flagP3 = false;
            bool flagP4 = false;
            bool flagP5 = false;
            bool flagP6 = false;
            bool flagP7 = false;
            bool flagP8 = false;
            float angle = crankShaft.transform.localEulerAngles.z;    

			springPiston1.GetComponent<SpringJoint> ().spring = 0;
			springPiston2.GetComponent<SpringJoint> ().spring = 0;
			springPiston3.GetComponent<SpringJoint> ().spring = 0;
			springPiston4.GetComponent<SpringJoint> ().spring = 0;
			springPiston5.GetComponent<SpringJoint> ().spring = 0;
			springPiston6.GetComponent<SpringJoint> ().spring = 0;
			springPiston7.GetComponent<SpringJoint> ().spring = 0;
			springPiston8.GetComponent<SpringJoint> ().spring = 0;
                   
			if (angle >= 40 && angle <= 200) {
				springPiston2.GetComponent<SpringJoint> ().spring = forceSlider.value;
				springPiston4.GetComponent<SpringJoint> ().spring = forceSlider.value;

				flagP2 = true;
				flagP4 = true;

			} 

			if ((angle >= 220 && angle <= 360) || (angle >= 0 && angle <= 20)) {
				springPiston1.GetComponent<SpringJoint> ().spring = forceSlider.value;
				springPiston3.GetComponent<SpringJoint> ().spring = forceSlider.value;

				flagP1 = true;
				flagP3 = true;
			} 

			if (angle >= 160 && angle <= 320) {
				springPiston5.GetComponent<SpringJoint> ().spring = forceSlider.value;
				springPiston7.GetComponent<SpringJoint> ().spring = forceSlider.value;

				flagP5 = true;
				flagP7 = true;
			}

			if ((angle >= 340 && angle <= 360) || (angle >= 0 && angle <= 140)) {
				springPiston6.GetComponent<SpringJoint> ().spring = forceSlider.value;
				springPiston8.GetComponent<SpringJoint> ().spring = forceSlider.value;

				flagP6 = true;
				flagP8 = true;
			}

            if (angle >=0 && angle < 180 && flag180)
            {
                flag0 = true;
                flag180 = false;
                times.Enqueue(Time.time);
                if (times.Count == 10)
                {
                    rpmText.text = ((60 / (Time.time - (float)times.Dequeue())) * 9).ToString();
                }

            } else if (angle >= 180 && angle < 360 && flag0)
            {
                flag0 = false;
                flag180 = true;
            }

			updateIndicators (flagP1, flagP2, flagP3, flagP4, flagP5, flagP6, flagP7, flagP8);

        }
        
    }

    public void toggle()
    {
		enable = engineToggle.isOn;
        updateIndicators(false, false, false, false, false, false, false, false);
    }

	public void starter()
	{
		enableStarter = starterToggle.isOn;
	}
  

    private void updateIndicators(bool flagP1, bool flagP2, bool flagP3, bool flagP4, bool flagP5, bool flagP6, bool flagP7, bool flagP8)
    {
        if (flagP1)
        {
            piston1Indicator.color = Color.red;
			springPiston1.GetComponent<Renderer> ().material = materialExplosionRed;
        } else
        {
            piston1Indicator.color = Color.white;
			springPiston1.GetComponent<Renderer> ().material = materialExplosionBlue;
        }


        if (flagP2)
        {
            piston2Indicator.color = Color.red;
			springPiston2.GetComponent<Renderer> ().material = materialExplosionRed;
        }
        else
        {
            piston2Indicator.color = Color.white;
			springPiston2.GetComponent<Renderer> ().material = materialExplosionBlue;
        }

        if (flagP3)
        {
            piston3Indicator.color = Color.red;
			springPiston3.GetComponent<Renderer> ().material = materialExplosionRed;
        }
        else
        {
            piston3Indicator.color = Color.white;
			springPiston3.GetComponent<Renderer> ().material = materialExplosionBlue;
        }

        if (flagP4)
        {
            piston4Indicator.color = Color.red;
			springPiston4.GetComponent<Renderer> ().material = materialExplosionRed;
        }
        else
        {
            piston4Indicator.color = Color.white;
			springPiston4.GetComponent<Renderer> ().material = materialExplosionBlue;
        }

        if(flagP5)
        {
            piston5Indicator.color = Color.red;
			springPiston5.GetComponent<Renderer> ().material = materialExplosionRed;
        } else
        {
            piston5Indicator.color = Color.white;
			springPiston5.GetComponent<Renderer> ().material = materialExplosionBlue;
        }


        if (flagP6)
        {
            piston6Indicator.color = Color.red;
			springPiston6.GetComponent<Renderer> ().material = materialExplosionRed;
        }
        else
        {
            piston6Indicator.color = Color.white;
			springPiston6.GetComponent<Renderer> ().material = materialExplosionBlue;
        }

        if (flagP7)
        {
            piston7Indicator.color = Color.red;
			springPiston7.GetComponent<Renderer> ().material = materialExplosionRed;
        }
        else
        {
            piston7Indicator.color = Color.white;
			springPiston7.GetComponent<Renderer> ().material = materialExplosionBlue;
        }

        if (flagP8)
        {
            piston8Indicator.color = Color.red;
			springPiston8.GetComponent<Renderer> ().material = materialExplosionRed;
        }
        else
        {
            piston8Indicator.color = Color.white;
			springPiston8.GetComponent<Renderer> ().material = materialExplosionBlue;
        }
    }


}
