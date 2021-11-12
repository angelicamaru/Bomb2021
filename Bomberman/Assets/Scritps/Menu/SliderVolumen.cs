using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumen : MonoBehaviour
{
   public Slider slider;
   public Image imagenMute;
   public float sliderValue;
   void Start (){
       slider.value = PlayerPrefs.GetFloat("volumenAudio",0.5f);
       AudioListener.volume=slider.value;
       RevisarSiEstoyMute();
   }
   public void ChangeSlider(float valor){
       sliderValue=valor;
       PlayerPrefs.SetFloat("volumenAudio",sliderValue);
       AudioListener.volume=slider.value;
       RevisarSiEstoyMute();
   }

   public void RevisarSiEstoyMute (){
       if (sliderValue==0){
           imagenMute.enabled=true;
       }
       else {
           imagenMute.enabled=false;
       }
   }
}