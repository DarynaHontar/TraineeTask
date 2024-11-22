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
                    throw new ArgumentException(ErrorMessages.EmptyFirstName);
                }

                if (string.IsNullOrWhiteSpace(student.SecondName))
                {
                    throw new ArgumentException(ErrorMessages.EmptySecondName);
                }

                if (student.Age < Constants.MinAge || student.Age > Constants.MaxAge)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.InvalidAge, Constants.MinAge, Constants.MaxAge));
                }
            }

            // Student Id validation
            if (students.GroupBy(s => s.Id).Any(g => g.Count() > 1))
            {
                throw new InvalidOperationException(ErrorMessages.DuplicateStudentId);
            }
        }

        public static void ValidateSubjects(List<Subject> subjects)
        {
            // Subjects name, grade validation
            foreach (Subject subject in subjects)
            {
                if (string.IsNullOrWhiteSpace(subject.Name))
                {
                    throw new ArgumentException(ErrorMessages.EmptySubjectName);
                }

                if (subject.Grade < Constants.MinGrade || subject.Grade > Constants.MaxGrade)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.InvalidGrade, Constants.MinGrade, Constants.MaxGrade));
                }
            }

            // Subjects Id validation
            if (subjects.GroupBy(s => s.Id).Any(g => g.Count() > 1))
            {
                throw new InvalidOperationException(ErrorMessages.DuplicateSubjectId);
            }
        }
    }
}