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
        [SerializeField] private GameObject aura;

        private MeshRenderer auraMesh;
        private bool flicker;
        private float value = 0.1f;
        
        [Header("Jumping")] 
        public int jumpLength;
        public Material jumpMaterial;

        [Header("Coin Magnet")]
        public bool magnetMode;
        public int magnetLength;
        public Material magnetMaterial;
        public GameObject magnet;
        
        [Header("God Mode")] 
        public bool godMode;
        public int godModeLength;
        public Material godModeMaterial;
        
        private void Awake()
        {
            auraMesh = aura.GetComponent<MeshRenderer>();
            aura.SetActive(false);
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
            
            if (flicker)
            { 
                Color color = new Color();
                color = auraMesh.material.color;
                color.a -= value * Time.deltaTime;
                auraMesh.material.SetColor("_Color", color);
            }
        }

        public async void Jumping(float speed)
        {
            float j = playerController.playerMovement.jumpForce;
            playerController.playerMovement.jumpForce *= 2f;
            aura.SetActive(true);
            ChangeColour(jumpMaterial, speed);
            await Task.Delay((int)speed);
            aura.SetActive(false);
            flicker = false;
            playerController.playerMovement.jumpForce = j;
        }
        
        public async void MagnetMode(float speed)
        {
            magnetMode = true;
            aura.SetActive(true);
            magnet.SetActive(true);
            ChangeColour(magnetMaterial, speed);
            await Task.Delay((int)speed);
            aura.SetActive(false);
            magnet.SetActive(false);
            magnetMode = false;
            flicker = false;
        }
        
        public async void GodMode(float speed)
        {
            godMode = true;
            aura.SetActive(true);
            ChangeColour(godModeMaterial, speed);
            await Task.Delay((int)speed);
            aura.SetActive(false);
            godMode = false;
            flicker = false;
        }

        private async void ChangeColour(Material m, float speed)
        {
           auraMesh.material = m;
           await Task.Delay((int)speed-2000);
           flicker = true;
        }
    }
}
