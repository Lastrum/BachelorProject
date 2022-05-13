using System;
using UnityEngine;

namespace Manager
{
    public enum CameraType
    {
        MainCamera,
        ShopCamera
    }
    
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Camera shopCamera;

        private static Camera _mainCamera;
        private static Camera _shopCamera;
        private static Camera _currentCamera;

        private void Awake()
        {
            mainCamera.gameObject.SetActive(false);
            shopCamera.gameObject.SetActive(false);

            _mainCamera = mainCamera;
            _shopCamera = shopCamera;
            _currentCamera = _mainCamera;
            
            SwitchCamera(CameraType.MainCamera);
        }
        
        public static void SwitchCamera(CameraType cameraType)
        {
            _currentCamera.gameObject.SetActive(false);
            
            switch (cameraType)
            {
                case CameraType.MainCamera:
                    _mainCamera.gameObject.SetActive(true);
                    _currentCamera = _mainCamera;
                    break;
                case CameraType.ShopCamera:
                    _shopCamera.gameObject.SetActive(true);
                    _currentCamera = _shopCamera;
                    break;
            }
        }
    }
}
