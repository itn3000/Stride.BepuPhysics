﻿using Stride.BepuPhysics.Components.Colliders;
using Stride.Core.Annotations;
using Stride.Engine;

namespace Stride.BepuPhysics.Processors
{
    public class ColliderProcessor : EntityProcessor<ColliderComponent>
    {
        public ColliderProcessor()
        {
            Order = 10010;
        }

        protected override void OnEntityComponentAdding(Entity entity, [NotNull] ColliderComponent component, [NotNull] ColliderComponent data)
        {
            component.Container?.ContainerData?.RebuildContainer();
        }

        protected override void OnEntityComponentRemoved(Entity entity, [NotNull] ColliderComponent component, [NotNull] ColliderComponent data)
        {
            component.Container?.ContainerData?.RebuildContainer();
            component.Container = null;
        }
    }
}
