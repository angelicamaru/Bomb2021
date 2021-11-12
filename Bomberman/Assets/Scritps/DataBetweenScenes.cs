using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBetweenScenes : MonoBehaviour
{
    public static DataBetweenScenes instance;

    #region Generic Script
    private int userId;
    public int vestuario;
    public int escena;
    #endregion

    private void Awake()
    {
        if (DataBetweenScenes.instance == null)
        {
            DataBetweenScenes.instance = this;//Creo el singleton la ÚNICA instancia del objeto
            DontDestroyOnLoad(gameObject);
        }
        else {
            //YA hay una instancia entonces hay que eliminarla.
            if (instance != this) {
                Destroy(gameObject);
            }
        }
    }

    public void SetUserId(int i) {
      
            userId = i;
        }

     public int GetUserId() {
            return userId;
        }

   
    public void SetVestuario(int i)
    {
     
        vestuario = i;
    }
    

  public int GetVestuario()
  {
      return vestuario;
  }
    
  public void SetEscenario(int i)
  {

      escena = i;
  }

  public int GetEscenario()
  {
      return escena;
  }


}
