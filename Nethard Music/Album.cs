﻿using System;

namespace Setchin.NethardMusic
{
    public class Album : IEquatable<Album>
    {
        private long _id;
        private string _name;

        public Album(long id, string name)
        {
            _id = id;
            _name = name;
        }

        public long Id { get { return _id; } }

        public string Name { get { return _name; } }

        public override bool Equals(object obj)
        {
            return Equals(obj as Album);
        }

        public bool Equals(Album other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}