using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BulkyBook.DataAccess;
using BulkyBook.Models;
using BulkyBook.DataAccess.Repository.IRepository;

namespace BulkyBookWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();

        return View(objCategoryList);
    }
    // GET
    public IActionResult Create()
    {

        return View();
    }
    //POST
    [HttpPost] // need everytime we make a post method
    [ValidateAntiForgeryToken] // adds and validation key to any form sent from the object to make sure that you cant enter the form from typing the url and uses cookies to do so
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("CustomError", "The Display order cannot match the Name"); // if i wanna make the error show up under name i can just replace CustomError with name
        }
        if (ModelState.IsValid) // this checks of the input of data is coherent with the model 
        {
            _unitOfWork.Category.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully"; // only stays in memory for one redirect
            return RedirectToAction("Index"); // if i wanna redirect to an action in another controller i can add a comma and then the name of the controller afterwards
        }
        return View(obj);
    }

    // GET
    public IActionResult Edit(int? id) // this takes an int and thats is id at based on the id it shows the one u r editing
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        // these are 3 different ways of retriving a category based on id, but we will be using the find one
        //var categoryFromDb = _db.Categories.Find(id);
        var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
        // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        if (categoryFromDbFirst == null)
        {
            return NotFound();
        }
        return View(categoryFromDbFirst);
    }
    //POST
    [HttpPost] // need everytime we make a post method
    [ValidateAntiForgeryToken] // adds and validation key to any form sent from the object to make sure that you cant enter the form from typing the url and uses cookies to do so
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("CustomError", "The Display order cannot match the Name"); // if i wanna make the error show up under name i can just replace CustomError with name
        }
        if (ModelState.IsValid) // this checks of the input of data is coherent with the model 
        {
            _unitOfWork.Category.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category edited successfully";
            return RedirectToAction("Index"); // if i wanna redirect to an action in another controller i can add a comma and then the name of the controller afterwards
        }
        return View(obj);

    }
    // GET
    public IActionResult Delete(int? id) // this takes an int and thats is id at based on the id it shows the one u r editing
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        // these are 3 different ways of retriving a category based on id, but we will be using the find one
        //var categoryFromDb = _db.Categories.Find(id);
        var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
        // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        if (categoryFromDbFirst == null)
        {
            return NotFound();
        }
        return View(categoryFromDbFirst);
    }
    //POST
    [HttpPost] // need everytime we make a post method
    [ValidateAntiForgeryToken] // adds and validation key to any form sent from the object to make sure that you cant enter the form from typing the url and uses cookies to do so
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.Category.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index"); // if i wanna redirect to an action in another controller i can add a comma and then the name of the controller afterwards
    }
}
