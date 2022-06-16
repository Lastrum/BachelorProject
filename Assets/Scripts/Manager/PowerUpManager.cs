using System;
using System.Threading.Tasks;
using Player;
using UnityEngine;

namespace Manager
{
    public enum Power
    {
        Jumping,
        CoinMagnet,
        GodMode
    }
    
    
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;

        private MeshRenderer auraMesh;
        private bool flicker;
        private float value = 0.1f;
        
        [Header("Jumping")] 
        public int jumpLength;
        public Material jumpMaterial;
        [SerializeField] private GameObject jumpPrefab;

        [Header("Coin Magnet")]
        public bool magnetMode;
        public int magnetLength;
        public Material magnetMaterial;
        public GameObject magnet;
        [SerializeField] private GameObject magnetPrefab;
        
        [Header("God Mode")] 
        public bool godMode;
        public int godModeLength;
        public Material godModeMaterial;
        [SerializeField] private GameObject godPrefab;
        
        private void Awake()
        {
            //auraMesh = aura.GetComponent<MeshRenderer>();
            //aura.SetActive(false);
            flicker = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                MagnetMode(magnetLength);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Jumping(jumpLength);
            }            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                GodMode(godModeLength);
            }
        }

        public async void Jumping(float speed)
        {
            CreateAura(jumpPrefab, speed);
            playerController.playerMovement.jumpForce = playerController.playerMovement.jumpForcePower;
            await Task.Delay((int)speed);
            playerController.playerMovement.jumpForce = playerController.playerMovement.jumpForceDefault;
        }
        
        public async void MagnetMode(float speed)
        {
            CreateAura(magnetPrefab, speed);
            magnetMode = true;
            magnet.SetActive(true);
            await Task.Delay((int)speed);
            magnet.SetActive(false);
            magnetMode = false;
        }
        
        public async void GodMode(float speed)
        {
            CreateAura(godPrefab, speed);
            godMode = true;
            await Task.Delay((int)speed);
            godMode = false;
        }
        

        private void CreateAura(GameObject prefab, float speed)
        {
            GameObject aura = Instantiate(prefab, playerController.transform, true);
            aura.transform.position = playerController.transform.position;
            
            
            Destroy(aura, speed/1000);
        }
    }
}
