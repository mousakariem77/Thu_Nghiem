using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.DAO;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        public Instructor GetInstructorByID(int instructorId) => InstructorDAO.Instance.GetInstructorByID(instructorId);
        public IEnumerable<Instructor> GetInstructors() => InstructorDAO.Instance.GetInstructorlist();
        public void InsertInstructor(Instructor instructor) => InstructorDAO.Instance.AddNew(instructor);
        public void DeleteInstructor(int instructorId) => InstructorDAO.Instance.Remove(instructorId);
        public void UpdateInstructor(Instructor instructor) => InstructorDAO.Instance.Update(instructor); 
    }
}