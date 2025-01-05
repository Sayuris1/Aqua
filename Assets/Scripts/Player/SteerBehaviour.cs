using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AcceleratedMovementBehaviour))]
public class SteerBehaviour : MonoBehaviour
{
    public float SteerSpeed = 1;

    private float _direction = 0;
    private AcceleratedMovementBehaviour _accelertedBehaviour;

    private void Start()
    {
        _accelertedBehaviour = GetComponent<AcceleratedMovementBehaviour>();
    }

    private void Update()
    {
        _accelertedBehaviour.AddToAccelerationPerFrame(_direction );
    }

    public void GetSteerInput(InputAction.CallbackContext ctx)
    {
        _direction = ctx.ReadValue<float>() * SteerSpeed;
    }

    void OnMessageArrived(string msg)
    {
        string copyMsg = string.Copy(msg);
        string[] splitMsg= copyMsg.Split(',');

        int[] inputInt = Array.ConvertAll(splitMsg, int.Parse);
        float[] inputFloat = inputInt.Select(i => (float)i).ToArray();
        float[] inputFloatRemaped = new float[inputFloat.Length];

        for (int i = 0; i < inputFloat.Length; i++)
            inputFloatRemaped[i] = Mathf.Clamp(inputFloat[i].Remap(850, 300, SteerSpeed, -SteerSpeed), -SteerSpeed, SteerSpeed);

        _direction = inputFloatRemaped[0] + inputFloatRemaped[1];
    }

    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
