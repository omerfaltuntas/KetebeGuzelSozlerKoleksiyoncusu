using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KetebeGuzelSK
{
    public class KGSK_Slot : MonoBehaviour
    {
        public bool isFilled = false;
        public int slotId;
        private void OnDisable()
        {
            isFilled = false;
        }
    }

}
