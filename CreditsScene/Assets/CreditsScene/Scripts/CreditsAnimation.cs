using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace nameCreditsScene
{
    public class CreditsAnimation : MonoBehaviour, IPointerClickHandler
    {
        
        private ScrollRect scrollRectCreditsPanel;
        private bool animationCreditsActive;

        private void OnEnable()
        {
            scrollRectCreditsPanel = gameObject.GetComponent<ScrollRect>();
            scrollRectCreditsPanel.verticalNormalizedPosition = 1f;
            animationCreditsActive = true;
            StartCoroutine(AnimationCredits());
        }

        private IEnumerator AnimationCredits()
        {

            while(scrollRectCreditsPanel.verticalNormalizedPosition > 0f)
            {
                scrollRectCreditsPanel.verticalNormalizedPosition -= 0.0002f;
                if(!animationCreditsActive) { break; }
                yield return new WaitForSeconds(0.0002f);
            }
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            animationCreditsActive = false;
        }

    }
}
