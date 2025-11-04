using KetebeFirtinaDolabi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KetebeGuzelSK
{
    public class KGSK_PageCountController : MonoBehaviour
    {
        public static KGSK_PageCountController instance;

        [Header("Page Count")]
        public int pageCount;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void OnEnable()
        {
            if (KGSK_GeneralCountController.instance.currentCount < pageCount)
                KGSK_GeneralCountController.instance.currentCount = pageCount;
        }

    }

}

