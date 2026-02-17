using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public ProjectData() { }


        public string Id { get; set; }
        public string Name { get; set; }

        public ProjectData(string Name) { }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (Name == other.Name)
            {
                return true;
            }
            return Name == other.Name;

        }
        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int nameComparison = Name.CompareTo(other.Name);
            if (nameComparison != 0)
            {
                return nameComparison;
            }
            return Name.CompareTo(other.Name);
        }
    }
}

