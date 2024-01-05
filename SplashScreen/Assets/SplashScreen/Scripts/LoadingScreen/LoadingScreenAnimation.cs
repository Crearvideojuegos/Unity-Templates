using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace nameSplashScreen
{
    public class LoadingScreenAnimation : MonoBehaviour
    {
        [SerializeField] private Image imageLoading;
        [SerializeField] private TMP_Text textLoading;

        
        private void OnEnable() 
        {
            StartCoroutine(TextLoadingDots());           
        }

        private void FixedUpdate()
        {
            RotationImage();
        }

        private void RotationImage()
        {
            Vector3 rotation = new Vector3(0, 0, -10);
            imageLoading.transform.Rotate(rotation * 10 * Time.deltaTime);
        }

        private IEnumerator TextLoadingDots()
        {
            textLoading.text = "Loading";
            yield return new WaitForSeconds(1f);

            textLoading.text = "Loading.";
            yield return new WaitForSeconds(1f);

            textLoading.text = "Loading..";
            yield return new WaitForSeconds(1f);

            textLoading.text = "Loading...";
            yield return new WaitForSeconds(1f);

            StartCoroutine(TextLoadingDots());    
        }


    }
}