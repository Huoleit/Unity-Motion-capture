using UnityEngine;
using System;

public class TalkToArduino : MonoBehaviour
{

	public ArduinoConnect arduinoConnect;
    public Orien orien;

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
		char leading = str [0];

        if (leading != '#' && leading != '$') return;

        str = str.Substring(2);
        string[] q_str = str.Split(';');


        if (q_str.Length != 4) return;

        double w,x,y,z;
        Debug.Log("<color=black>" + q_str[0] +  ' ' + q_str[1] + ' ' + q_str[2] + ' ' + q_str[3] +"</color>\n");
        if (!Double.TryParse(q_str[0], out w)) return;
        if (!Double.TryParse(q_str[1], out x)) return;
        if (!Double.TryParse(q_str[2], out y)) return;
        if (!Double.TryParse(q_str[3], out z)) return;
        switch(leading){
            case '#':
                orien.SetGloablOrien(new Quaternion((float)x, (float)y, (float)z, (float)w));
                break;
            case '$':
                orien.SetGloablOrien(new Quaternion((float)x, (float)y, (float)z, (float)w));
                break;

        }

        //int.TryParse (str.Substring (1), out result);

        //if (result == -1) {
        //	return;
        //}


        //if (result < 0) {
        //	Debug.Log ("<color=red>" + "Data not clean" + "</color>\n");
        //	result = 0;
        //}

        //if (result > 1024) {
        //	Debug.Log ("<color=red>" + "Data not clean" + "</color>\n");
        //	result = 1024;
        //}

        //switch (sensorReading) {

        //case 'A':
        //	Debug.Log ("<color=red>" + "A: " + result + "</color>\n");
        //	break;

        //case 'B':
        //	Debug.Log ("<color=orange>" + "B: " + result + "</color>\n");
        //	break;

        //case 'C':
        //	Debug.Log ("<color=yellow>" + "C: " + result + "</color>\n");
        //	break;

        //case 'H':
        //	Debug.Log ("<color=grey>" + "Cathed a spare handshake " + "</color>\n");
        //	break;

        //default:
        //	Debug.LogError ("Case not found: " + sensorReading);
        //	break;
        //}

    }
}
