using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_Group3.Models;
using WebLibrary.DAO;
using WebLibrary.Models;
using WebLibrary.Repository;


namespace Project_Group3.Controllers
{
    public class InstructorController : Controller
    {
       IInstructorRepository instructorRepository = null;
        public InstructorController() => instructorRepository = new InstructorRepository();

        public IActionResult Index()
        {
            var instructorList = instructorRepository.GetInstructors();
            return View(instructorList);
        }

        public IActionResult Details(int? id)
        {
            if(id == null){
                return NotFound();
            }
            var instructor = instructorRepository.GetInstructorByID(id.Value);
            if(instructor == null){
                return NotFound();
            }
            return View(instructor);
        }   
        
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instructor instructor){
            try{
                if(ModelState.IsValid){
                    instructorRepository.InsertInstructor(instructor);
                }
                return RedirectToAction(nameof(Index));
            }catch(Exception ex){
                ViewBag.Message = ex.Message;
                return View(instructor);
            }
        }

        public IActionResult Edit(int? id)
        {
            if(id == null){
                return NotFound();
            }
            var instructor = instructorRepository.GetInstructorByID(id.Value);
            if(instructor == null){
                return NotFound();
            }
            return View(instructor);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Instructor instructor){
            try{
                if(id != instructor.InstructorId){
                    return NotFound();
                }
                if(ModelState.IsValid){
                    instructorRepository.UpdateInstructor(instructor);
                }
                return RedirectToAction(nameof(Index));
            }catch(Exception ex){
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public IActionResult Delete(int? id)
        {
            if(id == null){
                return NotFound();
            }
            var instructor = instructorRepository.GetInstructorByID(id.Value);
            if(instructor == null){
                return NotFound();
            }
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id){
            try{
                instructorRepository.DeleteInstructor(id);
                return RedirectToAction(nameof(Index));
            }catch(Exception ex){
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}