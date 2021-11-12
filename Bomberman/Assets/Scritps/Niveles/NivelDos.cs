using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelDos : DecoradorNivel
{

public NivelDos(Nivel nivelDecorado) : base(nivelDecorado)
	{
		
	}	

public override string nombre()
{
	return "dos";
}

public override List<VestuarioE> vestuario()
{
	List<VestuarioE> list = new List<VestuarioE>();
	list = nivelDecorado.vestuario();
	VestuarioE vestuarioDos = new VestuarioE("vestuarioClasico", "cafe");
	list.Add(vestuarioDos);
	return list;

}
	
	
	public override List<Escenario> escenario() {
		List<Escenario> list =new List<Escenario>();
		list = nivelDecorado.escenario();
		Escenario vestuarioBase = new Escenario("Bodega");
		list.Add(vestuarioBase);
		return list;
	}
	
	
}
