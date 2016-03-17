﻿using Transit.Framework.Mod;
using Transit.Framework.Prerequisites;

namespace Transit.Mod
{
    public sealed partial class NetworkExtensions : TransitModBase
    {
        public override ulong WorkshopId
        {
            get { return 478820060; }
        }

        public override string Name
        {
            get { return "Network Extensions"; }
        }

        public override string Description
        {
            get { return "An addition of highways and roads"; }
        }

        public override string Version
        {
            get { return "1.0.0"; }
        }

        public override TransitModType Type
        {
            get { return TransitModType.Standalone; }
        }

        public override PrerequisiteType Requirements
        {
            get { return PrerequisiteType.NetworkAI | PrerequisiteType.UI; }
        }
    }
}
