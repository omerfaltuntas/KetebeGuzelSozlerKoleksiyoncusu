using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KetebeFirtinaDolabi
{
    public class FD_Slot : MonoBehaviour
    {
        public bool isFilled = false;
        public int slotId;
        private void OnDisable()
        {
            isFilled = false;
        }
    }

}
