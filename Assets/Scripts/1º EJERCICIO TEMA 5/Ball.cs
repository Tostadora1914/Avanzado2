using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
#region Propertie
    #endregion

#region Fields
    //Force Slider
    [Range(1500, 2000)]
    [SerializeField] private float _ballForce = 1500f;

    //Angle Slider
    [Range(-19, 19)]
    [SerializeField] private int _ballAngle;

    //Ball Transform
    [SerializeField] private Transform _ballTransform;

    #endregion

#region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
{
        //Ball Rotation from "Angle Slider"
        ballQuaternion();
        //Horizontal Rotation + Rotate in Y Axis 
        RotateY();

        //Input of key "E"
        if (Input.GetKeyUp(KeyCode.E))
        {
            GetComponent<Rigidbody>().AddForce(_ballTransform.forward * _ballForce);
        }
}
#endregion
 
#region Public Methods
    public void ballQuaternion()
    {
        _ballTransform.rotation = Quaternion.Euler(0, _ballAngle, 0);
    }
    public void RotateY()
    {
        float rotation = Input.GetAxis("Horizontal");
        _ballTransform.Rotate(0, rotation * _ballForce * Time.deltaTime, 0);
    }
    #endregion

#region Private Methods
    #endregion
}

