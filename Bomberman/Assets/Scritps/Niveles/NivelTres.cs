using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelTres : DecoradorNivel
{

	public NivelTres(Nivel nivelDecorado) : base(nivelDecorado)
	{

	}

	public override string nombre()
	{
		return "tres";
	}

	public override List<VestuarioE> vestuario()
	{
		List<VestuarioE> list = new List<VestuarioE>();
		list = nivelDecorado.vestuario();
		VestuarioE vestuarioDos = new VestuarioE("vestuarioDisco", "azul");
		list.Add(vestuarioDos);
		return list;

	}


	public override List<Escenario> escenario()
	{
		List<Escenario> list = new List<Escenario>();
		list = nivelDecorado.escenario();
		Escenario vestuarioBase = new Escenario("Disco");
		list.Add(vestuarioBase);
		return list;
	}


}
