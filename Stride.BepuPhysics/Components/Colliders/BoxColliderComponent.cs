﻿using BepuPhysics;
using BepuPhysics.Collidables;
using Stride.BepuPhysics.Processors;
using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Engine.Design;
using Stride.Games;

namespace Stride.BepuPhysics.Components.Colliders
{
    [DataContract]
    [DefaultEntityComponentProcessor(typeof(ColliderProcessor), ExecutionMode = ExecutionMode.Runtime)]
    [ComponentCategory("Bepu - Colliders")]
    public sealed class BoxColliderComponent : ColliderComponent
    {
        private Vector3 _size = new(1, 1, 1);

        public Vector3 Size
        {
            get => _size;
            set
            {
                _size = value;
                Container?.ContainerData?.TryUpdateContainer();
            }
        }

        internal override void AddToCompoundBuilder(IGame game, ref CompoundBuilder builder, RigidPose localPose)
        {
            builder.Add(new Box(Size.X, Size.Y, Size.Z), localPose, Mass);
        }
    }
}
