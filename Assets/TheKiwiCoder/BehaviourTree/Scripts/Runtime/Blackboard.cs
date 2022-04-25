using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace TheKiwiCoder {

    // This is the blackboard container shared between all nodes.
    // Use this to store temporary data that multiple nodes need read and write access to.
    // Add other properties here that make sense for your specific use case.
    [System.Serializable]
    public class Blackboard {
        public bool spotted;
        public bool heard;
        public NavMeshAgent hider;
        public Transform memoryObject;
        public Transform noiseObject;
        public Vector3 moveToPosition;
        public Transform waypoint;
    }
}