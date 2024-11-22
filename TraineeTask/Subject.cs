namespace TraineeTask
{
    public class Subject
    {
        public Subject(int id, string name, int studentId, int grade, DateTime date)
        {
            Id = id;
            Name = name;
            StudentId = studentId;
            Grade = grade;
            Date = date;
        }

        public int Id { get; set; }

        public string Name { get; private set; }

        public int StudentId { get; set; }

        public int Grade { get; private set; }

        public DateTime Date { get; set; }

        // Creating a list of Subject class objects
        public static List<Subject> Fill(string path)
        {
            List<Subject> subjects = JsonLoader.LoadFromJson<Subject>(path);
            Validator.ValidateSubjects(subjects);
            return subjects;
        }

        // Obtaining a list of subjects of a particular student
        public static List<Subject> GetByStudentId(List<Subject> subjectList, int studentId)
        {
            var studentSubjects = subjectList.Where(s => s.StudentId == studentId).ToList();
            if (!studentSubjects.Any())
            {
                throw new InvalidOperationException(string.Format(ErrorMessages.NoSubjectsFoundForStudent, studentId));
            }

            return studentSubjects;
        }
    }
}