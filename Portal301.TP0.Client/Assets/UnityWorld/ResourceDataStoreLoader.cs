using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld
{
    public class ResourceDataStoreLoader : MonoBehaviour
    {
        [SerializeField]
        private string rootPath;

        public ReadCsvAction ReadCsvAction;

        public void Load(ResourceDataStore resourceDataStore)
        {
            ReadCsvAction.Invoke($"{rootPath}/URRobot", (reader) =>
            {
                var row = new ResourceData.URRobot();
                row.URRobotID = reader.GetField("urRobotID");
                row.Path = reader.GetField("path");
                resourceDataStore.URRobots.Add(row);
            });
        }
    }
}