﻿// Drawer.cs
// Created by Holojam Inc. on 09.07.16

using UnityEngine;

namespace Holojam.Utility {

  /// <summary>
  /// Utility for extended gizmo drawing functions.
  /// </summary>
  public class Drawer : MonoBehaviour {

    const int circleResFactor = 128; // Quality factor for drawing circles

    public static void Circle(
      Vector3 position, Vector3 direction,
      Vector3 up, float radius = 0.1f
    ) {
      Vector3.Normalize(direction); Vector3.Normalize(up);
      // Approximate resolution based on radius
      int res = (int)(circleResFactor * Mathf.Sqrt(radius));

      float theta = 2 * Mathf.PI / res;
      Vector3 cache = Vector3.zero;

      for (int i = 0; i <= res; ++i) {
        Vector3 point =
           up * radius * Mathf.Sin(theta * i) +
           Vector3.Cross(direction, up) * radius * Mathf.Cos(theta * i) +
           position;
        if (i > 0) Gizmos.DrawLine(cache, point);
        cache = point;
      }
    }
  }
}
