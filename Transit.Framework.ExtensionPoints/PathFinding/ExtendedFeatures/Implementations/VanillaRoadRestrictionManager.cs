﻿using Transit.Framework.ExtensionPoints.PathFinding.ExtendedFeatures.Contracts;
using Transit.Framework.Network;

namespace Transit.Framework.ExtensionPoints.PathFinding.ExtendedFeatures.Implementations
{
    public class VanillaRoadRestrictionManager : IExtendedRoadRestrictionManager
    {
        public bool CanUseLane(uint laneId, ExtendedVehicleType vehicleType)
        {
            return true;
        }
    }
}