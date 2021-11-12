using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Nivel
{

	public abstract string nombre();
	public abstract List<VestuarioE> vestuario();
	public abstract List<Escenario> escenario();

}