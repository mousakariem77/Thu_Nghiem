using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.DAO
{
    public class InstructorDAO
    {
        private static InstructorDAO instance = null;
        private static readonly object instanceLock = new object();
        public static InstructorDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new InstructorDAO();

                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Instructor> GetInstructorlist()
        {
            var isntructors = new List<Instructor>();
            try
            {
                using var context = new DBContext();
                isntructors = context.Instructors.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

                throw;
            }
            return isntructors;
        }
        public Instructor GetInstructorByID(int isntructorID)
        {
            Instructor isntructor = null;
            try
            {
                using var context = new DBContext();
                isntructor = context.Instructors.SingleOrDefault(p => p.InstructorId == isntructorID);

            }
            catch (System.Exception)
            {

                throw;
            }
            return isntructor;
        }
        public void AddNew(Instructor isntructor)
        {
            try
            {
                Instructor existingInstructor = GetInstructorByID(isntructor.InstructorId);
                if (existingInstructor == null)
                {
                    using (var context = new DBContext())
                    {
                        context.Instructors.Add(isntructor);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The isntructor already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Instructor isntructor)
        {
            try
            {
                Instructor existingInstructor = GetInstructorByID(isntructor.InstructorId);
                if (existingInstructor != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Instructors.Update(isntructor);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The isntructor does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(int isntructorID)
        {
            try
            {
                Instructor isntructor = GetInstructorByID(isntructorID);
                if (isntructor != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Instructors.Remove(isntructor);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The isntructor does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}