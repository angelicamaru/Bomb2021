using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class NivelCinco : DecoradorNivel
	{

		public NivelCinco(Nivel nivelDecorado) : base(nivelDecorado)
		{

		}

	public override string nombre()
	{
		return "cuatro";
	}

	public override List<VestuarioE> vestuario()
	{
		List<VestuarioE> list = new List<VestuarioE>();
		list = nivelDecorado.vestuario();
		VestuarioE vestuarioDos = new VestuarioE("vestuarioLucha", "rojo");
		list.Add(vestuarioDos);
		return list;

	}


	public override List<Escenario> escenario()
	{
		List<Escenario> list = new List<Escenario>();
		list = nivelDecorado.escenario();
		Escenario vestuarioBase = new Escenario("Lucha");
		list.Add(vestuarioBase);
		return list;
	}


	}


