using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CounchHandler : MonoBehaviour
{
    private FixedJoystick fixedJoystick;  
    [SerializeField] private float rotationSpeed;   
    [SerializeField] private Button resetButton;           

    private Quaternion originalRotation;                   

    private void Start()
    {
        originalRotation = transform.rotation;

        resetButton.onClick.AddListener(ResetRotation);
        fixedJoystick = FindObjectOfType<FixedJoystick>();
    }


    private void FixedUpdate()
    {
        float horizontalInput = fixedJoystick.Horizontal;
        float verticalInput = fixedJoystick.Vertical;

        Vector3 rotationDirection = new Vector3(-verticalInput, horizontalInput, 0);

        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime, Space.Self);
    }
    private void ResetRotation()
    {
        transform.rotation = originalRotation;
    }
}

