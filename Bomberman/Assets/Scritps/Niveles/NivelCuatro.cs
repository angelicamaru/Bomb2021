using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelCuatro : DecoradorNivel
{

	public NivelCuatro(Nivel nivelDecorado) : base(nivelDecorado)
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
		VestuarioE vestuarioDos = new VestuarioE("vestuarioPlaya", "amarillo");
		list.Add(vestuarioDos);
		return list;

	}


	public override List<Escenario> escenario()
	{
		List<Escenario> list = new List<Escenario>();
		list = nivelDecorado.escenario();
		Escenario vestuarioBase = new Escenario("Playa");
		list.Add(vestuarioBase);
		return list;
	}


}

