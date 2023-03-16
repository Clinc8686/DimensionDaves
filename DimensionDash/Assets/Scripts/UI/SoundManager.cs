using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class SoundManager : MonoBehaviour
	{
		
		public float fadeTime;


		[SerializeField]
		private Slider musicVolumeSlider;
		[SerializeField]
		private Slider effectVolumeSlider;
		[SerializeField]

		private GenericDictionary<string, AudioSource> musicSourceDic;
		[SerializeField]
		private AudioSource effectSource;


		private float maxMusicVolume;
		public string   currentDimensionMusic;
		private string   priorDimensionMusic;
		private bool  fadeOut;
		private bool  fadeIn;
	


		void Start()
		{
			maxMusicVolume = musicVolumeSlider.value;
			foreach (AudioSource audioSource in musicSourceDic.Values) 
			{
				audioSource.volume    = 0;
				fadeIn                = true;
			}
		}

		void Update()
		{
			FadeMusic();
		}

		public void DimensionChangeMusicSwap(string i) 
		{
			if(i != currentDimensionMusic) {
				priorDimensionMusic   = currentDimensionMusic;
				currentDimensionMusic = i;
				fadeOut               = true;
				fadeIn                = true;
			}
		}



		private void FadeMusic() 
		{
			
			if (fadeOut && musicSourceDic[priorDimensionMusic] != null) {
				if (musicSourceDic[priorDimensionMusic].volume > 0)
					musicSourceDic[priorDimensionMusic].volume -= fadeTime;
				if (musicSourceDic[priorDimensionMusic].volume <= 0) 
				{
					musicSourceDic[priorDimensionMusic].volume = 0;
					fadeOut                                     = false;
				}
			}

			if (fadeIn) {
				if (musicSourceDic[currentDimensionMusic].volume < maxMusicVolume)
					musicSourceDic[currentDimensionMusic].volume += fadeTime;
				if (musicSourceDic[currentDimensionMusic].volume >= maxMusicVolume) 
				{
					musicSourceDic[currentDimensionMusic].volume = maxMusicVolume;
					fadeIn                                        = false;
				}
			}
		}


		public void ChangeMusicVolume() 
		{
			float newVolume = musicVolumeSlider.value;
			musicSourceDic[currentDimensionMusic].volume = newVolume;
			maxMusicVolume                                = newVolume;
			Debug.Log(maxMusicVolume);
		}

		public void ChangeEffectVolume() {
			float newVolume = musicVolumeSlider.value;
			effectSource.volume = newVolume;
		}
		
	}
}
