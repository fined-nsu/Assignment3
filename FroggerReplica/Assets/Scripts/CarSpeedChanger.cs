using UnityEngine;
using UnityEngine.UI;

public class CarSpeedChanger : MonoBehaviour
{
    public Slider carSpeedSlider;
    public static float speedChangeValue = 0f;

    public void ChangeCarSpeed()
    {
        speedChangeValue = carSpeedSlider.value;
    }
}
