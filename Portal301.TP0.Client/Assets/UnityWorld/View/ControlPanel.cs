using Portal301.TP0.Client.Core.View;
using System.Collections.Generic;

namespace Portal301.TP0.Client.UnityWorld.View
{
    public class ControlPanel : IControlPanel
    {
        public readonly List<JointPanel> JointPanels;

        public ControlPanel(List<JointPanel> jointPanels)
        {
            JointPanels = jointPanels;
        }

        public IJointPanel AddJointPanel()
        {
            foreach (var panel in JointPanels)
            {
                if (panel.IsActive)
                    continue;
                panel.SetActive(true);
                return panel;
            }

            return null;
        }

        public void ClearJointPanels()
        {
            foreach (var panel in JointPanels)
            {
                panel.Clear();
                panel.SetActive(false);
            }
        }
    }
}