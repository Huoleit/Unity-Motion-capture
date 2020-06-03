using UnityEngine;
using System;

public class TalkToArduino : MonoBehaviour
{

	public ArduinoConnect arduinoConnect;
    public Orien orien_upper;
    public Orien orien_lower;

    const float Frequency = 0.01f;

	public void StartTalkingToArduino (string portName,int baudrate)
    {
		arduinoConnect.Open (portName, baudrate);
		InvokeRepeating ("SendSensorIndexToArduino", Frequency, Frequency);
	}

	public void SendSensorIndexToArduino ()
	{
		//arduinoConnect.WriteToArduino (sensorChars [UpdateSensorIndex ()]);

		StartCoroutine
		(
			arduinoConnect.AsynchronousReadFromArduino
			((string s) => CheckCallback (s),     // Callback
				Frequency	                      // Timeout (seconds)
			)
		);
	}


	void CheckCallback (string str)
	{
        if (str == null) return;
		char leading = str [0];

        if (leading != '#') return;

        string[] q_str = str.Split(';');
        //Debug.Log("<color=black>" + q_str.Length + "</color>\n");

        if (q_str.Length != 9) return;

        double w1,x1,y1,z1,w2,x2,y2,z2;
        //Debug.Log("<color=black>" + q_str[0] +  ' ' + q_str[1] + ' ' + q_str[2] + ' ' + q_str[3] +"</color>\n")

        if (!Double.TryParse(q_str[1], out w1)) return;
        if (!Double.TryParse(q_str[2], out x1)) return;
        if (!Double.TryParse(q_str[3], out y1)) return;
        if (!Double.TryParse(q_str[4], out z1)) return;

        if (!Double.TryParse(q_str[5], out w2)) return;
        if (!Double.TryParse(q_str[6], out x2)) return;
        if (!Double.TryParse(q_str[7], out y2)) return;
        if (!Double.TryParse(q_str[8], out z2)) return;

       
        orien_upper.SetGloablOrien(new Quaternion((float)x1, (float)y1, (float)z1, (float)w1));

        orien_lower.SetGloablOrien(new Quaternion((float)x2, (float)y2, (float)z2, (float)w2));




    }
}
