using System;
using System.Collections;
using System.IO.Ports;
using CrazyPhone.Yields;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CrazyPhone.PortDetector
{
    public class DetectPort : MonoBehaviour
    {
        [SerializeField] private PortSetting phoneInput;
        [SerializeField] private Slider slider;
        [SerializeField] private TextMeshProUGUI status;
        [SerializeField] private float timeoutDuration = 2f;
        [SerializeField] private string sceneToLoadOnFinished = "IntroSequence";
        
        IEnumerator Start()
        {
            var ports = SerialPort.GetPortNames();
            var progress = ports.Length * 2;

            var currentProgress = 0;
            bool connected = false;
            
            foreach (var port in ports)
            {
                phoneInput.gameObject.SetActive(false);
                PortSetting.PORT = port;
                yield return new WaitForEndOfFrame();
                phoneInput.gameObject.SetActive(true);
                
                UpdateStatus($"connecting to {PortSetting.PORT}");

                var waitUntil = new WaitUntil(() => phoneInput.IsConnected).TimeoutParallel(timeoutDuration);
                yield return waitUntil;
                UpdateProgress(currentProgress++, progress);

                if (waitUntil.HasTimedOut)
                {
                    UpdateProgress(currentProgress++, progress);
                    continue;
                }

                try
                {
                    phoneInput.SendSerialMessage("ping");
                    UpdateStatus($"pinging {PortSetting.PORT}");
                }
                catch (Exception e)
                {
                    UpdateStatus(e.Message);
                    UpdateProgress(currentProgress++, progress);
                    continue;
                }

                var pong = new WaitForPong(phoneInput).TimeoutParallel(timeoutDuration);
                yield return pong;

                if (pong.HasTimedOut)
                {
                    UpdateProgress(currentProgress++, progress);
                    continue;
                }
                
                UpdateProgress(progress, progress);
                UpdateStatus($"connected to {PortSetting.PORT}");
                connected = true;
                break;
            }

            if (!connected) UpdateStatus("no device connected!");
            UpdateProgress(progress, progress);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(sceneToLoadOnFinished);
        }

        void UpdateProgress(int current, int max)
        {
            slider.value = (float) current / max;
        }

        void UpdateStatus(string text)
        {
            status.text = text;
        }
    }
}