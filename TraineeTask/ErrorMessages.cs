namespace TraineeTask
{
    public static class ErrorMessages
    {
        public const string EmptyFirstName = "First name cannot be empty.";
        public const string EmptySecondName = "Second name cannot be empty.";
        public const string InvalidAge = "Age must be between {0} and {1}.";
        public const string DuplicateStudentId = "Duplicate student Id detected.";
        public const string DuplicateSubjectId = "Duplicate subject Id detected.";
        public const string EmptySubjectName = "Subject name cannot be empty.";
        public const string InvalidGrade = "Grade must be between {0} and {1}.";
        public const string AverageGradeError = "Cannot calculate average grade.";
        public const string NoSubjectsFoundForStudent = "No subjects found for student with Id {0}.";
        public const string EmptySubjectsList = "The list of subjects is empty.";
        public const string StudentNotFound = "Student with Id {0} not found.";
    }
}