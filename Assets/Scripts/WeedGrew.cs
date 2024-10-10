using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class WeedGrew : MonoBehaviour
    {
        private float m_TimeToGrowth;
        private bool m_isGrowth;
        public bool isGrowth => m_isGrowth;
        private void Start()
        {
            m_isGrowth = false;
        }
        private IEnumerator WaitToGrowth()
        {
            yield return new WaitForSeconds(m_TimeToGrowth);
            m_isGrowth = true;
        }
        public void WeedBeginToGrow()
        {
            StartCoroutine(WaitToGrowth());
        }
    }
}
