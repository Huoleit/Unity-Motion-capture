using UnityEngine;

public class ArduinoConnectController : MonoBehaviour
{
    public TalkToArduino talk;
    public string portName;
    public int baudrate;

    //start scanning on Start
    void Start ()
	{
        talk.StartTalkingToArduino(portName, baudrate);
    }

	//start scanning for arduino
	
}
