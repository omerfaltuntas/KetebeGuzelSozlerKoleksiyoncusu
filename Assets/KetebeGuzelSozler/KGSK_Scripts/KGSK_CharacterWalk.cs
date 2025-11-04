using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace KetebeGuzelSK
{

    public class KGSK_CharacterWalk : MonoBehaviour
    {
        private Transform leftLeg;
        private Transform rightLeg;

        public float leftForwardAngle = 25f;
        public float leftBackwardAngle = 10f;
        public float rightForwardAngle = 25f;
        public float rightBackwardAngle = 10f;

        public float swingSpeed = 4f;
        public float moveSpeed = 2f;

        public float walkDistance = 5f;

        public bool startFacingRight = true; // true ise sağa başlar, false ise sola

        private float swingTimer = 0f;
        private Vector3 startPos;
        private int direction;

        void Start()
        {
            leftLeg = transform.GetChild(0);
            rightLeg = transform.GetChild(1);

            // Başlangıç yönü
            direction = startFacingRight ? 1 : -1;

            // Eğer sola başlıyorsa scale.x'i negatif yap (karakter sola baksın)
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * direction;
            //transform.localScale = scale;

            startPos = transform.position;
        }

        void Update()
        {
            swingTimer += Time.deltaTime * swingSpeed;
            float swing = Mathf.Sin(swingTimer);

            float leftAngle = swing >= 0
                ? Mathf.Lerp(0, leftForwardAngle, swing)
                : Mathf.Lerp(0, -leftBackwardAngle, -swing);

            float rightSwing = -swing;
            float rightAngle = rightSwing >= 0
                ? Mathf.Lerp(0, rightForwardAngle, rightSwing)
                : Mathf.Lerp(0, -rightBackwardAngle, -rightSwing);

            leftLeg.localRotation = Quaternion.Euler(0f, 0f, leftAngle);
            rightLeg.localRotation = Quaternion.Euler(0f, 0f, rightAngle);

            transform.position += Vector3.right * moveSpeed * Time.deltaTime * direction;

            float walkedDistance = Vector3.Distance(startPos, transform.position);
            if (walkedDistance >= walkDistance)
            {
                direction *= -1;

                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;

                startPos = transform.position;
            }
        }
    }
}
