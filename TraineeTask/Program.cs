using TraineeTask;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<Subject> subjects = Subject.Fill(Constants.FileSubjectsPath);
            List<Student> students = Student.Fill(Constants.FileStudentsPath);

            students.ForEach(student =>
            {
                if (student.SetSubjects(subjects))
                {
                    student.CalculateAverageGrade();
                    student.SetGrant();
                }
            });

            DisplayService.DisplayInfo(students, 1); // Info about student with Id=1
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Input error in data: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Operation error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.GetType().Name} - {ex.Message}");
        }
    }
}