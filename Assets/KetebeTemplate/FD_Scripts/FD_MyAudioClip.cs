using UnityEngine;
namespace KetebeFirtinaDolabi
{
    [System.Serializable]
    public class FD_MyAudioClip
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume = 1f; // Ses seviyesi eklendi
    }
}

