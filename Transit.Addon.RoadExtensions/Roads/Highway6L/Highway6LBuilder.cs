﻿using System;
using System.Linq;
using Transit.Framework;
using Transit.Framework.Modularity;
using UnityEngine;

namespace Transit.Addon.RoadExtensions.Roads.Highway6L
{
    public class Highway6LBuilder : NetInfoBuilderBase, INetInfoBuilder, INetInfoModifier
    {
        public int Order { get { return 50; } }
        public int Priority { get { return 14; } }

        public string TemplatePrefabName { get { return NetInfos.Vanilla.ONEWAY_6L; } }
        public string Name { get { return "Large Highway"; } }
        public string DisplayName { get { return "Six-Lane Highway"; } }
        public string CodeName { get { return "HIGHWAY_6L"; } }
        public string Description { get { return "A six-lane, one-way road suitable for very high and dense traffic between metropolitan areas. Lanes going the opposite direction need to be built separately. Highway does not allow zoning next to it!"; } }
        public string UICategory { get { return "RoadsHighway"; } }

        public string ThumbnailsPath { get { return @"Roads\Highway6L\thumbnails.png"; } }
        public string InfoTooltipPath { get { return @"Roads\Highway6L\infotooltip.png"; } }

        public NetInfoVersion SupportedVersions
        {
            get { return NetInfoVersion.All; }
        }

        public void BuildUp(NetInfo info, NetInfoVersion version)
        {
            ///////////////////////////
            // Template              //
            ///////////////////////////
            var highwayInfo = Prefabs.Find<NetInfo>(NetInfos.Vanilla.HIGHWAY_3L);
            var defaultMaterial = highwayInfo.m_nodes[0].m_material;

            ///////////////////////////
            // 3DModeling            //
            ///////////////////////////
            if (version == NetInfoVersion.Ground)
            {
                info.m_surfaceLevel = 0;
                info.m_class = highwayInfo.m_class.Clone("NExtHighway");

                var segments0 = info.m_segments[0];
                var nodes0 = info.m_nodes[0];

                segments0.m_backwardForbidden = NetSegment.Flags.None;
                segments0.m_backwardRequired = NetSegment.Flags.None;

                segments0.m_forwardForbidden = NetSegment.Flags.None;
                segments0.m_forwardRequired = NetSegment.Flags.None;

                var nodes1 = nodes0.ShallowClone();

                nodes0.m_flagsForbidden = NetNode.Flags.Transition;
                nodes0.m_flagsRequired = NetNode.Flags.None;

                nodes1.m_flagsForbidden = NetNode.Flags.None;
                nodes1.m_flagsRequired = NetNode.Flags.Transition;

                segments0.SetMeshes
                    (@"Roads\Highway6L\Meshes\Ground.obj",
                     @"Roads\Highway6L\Meshes\Ground_LOD.obj");

                nodes0.SetMeshes
                    (@"Roads\Highway6L\Meshes\Ground.obj",
                     @"Roads\Highway6L\Meshes\Ground_Node_LOD.obj");

                nodes1.SetMeshes
                    (@"Roads\Highway6L\Meshes\Ground_Trans.obj",
                     @"Roads\Highway6L\Meshes\Ground_Trans_LOD.obj");

                info.m_segments = new[] { segments0 };
                info.m_nodes = new[] { nodes0, nodes1 };
                Framework.Debug.Log("REx: Ground Done");
            }
            else if (version == NetInfoVersion.Elevated)
            {
                info.m_surfaceLevel = 0;
                info.m_class = highwayInfo.m_class.Clone("NExtHighway");

                var segments0 = info.m_segments[0];
                var nodes0 = info.m_nodes[0];

                segments0.m_backwardForbidden = NetSegment.Flags.None;
                segments0.m_backwardRequired = NetSegment.Flags.None;

                segments0.m_forwardForbidden = NetSegment.Flags.None;
                segments0.m_forwardRequired = NetSegment.Flags.None;

                var nodes1 = nodes0.ShallowClone();

                nodes0.m_flagsForbidden = NetNode.Flags.Transition;
                nodes0.m_flagsRequired = NetNode.Flags.None;

                nodes1.m_flagsForbidden = NetNode.Flags.None;
                nodes1.m_flagsRequired = NetNode.Flags.Transition;

                segments0.SetMeshes
                    (@"Roads\Highway6L\Meshes\Elevated.obj",
                    @"Roads\Highway6L\Meshes\Elevated_LOD.obj");

                nodes0.SetMeshes
                    (@"Roads\Highway6L\Meshes\Elevated.obj",
                    @"Roads\Highway6L\Meshes\Elevated_Node_LOD.obj");

                nodes1.SetMeshes
                    (@"Roads\Highway6L\Meshes\Elevated_Trans.obj",
                    @"Roads\Highway6L\Meshes\Elevated_Trans_LOD.obj");

                info.m_segments = new[] { segments0 };
                info.m_nodes = new[] { nodes0, nodes1 };
                Framework.Debug.Log("REx: Elevated Done");
            }
            else if (version == NetInfoVersion.Bridge)
            {
                info.m_surfaceLevel = 0;
                info.m_class = highwayInfo.m_class.Clone("NExtHighway");

                var segments0 = info.m_segments[0];
                var segments1 = info.m_segments[1];
                var nodes0 = info.m_nodes[0];

                segments0.m_backwardForbidden = NetSegment.Flags.None;
                segments0.m_backwardRequired = NetSegment.Flags.None;

                segments0.m_forwardForbidden = NetSegment.Flags.None;
                segments0.m_forwardRequired = NetSegment.Flags.None;

                var nodes1 = nodes0.ShallowClone();

                nodes0.m_flagsForbidden = NetNode.Flags.Transition;
                nodes0.m_flagsRequired = NetNode.Flags.None;

                nodes1.m_flagsForbidden = NetNode.Flags.None;
                nodes1.m_flagsRequired = NetNode.Flags.Transition;

                segments0.SetMeshes
                    (@"Roads\Highway6L\Meshes\Elevated.obj",
                    @"Roads\Highway6L\Meshes\Elevated_LOD.obj");

                nodes0.SetMeshes
                    (@"Roads\Highway6L\Meshes\Elevated.obj",
                    @"Roads\Highway6L\Meshes\Elevated_Node_LOD.obj");

                nodes1.SetMeshes
                    (@"Roads\Highway6L\Meshes\Elevated_Trans.obj",
                    @"Roads\Highway6L\Meshes\Elevated_Trans_LOD.obj");

                info.m_segments = new[] { segments0, segments1 };
                info.m_nodes = new[] { nodes0, nodes1 };
                Framework.Debug.Log("REx: Bridge Done Done");
            }
            else if (version == NetInfoVersion.Slope)
            {
                info.m_surfaceLevel = 0;
                info.m_class = highwayInfo.m_class.Clone("NExtHighway");

                var segments0 = info.m_segments[0];
                var segments1 = info.m_segments[1];
                var segments2 = segments1.ShallowClone();
                var nodes0 = info.m_nodes[0];
                var nodes1 = info.m_nodes[1];
                var nodes2 = nodes0.ShallowClone();
                var nodes3 = nodes1.ShallowClone();

                segments0.m_backwardForbidden = NetSegment.Flags.None;
                segments0.m_backwardRequired = NetSegment.Flags.None;

                segments0.m_forwardForbidden = NetSegment.Flags.None;
                segments0.m_forwardRequired = NetSegment.Flags.None;

                segments1.m_backwardForbidden = NetSegment.Flags.None;
                segments1.m_backwardRequired = NetSegment.Flags.None;

                segments1.m_forwardForbidden = NetSegment.Flags.None;
                segments1.m_forwardRequired = NetSegment.Flags.None;

                segments2.m_backwardForbidden = NetSegment.Flags.None;
                segments2.m_backwardRequired = NetSegment.Flags.None;

                segments2.m_forwardForbidden = NetSegment.Flags.None;
                segments2.m_forwardRequired = NetSegment.Flags.None;

                //nodes0.m_flagsForbidden = NetNode.Flags.Transition;
                //nodes0.m_flagsRequired = NetNode.Flags.Underground;

                nodes1.m_flagsForbidden = NetNode.Flags.UndergroundTransition;
                nodes1.m_flagsRequired = NetNode.Flags.None;

                //nodes2.m_flagsForbidden = NetNode.Flags.None;
                //nodes2.m_flagsRequired = NetNode.Flags.UndergroundTransition;

                //nodes3.m_flagsForbidden = NetNode.Flags.Underground;
                //nodes3.m_flagsRequired = NetNode.Flags.Transition;

                segments0.SetMeshes
                    (@"Roads\Highway6L\Meshes\Slope_Gray.obj",
                     @"Roads\Highway6L\Meshes\Slope_Gray_LOD.obj");
                segments2.SetMeshes
                    (@"Roads\Highway6L\Meshes\Slope.obj",
                     @"Roads\Highway6L\Meshes\Slope_LOD.obj");

                nodes0.SetMeshes
                    (@"Roads\Highway6L\Meshes\Slope_U_Node.obj",
                     @"Roads\Highway6L\Meshes\Ground_LOD.obj");
                nodes1.SetMeshes
                    (@"Roads\Highway6L\Meshes\Ground.obj",
                    @"Roads\Highway6L\Meshes\Ground_Node_LOD.obj");
                nodes2.SetMeshes
                    (@"Roads\Highway6L\Meshes\Slope_U_Node.obj");
                nodes3.SetMeshes
                    (@"Roads\Highway6L\Meshes\Ground_Trans.obj",
                     @"Roads\Highway6L\Meshes\Ground_Trans_LOD.obj");

                nodes2.m_material = defaultMaterial;

                info.m_segments = new[] { segments0, segments1, segments2 };
                info.m_nodes = new[] { nodes0, nodes1, nodes2, nodes3 };
                Framework.Debug.Log("REx: Slope Done");
            }
            else if (version == NetInfoVersion.Tunnel)
            {
                var segments0 = info.m_segments[0];
                var segments1 = segments0.ShallowClone();
                var nodes0 = info.m_nodes[0];
                var nodes1 = nodes0.ShallowClone();
                //var nodes2 = nodes1.ShallowClone();

                //segments1.m_backwardForbidden = NetSegment.Flags.None;
                //segments1.m_backwardRequired = NetSegment.Flags.None;

                //segments1.m_forwardForbidden = NetSegment.Flags.None;
                //segments1.m_forwardRequired = NetSegment.Flags.None;

                //nodes1.m_flagsForbidden = NetNode.Flags.Transition;
                //nodes1.m_flagsRequired = NetNode.Flags.Underground;

                //nodes2.m_flagsForbidden = NetNode.Flags.None;
                // nodes2.m_flagsRequired = NetNode.Flags.UndergroundTransition;

                segments0.SetMeshes
                    (@"Roads\Highway6L\Meshes\Tunnel.obj",
                    @"Roads\Highway6L\Meshes\Tunnel_LOD.obj");
                segments1.SetMeshes
                    (@"Roads\Highway6L\Meshes\Tunnel.obj",
                    @"Roads\Highway6L\Meshes\Tunnel_LOD.obj");
                nodes0.SetMeshes
                     (@"Roads\Highway6L\Meshes\Tunnel.obj");
                nodes1.SetMeshes
                    (@"Roads\Highway6L\Meshes\Tunnel.obj");
                // nodes2.SetMeshes
                //    (@"Roads\Highway6L\Meshes\Tunnel.obj",
                //    @"Roads\Highway6L\Meshes\Ground_LOD.obj");

                segments1.m_material = defaultMaterial;
                nodes1.m_material = defaultMaterial;
                //nodes2.m_material = defaultMaterial;

                segments1.m_surfaceMapping = new UnityEngine.Vector4(0, 0, 0, 0);
                nodes1.m_surfaceMapping = new UnityEngine.Vector4(0, 0, 0, 0);
                //nodes2.m_surfaceMapping = new UnityEngine.Vector4(0, 0, 0, 0);

                info.m_segments = new[] { segments0, segments1 };
                info.m_nodes = new[] { nodes0, nodes1 };
                Framework.Debug.Log("REx: Tunnel Done");
            }

            ///////////////////////////
            // Texturing             //
            ///////////////////////////
            switch (version)
            {
                case NetInfoVersion.Ground:
                case NetInfoVersion.Elevated:
                case NetInfoVersion.Bridge:
                    info.SetAllSegmentsTexture(
                        new TexturesSet(
                            @"Roads\Highway6L\Textures\Ground_Elevated_Segment__MainTex.png",
                            @"Roads\Highway6L\Textures\Ground_Elevated_Segment__APRMap.png"),
                        new TexturesSet
                           (@"Roads\Highway6L\Textures\Ground_Elevated_SegmentLOD__MainTex.png",
                            @"Roads\Highway6L\Textures\Ground_Elevated_SegmentLOD__APRMap.png",
                            @"Roads\Highway6L\Textures\Elevated_NodeLOD__XYSMap.png"));
                    info.SetAllNodesTexture(
                        new TexturesSet
                           (@"Roads\Highway6L\Textures\Ground_Elevated_Node__MainTex.png",
                            @"Roads\Highway6L\Textures\Ground_Elevated_Node__APRMap.png"),
                        new TexturesSet
                           (@"Roads\Highway6L\Textures\Ground_Elevated_NodeLOD__MainTex.png",
                            @"Roads\Highway6L\Textures\Ground_Elevated_NodeLOD__APRMap.png",
                            @"Roads\Highway6L\Textures\Elevated_NodeLOD__XYSMap.png"));
                    break;

                case NetInfoVersion.Slope:
                    info.SetAllSegmentsTexture(
                        new TexturesSet
                           (@"Roads\Highway6L\Textures\Slope_Segment__MainTex.png",
                            @"Roads\Highway6L\Textures\Slope_Segment_Open__APRMap.png"));
                        //new TexturesSet
                        //    (@"Roads\Highway6L\Textures\Slope_SegmentLOD__MainTex.png",
                        //    @"Roads\Highway6L\Textures\Slope_Segment_OpenLOD__APRMap.png",
                        //    @"Roads\Highway6L\Textures\Slope_NodeLOD__XYSMap.png"));
                    info.SetAllNodesTexture(
                        new TexturesSet
                           (@"Roads\Highway6L\Textures\Slope_Node__MainTex.png",
                            @"Roads\Highway6L\Textures\Slope_Node__APRMap.png"),
                        new TexturesSet
                           (@"Roads\Highway6L\Textures\Slope_NodeLOD__MainTex.png",
                            @"Roads\Highway6L\Textures\Slope_NodeLOD__APRMap.png",
                            @"Roads\Highway6L\Textures\Slope_NodeLOD__XYSMap.png"));
                    break;
                case NetInfoVersion.Tunnel:
                    info.SetAllSegmentsTexture(
                        new TexturesSet
                           (@"Roads\Highway6L\Textures\Tunnel_Segment__MainTex.png",
                            @"Roads\Highway6L\Textures\Tunnel_Segment__APRMap.png"));
                        //new TexturesSet
                        //   (@"Roads\Highway6L\Textures\Tunnel_SegmentLOD__MainTex.png",
                        //    @"Roads\Highway6L\Textures\Tunnel_SegmentLOD__APRMap.png",
                        //    @"Roads\Highway6L\Textures\Slope_NodeLOD__XYSMap.png"));
                    info.SetAllNodesTexture(
                        new TexturesSet
                           (@"Roads\Highway6L\Textures\Tunnel_Node__MainTex.png",
                            @"Roads\Highway6L\Textures\Tunnel_Segment__APRMap.png"),
                        new TexturesSet
                           (@"Roads\Highway6L\Textures\Tunnel_NodeLOD__MainTex.png",
                            @"Roads\Highway6L\Textures\Tunnel_SegmentLOD__APRMap.png",
                            @"Roads\Highway6L\Textures\Slope_NodeLOD__XYSMap.png"));
                    break;
            }

            ///////////////////////////
            // Set up                //
            ///////////////////////////
            info.m_setVehicleFlags = Vehicle.Flags.None;
            info.m_availableIn = ItemClass.Availability.All;
            info.m_surfaceLevel = 0;
            info.m_createPavement = false; //(version == NetInfoVersion.Slope);
            info.m_createGravel = !(version == NetInfoVersion.Tunnel);
            info.m_averageVehicleLaneSpeed = 2f;
            info.m_hasParkingSpaces = false;
            info.m_hasPedestrianLanes = false;
            info.m_halfWidth = version == NetInfoVersion.Elevated || version == NetInfoVersion.Bridge ? 14 : 16;
            info.m_UnlockMilestone = highwayInfo.m_UnlockMilestone;
            info.m_pavementWidth = 2;
            // Disabling Parkings and Peds
            foreach (var l in info.m_lanes)
            {
                switch (l.m_laneType)
                {
                    case NetInfo.LaneType.Parking:
                        l.m_laneType = NetInfo.LaneType.None;
                        break;
                    case NetInfo.LaneType.Pedestrian:
                        l.m_laneType = NetInfo.LaneType.None;
                        break;
                }
            }
            // Setting up lanes
            var vehicleLanes = info.m_lanes
                .Where(l => l.m_laneType != NetInfo.LaneType.None)
                .OrderBy(l => l.m_similarLaneIndex)
                .ToArray();

            var propLanes = info.m_lanes
                .Where(l => l.m_laneType == NetInfo.LaneType.None)
                .OrderBy(l => l.m_similarLaneIndex)
                .ToArray();

            var nbLanes = vehicleLanes.Count();

            const float laneWidth = 4f;
            var positionStart = (laneWidth * ((1f - nbLanes) / 2f));

            for (int i = 0; i < vehicleLanes.Length; i++)
            {
                var l = vehicleLanes[i];
                l.m_allowStop = false;
                l.m_speedLimit = 2f;
                l.m_direction = NetInfo.Direction.Forward;
                l.m_finalDirection = NetInfo.Direction.Forward;
                l.m_verticalOffset = 0f;
                l.m_width = laneWidth;
                l.m_position = positionStart + i * laneWidth;
            }
            var hwPlayerNetAI = highwayInfo.GetComponent<PlayerNetAI>();
            var playerNetAI = info.GetComponent<PlayerNetAI>();

            if (hwPlayerNetAI != null && playerNetAI != null)
            {
                playerNetAI.m_constructionCost = hwPlayerNetAI.m_constructionCost * 2;
                playerNetAI.m_maintenanceCost = hwPlayerNetAI.m_maintenanceCost * 2;
            }

            var roadBaseAI = info.GetComponent<RoadBaseAI>();

            if (roadBaseAI != null)
            {
                roadBaseAI.m_highwayRules = true;
                roadBaseAI.m_trafficLights = false;
            }

            var roadAI = info.GetComponent<RoadAI>();

            if (roadAI != null)
            {
                roadAI.m_enableZoning = false;
            }

            info.SetHighwayProps(highwayInfo);
            info.TrimHighwayProps();

            //Setting up props
            NetInfo.Lane leftHwLane = null;
            NetInfo.Lane rightHwLane = null;
            if (version == NetInfoVersion.Tunnel)
            {
                var counter = 0;
                for (var i = 0; i < info.m_lanes.Length; i++)
                {
                    if (info.m_lanes[i].m_laneType == NetInfo.LaneType.None && counter == 0)
                    {
                        counter++;
                        leftHwLane = info.m_lanes[i];
                    }
                    else if (info.m_lanes[i].m_laneType == NetInfo.LaneType.None && counter == 1)
                    {
                        rightHwLane = info.m_lanes[i];
                    }
                    else
                    {
                        info.m_lanes[i].m_laneProps = highwayInfo.m_lanes.Where(l => l.m_laneType == NetInfo.LaneType.Vehicle).First().m_laneProps.ShallowClone();
                    }
                }
                if (leftHwLane != null)
                {
                    leftHwLane.m_laneProps = new NetLaneProps();
                    var newProps = ScriptableObject.CreateInstance<NetLaneProps>();
                    newProps.name = "Highway6L Left Props";

                    newProps.m_props = highwayInfo
                        .m_lanes
                        .Where(l => l != null && l.m_laneProps != null && l.m_laneProps.name != null && l.m_laneProps.m_props != null)
                        .FirstOrDefault(l => l.m_laneProps.name.ToLower().Contains("left"))
                        .m_laneProps
                        .m_props
                        .Select(p => p.ShallowClone())
                        .ToArray();

                    leftHwLane.m_laneProps = newProps;
                }
                if (rightHwLane != null)
                {
                    rightHwLane.m_laneProps = new NetLaneProps();
                    var newProps = ScriptableObject.CreateInstance<NetLaneProps>();
                    newProps.name = "Highway6L Right Props";

                    newProps.m_props = highwayInfo
                        .m_lanes
                        .Where(l => l != null && l.m_laneProps != null && l.m_laneProps.name != null && l.m_laneProps.m_props != null)
                        .FirstOrDefault(l => l.m_laneProps.name.ToLower().Contains("right"))
                        .m_laneProps
                        .m_props
                        .Select(p => p.ShallowClone())
                        .ToArray();

                    rightHwLane.m_laneProps = newProps;
                    Framework.Debug.Log("REx: Tunnel Props Initialized Done");
                }
            }
            else
            {
                leftHwLane = info
                   .m_lanes
                   .Where(l => l != null && l.m_laneProps != null && l.m_laneProps.name != null && l.m_laneProps.m_props != null)
                   .FirstOrDefault(l => l.m_laneProps.name.ToLower().Contains("left")).ShallowClone();

                rightHwLane = info
                  .m_lanes
                  .Where(l => l != null && l.m_laneProps != null && l.m_laneProps.name != null && l.m_laneProps.m_props != null)
                  .FirstOrDefault(l => l.m_laneProps.name.ToLower().Contains("right")).ShallowClone();
                Framework.Debug.Log("REx: Other Props Initialized Done");
            }

            if (leftHwLane != null && rightHwLane != null)
            {
                var leftHwProps = leftHwLane.m_laneProps.m_props.ToList();
                var rightHwProps = rightHwLane.m_laneProps.m_props.ToList();

                var wallLightProp = new NetLaneProps.Prop();
                var wallLightPropInfo = Prefabs.Find<PropInfo>("Wall Light Orange",false);
                var streetLightPropInfo = Prefabs.Find<PropInfo>("New Street Light",false);

                NetLaneProps.Prop streetLightLeft = null;
                NetLaneProps.Prop streetLightRight = null;

                foreach (var prop in rightHwLane.m_laneProps.m_props)
                {
                    if (prop != null && prop.m_prop != null && prop.m_prop.name != null && prop.m_prop.name.Contains("New Street Light"))
                    {
                        streetLightRight = prop;
                        streetLightLeft = prop.ShallowClone();
                        break;
                    }
                }

                if (streetLightLeft != null && streetLightRight != null)
                {
                    streetLightLeft.m_angle = 180;
                    if (version == NetInfoVersion.Tunnel)
                    {
                        streetLightLeft.m_repeatDistance = 40;
                        streetLightRight.m_repeatDistance = 40;

                        streetLightLeft.m_segmentOffset = 0;
                        streetLightRight.m_segmentOffset = 0;

                        streetLightLeft.m_position = new UnityEngine.Vector3(-3.2f, -4.5f, 20);
                        streetLightRight.m_position = new UnityEngine.Vector3(3.2f, -4.5f, 0);

                        //extra strength lighting (x2)
                        leftHwProps.Add(streetLightLeft);
                        leftHwProps.Add(streetLightLeft);

                        rightHwProps.Add(streetLightRight);
                        Framework.Debug.Log("REx: Tunnel Props set");
                    }
                    else if (version == NetInfoVersion.Slope)
                    {
                        wallLightProp.m_prop = wallLightPropInfo.ShallowClone();
                        wallLightProp.m_finalProp = wallLightPropInfo.ShallowClone();
                        wallLightProp.m_probability = 100;
                        wallLightProp.m_repeatDistance = 10;
                        wallLightProp.m_segmentOffset = 0;
                        wallLightProp.m_prop.m_effects[0].m_direction = new UnityEngine.Vector3(0, -90, 25);
                        wallLightProp.m_finalProp.m_effects[0].m_direction = new UnityEngine.Vector3(0, -90, 25);
                        var wallLightPropLeft = wallLightProp.ShallowClone();
                        var wallLightPropRight = wallLightProp.ShallowClone();
                        wallLightPropLeft.m_angle = 270;
                        wallLightPropRight.m_angle = 90;
                        wallLightPropLeft.m_position = new UnityEngine.Vector3(-2, 1.5f, 0);
                        wallLightPropRight.m_position = new UnityEngine.Vector3(2, 1.5f, 0);

                        streetLightLeft.m_repeatDistance = 80;
                        streetLightRight.m_repeatDistance = 80;
                        streetLightLeft.m_segmentOffset = 0;
                        streetLightRight.m_segmentOffset = 0;
                        streetLightLeft.m_position = new UnityEngine.Vector3(-1, 0, 0);
                        streetLightRight.m_position = new UnityEngine.Vector3(1, 0, 0);


                        leftHwProps.Add(streetLightLeft);
                        leftHwProps.Add(streetLightLeft);
                        leftHwProps.Add(wallLightPropLeft);

                        rightHwProps.Add(streetLightRight);
                        rightHwProps.Add(wallLightPropRight);
                        Framework.Debug.Log("REx: Slope Props set");
                    }
                    else
                    {
                        streetLightRight.m_repeatDistance = 80;
                        streetLightLeft.m_repeatDistance = 80;

                        streetLightLeft.m_segmentOffset = 40;

                        if (version == NetInfoVersion.Bridge || version == NetInfoVersion.Elevated)
                        {
                            streetLightLeft.m_position = new UnityEngine.Vector3(-1.75f, 0, 0);
                            streetLightRight.m_position = new UnityEngine.Vector3(1.75f, 0, 0);
                        }
                        else
                        {
                            streetLightLeft.m_position = new UnityEngine.Vector3(-1, 0, 0);
                            streetLightRight.m_position = new UnityEngine.Vector3(1, 0, 0);
                        }

                        leftHwProps.Add(streetLightLeft);
                        Framework.Debug.Log("REx: Other Props set");
                    }
                }

                leftHwLane.m_laneProps.m_props = leftHwProps.ToArray();
                rightHwLane.m_laneProps.m_props = rightHwProps.ToArray();
                Framework.Debug.Log("REx: Props Added");

                foreach (var lane in vehicleLanes)
                {
                    if (lane.m_laneProps != null && lane.m_laneProps.m_props.Length > 0)
                    {
                        foreach (var prop in lane.m_laneProps.m_props)
                        {
                            prop.m_position = new UnityEngine.Vector3(0, 0, 0);
                        }
                    }
                }
                Framework.Debug.Log("REx: Vehicle Props Centered");
                foreach (var lane in propLanes)
                {
                    if (lane.m_laneProps != null && lane.m_laneProps.m_props.Length > 0)
                    {
                        foreach (var prop in lane.m_laneProps.m_props)
                        {
                            var propName = prop.m_prop.name;
                            var positionMultiplier = lane.m_position / Math.Abs(lane.m_position);
                            if (!propName.Contains(streetLightPropInfo.name) && propName != wallLightPropInfo.name)
                            {
                                prop.m_position.x = positionMultiplier * 1.2f;
                            }
                        }
                    }
                }
                Framework.Debug.Log("REx: Proplane Props Centered");
            }
        }

        public void ModifyExistingNetInfo()
        {
            var highwayRampInfo = Prefabs.Find<PropInfo>("HighwayRamp",false);
            if (highwayRampInfo != null)
            {
                highwayRampInfo.m_UIPriority = highwayRampInfo.m_UIPriority + 1;
            }
        }
    }
}
