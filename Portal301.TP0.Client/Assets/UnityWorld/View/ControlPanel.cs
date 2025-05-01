using Portal301.TP0.Client.Core.View;
using System.Collections.Generic;
using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld.View
{
    public class ControlPanel : MonoBehaviour, IControlPanel
    {
        [SerializeField]
        public List<JointPanel> JointPanels;

        public IJointPanel AddJointPanel()
        {
            foreach (var panel in JointPanels)
            {
                if (panel.gameObject.activeSelf)
                    continue;
                panel.gameObject.SetActive(true);
                return panel;
            }

            return null;
        }

        public void ClearJointPanels()
        {
            foreach (var panel in JointPanels)
            {
                panel.Clear();
                panel.gameObject.SetActive(false);
            }
        }
    }
}