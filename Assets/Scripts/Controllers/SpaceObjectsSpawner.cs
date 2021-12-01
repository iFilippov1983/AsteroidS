using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AsteroidS
{
    public class SpaceObjectsSpawner
    {
        private Dictionary<SpaceObjectType, SpaceObject> _spaceObjects;
        private SpaceObjectBuilder _builder;

        public SpaceObjectsSpawner(GameData gameData)
        {
            _spaceObjects = gameData.SpaceObjectsData.SpaceObjectsPrefabsDictionary;
            _builder = new SpaceObjectBuilder();
        }

        public Stack<SpaceObject> SpawnAllSpaceObjects()
        {
            var stack = new Stack<SpaceObject>();

            for (int typeIndex = 1; typeIndex <= _spaceObjects.Count; typeIndex++)
            {
                var spaceObjectType = (SpaceObjectType)typeIndex;
                var prefab = _spaceObjects[spaceObjectType];
                var amount = prefab.GetSpaceObjectProperties.amountOnScene;

                for (int index = 0; index < amount ; index++)
                {
                    var obj = Spawn(spaceObjectType);
                    stack.Push(obj);
                }
            }

            return stack;
        }

        public SpaceObject Spawn(SpaceObjectType type)
        {
            var prefab = _spaceObjects[type];

            var spaceObject = _builder
                                .MakeInstance(prefab)
                                .SetPosition(CalculateRandomPosition())
                                .SetObjectView(prefab.GetSprites)
                                .SetRandomRotation()
                                .Get();

            return spaceObject;
        }

        private Vector3 CalculateRandomPosition()
        {
            return Vector3.zero;
        }
    }
}
