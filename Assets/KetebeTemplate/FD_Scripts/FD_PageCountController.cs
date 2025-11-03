using KetebeFirtinaDolabi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KetebeFirtinaDolabi
{
    public class FD_PageCountController : MonoBehaviour
    {
        public static FD_PageCountController instance;

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
            if (FD_GeneralCountController.instance.currentCount < pageCount)
                FD_GeneralCountController.instance.currentCount = pageCount;
        }

    }

}

