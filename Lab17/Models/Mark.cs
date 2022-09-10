namespace Lab17.Models
{
    internal class Mark
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }


        public override string ToString() =>
            $"nota {Value} Course {CourseId} Student {StudentId}";

    }
}