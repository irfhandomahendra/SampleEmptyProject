using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleEmptyProject.DAL;
using SampleEmptyProject.Models;
using System;

namespace SampleEmptyProject.Controllers
{
    public class StudentController : Controller
    {
        private IStudentDAL _studentDAL;
        public StudentController(IStudentDAL studentDAL)
        {
            _studentDAL = studentDAL;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var results = _studentDAL.GetAll();
            string strStudent = string.Empty;
            foreach (var student in results)
            {
                strStudent += $"{student.FirstName} {student.LastName} \n";
            }

            return Content(strStudent);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var result = _studentDAL.GetById(id);
            return Content($"{result.FirstName} {result.LastName} {result.EnrollmentDate}");
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            try
            {
                Student student = new Student
                {
                    FirstName = "Peter",
                    LastName = "Parker",
                    EnrollmentDate = System.DateTime.Now
                };
                _studentDAL.Insert(student);
                return Content("data berhasil ditambah");
            }
            catch (System.Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Student student = new Student
                {
                    ID = id,
                    FirstName = "Clark",
                    LastName = "Kent",
                    EnrollmentDate = DateTime.Now
                };
                _studentDAL.Update(student);
                return Content("Data berhasil diupdate");
            }
            catch (System.Exception ex)
            {

                return Content(ex.Message);
            }
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _studentDAL.Delete(id.ToString());
                return Content("data berhasil didelete");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}