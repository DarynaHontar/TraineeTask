namespace TraineeTask
{
    public static class Validator
    {
        public static void ValidateStudents(List<Student> students)
        {
            // Student full name, age validation
            foreach (Student student in students)
            {
                if (string.IsNullOrWhiteSpace(student.FirstName))
                {
                    throw new ArgumentException($"First name cannot be empty.");
                }

                if (string.IsNullOrWhiteSpace(student.SecondName))
                {
                    throw new ArgumentException($"Second name cannot be empty.");
                }

                if (student.Age < Constants.MinAge || student.Age > Constants.MaxAge)
                {
                    throw new ArgumentException($"Age must be between {Constants.MinAge} and {Constants.MaxAge}.");
                }
            }

            // Student Id validation
            if (students.GroupBy(s => s.Id).Any(g => g.Count() > 1))
            {
                throw new InvalidOperationException("Duplicate student Id detected.");
            }
        }

        public static void ValidateSubjects(List<Subject> subjects)
        {
            // Subjects name, grade validation
            foreach (Subject subject in subjects)
            {
                if (string.IsNullOrWhiteSpace(subject.Name))
                {
                    throw new ArgumentException("Subject name cannot be empty.");
                }

                if (subject.Grade < Constants.MinGrade || subject.Grade > Constants.MaxGrade)
                {
                    throw new ArgumentException($"Grade must be between {Constants.MinGrade} and {Constants.MaxGrade}.");
                }
            }

            // Subjects Id validation
            if (subjects.GroupBy(s => s.Id).Any(g => g.Count() > 1))
            {
                throw new InvalidOperationException("Duplicate subject Id detected.");
            }
        }
    }
}