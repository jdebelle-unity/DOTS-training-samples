﻿using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct RoadInfo : IComponentData
{
    public float LaneWidth;
    public int MaxLanes;

    //Move this probably
    public float CarSpawningDistancePercent;
    
    public float MidRadius;
    public float StraightPieceLength;

    public int SegmentCount;
}

public struct LaneInfo
{
    public float Pivot;
    public float Radius;
    public float CurvedPieceLength;
    public float TotalLength;
}

// This describes the number of buffer elements that should be reserved
// in chunk data for each instance of a buffer. In this case, 16 integers
// will be reserved (64 bytes) along with the size of the buffer header
// (currently 16 bytes on 64-bit targets)
[InternalBufferCapacity(16)]
public struct LaneInfoElement : IBufferElementData
{
    // These implicit conversions are optional, but can help reduce typing.
    public static implicit operator LaneInfo(LaneInfoElement e) { return e.Value; }
    public static implicit operator LaneInfoElement(LaneInfo e) { return new LaneInfoElement { Value = e }; }

    // Actual value each buffer element will store.
    public LaneInfo Value;
}