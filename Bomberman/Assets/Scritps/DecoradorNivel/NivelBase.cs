using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelBase : Nivel
{
    public override string nombre()
    {
        return "uno";
    }

    public override List<VestuarioE> vestuario()
    {
        List<VestuarioE> list = new List<VestuarioE>();
        VestuarioE vestuarioBase = new VestuarioE("vestuarioBase", "gris");
        list.Add(vestuarioBase);
        return list;
    }

    public override List<Escenario> escenario()
    {
        List<Escenario> list = new List<Escenario>();
        Escenario vestuarioBase = new Escenario("Default");
        list.Add(vestuarioBase);
        return list;
    
    }
}