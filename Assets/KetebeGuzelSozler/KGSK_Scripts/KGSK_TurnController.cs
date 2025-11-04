using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KetebeGuzelSK
{
    public class KGSK_TurnController : MonoBehaviour
    {
        public float turnSpeed = 30f;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }
    }

}
