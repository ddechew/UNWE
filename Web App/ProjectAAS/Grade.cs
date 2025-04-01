using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAAS
{
    public class Grade
    {
        private int fNumber;
        private int subjectId;
        private int finalGrade;

        public int FNumber { get { return fNumber; } set { fNumber = value; } }

        public int SubjectId { get { return subjectId; } set { subjectId = value; } }

        public int FinalGrade { get { return finalGrade; } set { finalGrade = value; } }
    }
}