﻿using System;
namespace TechJobsMVC.Models
{
    public class Job
    {

        public int Id { get; }
        static private int nextId = 1;

        public string Name { get; set; }
        public Employer Employer { get; set; }
        public Location Location { get; set; }
        public PositionType PositionType { get; set; }
        public CoreCompetency CoreCompetency { get; set; }

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employer, Location location, PositionType positionType, CoreCompetency coreCompetency) : this()
        {
            Name = name;
            Employer = employer;
            Location = location;
            PositionType = positionType;
            CoreCompetency = coreCompetency;
        }
        

        public override string ToString()
        {
            string output = "";
            if (Name.Equals(""))
            {
                Name = "Data not available";
            }
            if (Employer.Value.Equals("") || Employer.Value == null)
            {
                Employer.Value = "Data not available";
            }
            if (Location.Value.Equals("") || Location.Value == null)
            {
                Location.Value= "Data not available";
            }
            if (CoreCompetency.Value.Equals("") || CoreCompetency.Value == null)
            {
                CoreCompetency.Value = "Data not available";
            }
            if (PositionType.Value.Equals("") || PositionType.Value == null)
            {
                PositionType.Value = "Data not available";
            }

            output = string.Format("ID: {0}\n" +
                     "Name: {1}\n" +
                     "Employer: {2}\n" +
                     "Location: {3}\n" +
                     "Position Type: {4}\n" +
                     "Core Competency: {5}", Id, Name, Employer, Location, PositionType, CoreCompetency);
            return output;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
