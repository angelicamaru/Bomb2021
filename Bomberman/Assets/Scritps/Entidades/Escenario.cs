using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escenario
{

	private string nombre;


	//Constructores;

	public Escenario(string nombre)
	{
		this.nombre = nombre;
	}

	public Escenario()
	{

	}

	//Getters & Setters

	public string getNombre()
	{
		return nombre;
	}

	public void setNombre(string nombre)
	{
		this.nombre = nombre;
	}
}
