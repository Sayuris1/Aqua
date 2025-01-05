using UnityEngine;

namespace CrazyPhone.PortDetector
{
    public class WaitForPong : CustomYieldInstruction
    {
        private const string PONG = "pong";
        private string lastMessage;
        private bool success;

        public WaitForPong(PortSetting input)
        {
            input.onSerializedMessage += OnMessage;
        }

        private void OnMessage(string msg)
        {
            lastMessage = msg;
            success = lastMessage.Equals(PONG);
        }

        public override bool keepWaiting => !success;
    }
}