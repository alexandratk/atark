using System.Collections.Generic;
using System;
namespace PersonalityIdentification.DataContext
{
    public class Pupil : User
    {
        public Pupil()
        {
            MovingPupils = new List<MovingPupil>();
            PupilParents = new List<PupilParent>();
        }
        
        public Group Group { get; set; }
        public IList<MovingPupil> MovingPupils { get; set; }
        public IList<PupilParent> PupilParents { get; set; }
        public List<Mark> Marks { get; set; }
    }
}