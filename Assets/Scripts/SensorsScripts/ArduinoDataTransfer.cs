using System.IO.Ports;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ArduinoDataTransfer : MonoBehaviour {

	//zmienne pomocnicze do odliczania czasu
	private float counter = 0;
	private double time = 0.9;

	//zmienne do odbierania przesłanych danych
	private string firstData, secondData;


	private float gsrInput;
	private float pulseInput;

	private DataManager dataManager;

	//ustawienia portu numer COM18, z prędkością transmisji 9600
	//KOM TYMCZASOWY     SerialPort port = new SerialPort(@"\\.\" + "COM18", 9600);

	void Start(){

		dataManager = gameObject.GetComponent<DataManager> ();

		//KOM TYMCZASOWY    port.Open(); //otworzenie portu
		//KOM TYMCZASOWY    port.ReadTimeout = 1;
	}


	void FixedUpdate(){

		if(counter < time)
		{
			counter += Time.deltaTime;
		}
		else
		{

			//KOD DO TESTOWANIA
			pulseInput = (float)UnityEngine.Random.Range(60, 140);
			gsrInput = (float)UnityEngine.Random.Range(0, 50); //zmienna pomocnicza

			dataManager.saveData (pulseInput, gsrInput);
			//Debug.Log ("Przesłanie danych do zapisu: " + pulseInput + " " + gsrInput);

			//KOD WŁAŚCIWY
			/*
			try {

				firstData = port.ReadLine();
				Debug.Log("P: " + firstData);

				secondData = port.ReadLine();
				Debug.Log("C: " + secondData);

				pulseInput = (float)firstData;
				gsrInput = (float)secondData;

				dataManager.saveData (pulseInput, gsrInput);
					
			} catch (SystemException) {
				Debug.Log ("Błąd odczytu.");
			}*/


			counter = 0;
		}
	}

}
