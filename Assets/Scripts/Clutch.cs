using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clutch : MonoBehaviour {

    public GameObject outDisk;
    public Slider clutchSlider;

    private bool flag = false;

    void Awake()
    {
        updateDiskPosition();
    }

    void Update()
    {
        if (flag)
        {
            updateDiskPosition();
            flag = false;
        }
    }

    public void onClutchValueChanged()
    {
        flag = true;
    }

    private void updateDiskPosition()
    {
        outDisk.transform.localPosition = new Vector3(outDisk.transform.localPosition.x, outDisk.transform.localPosition.y, clutchSlider.value);
    }

    
}
