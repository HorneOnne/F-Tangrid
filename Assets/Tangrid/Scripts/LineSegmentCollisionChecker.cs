using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tangrid
{
    public class LineSegmentCollisionChecker
    {    
        public static bool ArePairsIntersecting(Pair pairA, Pair pairB)
        {
            // Check if two line segments have one or more common points (share an endpoint)
            if (pairA.pointA == pairB.pointA || pairA.pointA == pairB.pointB || pairA.pointB == pairB.pointA || pairA.pointB == pairB.pointB)
            {
                // Calculate the direction vectors of the line segments
                Vector2 _AB = pairA.pointB.transform.position - pairA.pointA.transform.position;
                Vector2 _CD = pairB.pointB.transform.position - pairB.pointA.transform.position;

                // Calculate the angle between the two segments
                float angle = Vector2.Angle(_AB, _CD);
                float angleThreshold = 10f;
                if (angle > angleThreshold)
                {
                    return false;
                }
            }

            // Calculate the direction vectors of the line segments
            Vector2 AB = pairA.pointB.transform.position - pairA.pointA.transform.position;
            Vector2 CD = pairB.pointB.transform.position - pairB.pointA.transform.position;

            // Calculate the cross products
            float crossAB_CD = Vector3.Cross(AB, CD).z;
            float crossAC_AB = Vector3.Cross(pairB.pointA.transform.position - pairA.pointA.transform.position, AB).z;
            float crossAC_CD = Vector3.Cross(pairB.pointA.transform.position - pairA.pointA.transform.position, CD).z;

            // Check if the line segments are collinear (cross products are approximately zero)
            if (Mathf.Approximately(crossAB_CD, 0f) && Mathf.Approximately(crossAC_AB, 0f))
            {
                // Check if any of the endpoints of one segment lies on the other segment
                if (Vector2.Dot(pairB.pointA.transform.position - pairA.pointA.transform.position, AB) >= 0f && Vector2.Dot(pairB.pointA.transform.position - pairA.pointB.transform.position, AB) <= 0f)
                    return true;
                if (Vector2.Dot(pairA.pointA.transform.position - pairB.pointA.transform.position, CD) >= 0f && Vector2.Dot(pairA.pointA.transform.position - pairB.pointB.transform.position, CD) <= 0f)
                    return true;
            }
            // Check for proper intersection of two non-parallel segments
            else if (crossAB_CD != 0f)
            {
                float t = crossAC_CD / crossAB_CD;
                float u = crossAC_AB / crossAB_CD;

                if (t >= 0f && t <= 1f && u >= 0f && u <= 1f)
                    return true;
            }

            return false;
        }



        // Function to check if a line segment can collide with any line segment in the list
        public static bool AreCollisionsInPairs(Pair pair, List<Pair> lineSegments)
        {
            foreach (var segment in lineSegments)
            {
                if (segment == pair) continue;
                if (ArePairsIntersecting(pair, segment))
                {
                    // There's a collision between the given line segment and the segment in the list
                    // You can handle the collision here, e.g., return true or perform some action
                    return true;
                }
            }

            // No collisions found between the given line segment and the segments in the list
            return false;
        }
    }
}
