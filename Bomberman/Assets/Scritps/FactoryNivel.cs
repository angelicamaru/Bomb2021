using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryNivel
{

	public static Nivel getNivel(string tipo)
	{

		Nivel nivel = new NivelBase();//Nivel 1	
		Nivel nivel2 = new NivelDos(nivel);
		Nivel nivel3 = new NivelTres(nivel2);
		Nivel nivel4 = new NivelCuatro(nivel3);
		Nivel nivel5 = new NivelCinco(nivel4);


		if (tipo.Equals("1"))
		{
			return nivel;
		}
		else if (tipo.Equals("2"))
		{

			return nivel2;
		}
		else if (tipo.Equals("3"))
		{

			return nivel3;
		}
		else if (tipo.Equals("4"))
		{

			return nivel4;
		}
		else if (tipo.Equals("5"))
		{

			return nivel5;
		}
		else
		{
			//null object
			return nivel;
		}

	}
}