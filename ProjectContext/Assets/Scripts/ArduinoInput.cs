using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;


public class ArduinoInput : MonoBehaviour
{

	[SerializeField] private SerialController serialCon;

    // Start is called before the first frame update
    void Start()
    {
		//serialCon.GetComponent<SerialController>();
    }

    // Update is called once per frame
    void Update()
    {
		serialCon.ReadSerialMessage();
		//SerialController.ReadSerialMessage()
		Debug.Log(serialCon.ReadSerialMessage());
	}
}
