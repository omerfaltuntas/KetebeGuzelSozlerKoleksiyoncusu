using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KetebeFirtinaDolabi
{
    public class FD_GeneralCountController : MonoBehaviour
    {
        public static FD_GeneralCountController instance;

        public int currentCount;

        [Header("Max Page Count")]
        public int maxPageCount;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            currentCount = PlayerPrefs.GetInt("FDPageData");
        }

        private void FixedUpdate()
        {
            currentCount = Mathf.Min(currentCount, maxPageCount);

            // Değeri kaydet
            PlayerPrefs.SetInt("FDPageData", currentCount);
            PlayerPrefs.Save();
        }
    }

}
