using System;
using UnityEngine;

namespace CrazyPhone.PortDetector
{
    public class SetPortToSetting : MonoBehaviour
    {
        [SerializeField] private SerialController serialController;

        private void Awake()
        {
            serialController.portName = PortSetting.PORT;
        }
    }
}