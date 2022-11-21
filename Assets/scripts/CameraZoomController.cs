
using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoomController : MonoBehaviour
{
    [Header("INIT")] 
    [SerializeField] private Camera _camera;
    [SerializeField] private Slider _slider;

    [Header("INFO")] 
    [SerializeField] private float latestValue;

    public void ValueChange(float value)
    {
        Debug.Log("Slider Value " + value);
    }

    private void Update()
    {
        var newValue = _slider.value;
        if(newValue != latestValue)
        {
            latestValue = newValue;
            Debug.Log("Slider Value " + _slider.value);

            _camera.transform.localPosition = map(latestValue, 0f, 1f, 0f, 100f) * _camera.transform.forward;
        }
    }
    
    public static float map( float value, float leftMin, float leftMax, float rightMin, float rightMax )
    {
        return rightMin + ( value - leftMin ) * ( rightMax - rightMin ) / ( leftMax - leftMin );
    }
}
