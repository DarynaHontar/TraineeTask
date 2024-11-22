using System.Text;

namespace TraineeTask
{
    public static class DisplayService
    {
        public static void DisplayInfo(List<Student> students, int studentId)
        {
            Student selectedStudent = students.FirstOrDefault(s => s.Id == studentId);

            if (selectedStudent == null)
            {
                Console.WriteLine(string.Format(ErrorMessages.StudentNotFound, studentId));
                return;
            }

            string studentInfo = GetStudentInfo(selectedStudent);
            string subjectsInfo = GetSubjectInfo(selectedStudent.Subjects);
            Console.WriteLine(studentInfo + subjectsInfo);
        }

        private static string GetStudentInfo(Student student)
        {
            return $"Student:\nId: {student.Id}\nFull name: {student.FirstName} {student.SecondName}" +
                $"\nAge: {student.Age}\nAverage grade: {student.AverageGrade}\nGrant: {student.Grant}";
        }

        private static string GetSubjectInfo(List<Subject> subjects)
        {
            StringBuilder subjectsInfo = new ("\nSubjects:\n");
            if (subjects.Any())
            {
                foreach (Subject subject in subjects)
                {
                    string subjectItem = $" - {subject.Name}, Grade: {subject.Grade}, Date: {subject.Date.ToShortDateString()}.\n";
                    subjectsInfo.Append(subjectItem);
                }
            }
            else
            {
                subjectsInfo.Append(ErrorMessages.EmptySubjectsList);
            }

            return subjectsInfo.ToString();
        }
    }
}