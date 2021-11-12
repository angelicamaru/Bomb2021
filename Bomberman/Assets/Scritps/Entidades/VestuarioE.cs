using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VestuarioE
{
	private string nombre;
	private string color;


	//Constructores;

	public VestuarioE(string nombre, string color)
	{
		this.nombre = nombre;
		this.color = color;
	}

	public VestuarioE()
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

	public string getColor()
	{
		return color;
	}

	public void setColor(string color)
	{
		this.color = color;
	}

}