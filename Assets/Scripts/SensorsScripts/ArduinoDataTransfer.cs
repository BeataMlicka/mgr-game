using System.IO.Ports;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ArduinoDataTransfer : MonoBehaviour {

	//zmienne pomocnicze do odliczania czasu
	private float counter = 0;
	private float time = 1;

	//zmienne do odbierania przesłanych danych
	private string firstData, secondData;


	private float firstInput;
	private float secondInput;

	private DataManager dataManager;

	private float pulseInput;
	private float gsrInput;

	//ustawienia portu numer COM18, z prędkością transmisji 9600
	//KOM TYMCZASOWY   
	SerialPort port = new SerialPort(@"\\.\" + "COM18", 9600);

	void Start(){

		dataManager = gameObject.GetComponent<DataManager> ();

		//KOM TYMCZASOWY   
		port.Open(); //otworzenie portu
		//KOM TYMCZASOWY  
		//port.ReadTimeout = 1;
	}


	void FixedUpdate(){

		if(counter < time)
		{
			counter += Time.deltaTime;
		}
		else if(counter > time)
		{

			//KOD DO TESTOWANIA
			/*
			pulseInput = (float)UnityEngine.Random.Range(60, 140);
			gsrInput = (float)UnityEngine.Random.Range(0, 50); //zmienna pomocnicza

			dataManager.saveData (pulseInput, gsrInput);
			//Debug.Log ("Przesłanie danych do zapisu: " + pulseInput + " " + gsrInput);
*/
			//KOD WŁAŚCIWY

			try {

				firstData = port.ReadLine();
				//Debug.Log("P: " + firstData);

				secondData = port.ReadLine();
				//Debug.Log("C: " + secondData);

				firstInput = float.Parse(firstData);
				secondInput = float.Parse(secondData);

				if((firstInput == 0f) || (firstInput > 20)){
					pulseInput = firstInput;
				}else{
					gsrInput = firstInput;
				}

				if((secondInput == -1f) || ((secondInput > 0) && (secondInput < 20))){
					gsrInput = secondInput;
				}else{
					pulseInput = secondInput;
				}


				dataManager.saveData (pulseInput, gsrInput);
					
			} catch (SystemException) {
				Debug.Log ("Błąd odczytu.");
			}


			counter = 0;
		}
	}

}
