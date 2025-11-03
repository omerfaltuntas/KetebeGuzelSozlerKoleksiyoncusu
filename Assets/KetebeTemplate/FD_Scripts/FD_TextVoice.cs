using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KetebeFirtinaDolabi
{
    public class FD_TextVoice : MonoBehaviour
    {
        public string soundName;
        private bool isPlaying = false; // Sesin calip calmadigini kontrol eder

        private void OnMouseDown()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!string.IsNullOrEmpty(soundName) && !isPlaying)
                {
                    StartCoroutine(PlaySoundWithCooldown());
                }
            }
        }

        private IEnumerator PlaySoundWithCooldown()
        {
            isPlaying = true; // Ses caliyor olarak isaretleniyor
            FD_AudioManager.instance.PlayClip(soundName);

            // Sesin uzunlugunu al (KM_AudioManager icinde ses uzunlugunu alabilecegimiz bir metod oldugunu varsayalim)
            float soundDuration = FD_AudioManager.instance.GetClipLength(soundName);

            yield return new WaitForSeconds(soundDuration); // Ses uzunlugu kadar bekle
            isPlaying = false; // Bekleme suresi bitince tekrar calinabilir hale getir
        }


    }
}


