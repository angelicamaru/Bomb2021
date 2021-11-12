using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoradorNivel : Nivel
{
    protected Nivel nivelDecorado;
    public DecoradorNivel(Nivel nivelDecorado)
    {
        this.nivelDecorado = nivelDecorado;
    }
	public override string nombre()
	{
		return nivelDecorado.nombre();
	}

	public override List<VestuarioE> vestuario()
	{
		return nivelDecorado.vestuario();
	}
	public override List<Escenario> escenario()
	{
		return nivelDecorado.escenario();
	}
}