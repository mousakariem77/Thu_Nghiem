using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public interface IInstructorRepository
    {
        IEnumerable<Instructor> GetInstructors();
        Instructor GetInstructorByID(int instructorId);
        void InsertInstructor(Instructor instructor);
        void DeleteInstructor(int instructorId);
        void UpdateInstructor(Instructor instructor);
    }
}