using System;
using UnityEngine;

namespace CrazyPhone.PortDetector
{
    public class PortSetting : MonoBehaviour
    {
        public static string PORT = "COM12";

        public event Action<string> onSerializedMessage; 

        private bool isConnected;

        public bool IsConnected => isConnected;
        
        [SerializeField] private SerialController serialController;

        public void SendSerialMessage(string msg) => serialController.SendSerialMessage(msg);
        
        void OnConnectionEvent(bool success)
        {
            isConnected = success;
            //Debug.Log($"Connection Event: {success}");
        }
    }
}