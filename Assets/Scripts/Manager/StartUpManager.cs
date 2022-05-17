using System;
using UnityEngine;

namespace Manager
{
    public class StartUpManager : MonoBehaviour
    {
        [SerializeField] private DataManager dataManager;

        private void Start()
        {
            dataManager.UpdateData();
        }
        
    }
}
