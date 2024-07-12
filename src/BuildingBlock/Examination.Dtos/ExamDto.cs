using Examination.Dtos.Enums;
using System;

namespace Examination.Dtos
{
    public class ExamDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ShortDes { get; set; }

        public int NumberOfQuestion { get; set; }

        public TimeSpan? Duration { get; set; }

        public Level Level { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
