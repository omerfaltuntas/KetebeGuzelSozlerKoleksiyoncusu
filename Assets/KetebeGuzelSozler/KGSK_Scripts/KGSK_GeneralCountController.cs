using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KetebeGuzelSK
{
    public class KGSK_GeneralCountController : MonoBehaviour
    {
        public static KGSK_GeneralCountController instance;

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
            currentCount = PlayerPrefs.GetInt("KGSKPageData");
        }

        private void FixedUpdate()
        {
            currentCount = Mathf.Min(currentCount, maxPageCount);

            // Değeri kaydet
            PlayerPrefs.SetInt("KGSKPageData", currentCount);
            PlayerPrefs.Save();
        }
    }

}
