using SampleEmptyProject.Models;
using System.Collections.Generic;

namespace SampleEmptyProject.DAL
{
    public interface IStudentDAL
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Insert(Student student);
        void Update(Student student);
        void Delete(string id);
    }
}