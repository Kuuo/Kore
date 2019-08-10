using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kore
{
    [System.Serializable]
    public class Waypoints : IReadOnlyList<Waypoints.Pose>
    {
        [System.Serializable]
        public class Pose
        {
            public Vector3 position;
            public Quaternion rotation;
        }

        public List<Pose> list;

        public int Count => ((IReadOnlyList<Pose>)list).Count;

        public Pose this[int index] => ((IReadOnlyList<Pose>)list)[index];

        public IEnumerator<Pose> Enumerator => ((IReadOnlyList<Pose>)list).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IReadOnlyList<Pose>)list).GetEnumerator();
        }

        public IEnumerator<Pose> GetEnumerator()
        {
            return ((IReadOnlyList<Pose>)list).GetEnumerator();
        }
    }
}
