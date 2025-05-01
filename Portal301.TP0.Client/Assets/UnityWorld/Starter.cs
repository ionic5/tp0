using Portal301.TP0.Client.Core;
using Portal301.TP0.Client.UnityWorld.View;
using System.Collections;
using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld
{
    public class Starter : MonoBehaviour
    {
        [SerializeField]
        private MainScene mainScene;

        // Use this for initialization
        void Start()
        {
            Destroy(gameObject);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}