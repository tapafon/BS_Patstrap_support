using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using CoreOSC;
using CoreOSC.IO;
using System.Net.Sockets;
using IPA.Config;
using IPA.Utilities;
using BS_Patstrap_support.Configuration;

namespace BS_Patstrap_support
{
    /// <summary>
    /// Monobehaviours (scripts) are added to GameObjects.
    /// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
    /// </summary>
    public class BS_Patstrap_supportController : MonoBehaviour
    {
        public static BS_Patstrap_supportController Instance { get; private set; }

        UdpClient patStrapServer;

        String ipAddress;

        Config config;

        bool iteration = true;

        // These methods are automatically called by Unity, you should remove any you aren't using.
        #region Monobehaviour Messages
        /// <summary>
        /// Only ever called once, mainly used to initialize variables.
        /// </summary>
        private void Awake()
        {
            // For this particular MonoBehaviour, we only want one instance to exist at any time, so store a reference to it in a static property
            //   and destroy any that are created while one already exists.
            if (Instance != null)
            {
                Plugin.Log?.Warn($"Instance of {GetType().Name} already exists, destroying.");
                GameObject.DestroyImmediate(this);
                return;
            }
            GameObject.DontDestroyOnLoad(this); // Don't destroy this object on scene changes
            Instance = this;
            Plugin.Log?.Debug($"{name}: Awake()");
            
        }
        /// <summary>
        /// Only ever called once on the first frame the script is Enabled. Start is called after any other script's Awake() and before Update().
        /// </summary>
        private void Start()
        {
            ipAddress = $"{PluginConfig.Instance.AddressOne}.{PluginConfig.Instance.AddressTwo}.{PluginConfig.Instance.AddressThree}.{PluginConfig.Instance.AddressFour}";
            Plugin.Log?.Info($"Read {ipAddress} from config.");
            patStrapServer = new UdpClient(ipAddress, 9001); //connecting to original PatStrap server
        }

        /// <summary>
        /// Called every frame if the script is enabled.
        /// </summary>
        private async void Update()
        {
            PlayerHeadAndObstacleInteraction[] obstacle = Resources.FindObjectsOfTypeAll<PlayerHeadAndObstacleInteraction>(); //find that component, no matter where
                Address pl = new Address("/avatar/parameters/pat_left");
                Address pr = new Address("/avatar/parameters/pat_right");
                Address pd = new Address("/avatar/parameters/dummy");
                float x;
                if (iteration) // "emulating" headpats for server
                    x = 0f;
                else
                    x = 1f;
                object[] obj = new object[] { x };

                var msg1 = new OscMessage(pl, obj);
                var msg2 = new OscMessage(pr, obj);
                var msg3 = new OscMessage(pd, obj);

                if (obstacle.Length > 0) //if it exists
                {
                    PlayerHeadAndObstacleInteraction wall = obstacle[0]; //another object
                    if (wall.playerHeadIsInObstacle) //reality check
                    {
                        //screw "3d effect", there's only one collider provided by BS
                        await patStrapServer.SendMessageAsync(msg1);
                        await patStrapServer.SendMessageAsync(msg2);
                        iteration = !iteration; //here, not each frame to avoid getting same values
                    }
                    else
                    {
                        await patStrapServer.SendMessageAsync(msg3); //dummy message to trick PatStrap server that VRC is working
                    }
                }
                else
                {
                    await patStrapServer.SendMessageAsync(msg3); //dummy message to trick PatStrap server that VRC is working
                }
        }
        /// <summary>
        /// Called when the script becomes disabled or when it is being destroyed.
        /// </summary>
        private void OnDisable()
        {
            patStrapServer.Close();
        }

        /// <summary>
        /// Called when the script is being destroyed.
        /// </summary>
        private void OnDestroy()
        {
            Plugin.Log?.Debug($"{name}: OnDestroy()");
            if (Instance == this)
                Instance = null; // This MonoBehaviour is being destroyed, so set the static instance property to null.

        }
        #endregion
    }
}
