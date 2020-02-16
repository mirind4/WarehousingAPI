﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace KaliGasService.Core.Domain
{

    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastModifiedAt { get; set; }

        public ICollection<IDomainEvent> Events { get; } = new List<IDomainEvent>(); 
        
        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now; 
        }

        public void RaiseEvent(IDomainEvent @event)
        {
            Events.Add(@event);
        }

        public void ClearEvents()
        {
            Events.Clear();
        }

        public bool HasEvents()
        {
            return Events.Any();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (obj.GetType() != other.GetType())
                return false;

            if (Id == Guid.Empty || other.Id == Guid.Empty)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
