namespace TraineeTask
{
    public class Student
    {
        public Student(int id, string firstName, string secondName, int age)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
            Age = age;
        }

        public int Id { get; set; }

        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public int Age { get; private set; }

        public List<Subject> Subjects { get; private set; } = new List<Subject>();

        public double AverageGrade { get; private set; }

        public Grant Grant { get; private set; }

        // Creating student list
        public static List<Student> Fill(string path)
        {
            List<Student> students = JsonLoader.LoadFromJson<Student>(path);
            Validator.ValidateStudents(students);
            return students;
        }

        // Completing subjects for a student
        public bool SetSubjects(List<Subject> subjectsList)
        {
            var studentSubjects = subjectsList.Where(s => s.StudentId == Id).ToList();
            if (!studentSubjects.Any())
            {
                Console.WriteLine($"No subjects found for student with Id {Id}.");
                return false;
            }

            Subjects = studentSubjects;
            return true;
        }

        // Calculating average grade
        public void CalculateAverageGrade()
        {
            AverageGrade = Subjects.Count > 0
                ? Math.Round(Subjects.Average(s => s.Grade), 2)
                : throw new InvalidOperationException("Cannot calculate average grade.");
        }

        // Setting grant
        public void SetGrant()
        {
            Grant = AverageGrade switch
            {
                < 60 => Grant.None,
                < 90 => Grant.Regular,
                _ => Grant.Increased
            };
        }
    }
}