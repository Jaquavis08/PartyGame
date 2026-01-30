using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

    public class HereToThere : MonoBehaviour
    {
        public List<GameObject> waypoints;
        public List<GameObject> alternateWaypoints;
        public GameObject buttonObject;
        public float speed = 2;
        int index = 0;
        bool usingAlternate = false;

        private List<GameObject> activeWaypoints => usingAlternate ? alternateWaypoints : waypoints;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        private void Update()
        {
            // Check for button press
            if (buttonObject != null)
            {
               // CheckForButtonPress();
            }

            var list = activeWaypoints;
            if (list == null || list.Count == 0)
            {
                return;
            }

            if (index < 0) index = 0;
            if (index >= list.Count) index = list.Count - 1;

            Vector2 destination = list[index].transform.position;
            Vector2 newPos = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPos;

            float distance = Vector2.Distance(transform.position, destination);
            if (distance <= 0.05f)
            {
                if (index < list.Count - 1)
                {
                    index++;
                }
            }
        }

        // alternate waypoint
        public void StartAlternatePath()
        {
            if (alternateWaypoints == null || alternateWaypoints.Count == 0)
            {
                Debug.LogWarning("Alternate waypoints not set or empty.");
                return;
            }

            usingAlternate = true;
            index = 0;
        }

    }
