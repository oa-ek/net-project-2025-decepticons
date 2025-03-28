using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShubkivTour.Data;
using ShubkivTour.Models.Entity;
using System.Linq;

namespace ShubkivTour.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string sortOrder, int? categoryId, int? subCategoryId)
        {
            var products = _context.Products
                .Include(p => p.CategoryProduct)
                .ThenInclude(c => c.SubCategory)
                .Include(p => p.Brand)
                .AsQueryable();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryProductId == categoryId.Value);
            }

            if (subCategoryId.HasValue)
            {
                products = products.Where(p => p.CategoryProduct.SubCategoryId == subCategoryId.Value);
            }

            switch (sortOrder)
            {
                case "price_asc":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
            }

            ViewBag.Categories = new SelectList(_context.CategoryProducts, "Id", "Name", categoryId);
            ViewBag.SubCategories = new SelectList(_context.SubCategories, "Id", "Name", subCategoryId);
            ViewBag.SortOrder = sortOrder;

            // Перенаправляємо до вашої в'юшки з каталогу
            return View("CatalogLook", products.ToList());
        }

        public IActionResult Add()
        {
            ViewBag.Categories = new SelectList(_context.CategoryProducts, "Id", "Name");
            ViewBag.SubCategories = new SelectList(_context.SubCategories, "Id", "Name");
            ViewBag.Brands = new SelectList(_context.Brands, "Id", "Name");

            return View("CatalogAdd");
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                // Завантажуємо пов'язані об'єкти
                var category = _context.CategoryProducts.FirstOrDefault(c => c.Id == product.CategoryProductId);
                var subCategory = _context.SubCategories.FirstOrDefault(s => s.Id == product.CategoryProduct.SubCategoryId);
                var brand = _context.Brands.FirstOrDefault(b => b.Id == product.BrandId);

                if (category != null)
                {
                    product.CategoryProduct = category;
                }

                if (subCategory != null)
                {
                    product.CategoryProduct.SubCategory = subCategory;
                }

                if (brand != null)
                {
                    product.Brand = brand;
                }

                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("Index", new { sortOrder = ViewBag.SortOrder, categoryId = product.CategoryProductId, subCategoryId = product.CategoryProduct?.SubCategoryId });
            }

            ViewBag.Categories = new SelectList(_context.CategoryProducts, "Id", "Name", product.CategoryProductId);
            ViewBag.SubCategories = new SelectList(_context.SubCategories, "Id", "Name", product.CategoryProduct?.SubCategoryId);
            ViewBag.Brands = new SelectList(_context.Brands, "Id", "Name", product.BrandId);

            return View("CatalogAdd", product);
        }


        public IActionResult Edit(int id)
        {
            var product = _context.Products
                .Include(p => p.CategoryProduct)
                .ThenInclude(c => c.SubCategory)
                .FirstOrDefault(p => p.Id == id);

            if (product == null) return NotFound();

            ViewBag.Categories = new SelectList(_context.CategoryProducts, "Id", "Name", product.CategoryProductId);
            ViewBag.SubCategories = new SelectList(_context.SubCategories, "Id", "Name", product.CategoryProduct?.SubCategoryId);
            ViewBag.Brands = new SelectList(_context.Brands, "Id", "Name", product.BrandId);

            return View("CatalogEdit", product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index", new { sortOrder = ViewBag.SortOrder, categoryId = product.CategoryProductId, subCategoryId = product.CategoryProduct?.SubCategoryId });
            }

            ViewBag.Categories = new SelectList(_context.CategoryProducts, "Id", "Name", product.CategoryProductId);
            ViewBag.SubCategories = new SelectList(_context.SubCategories, "Id", "Name", product.CategoryProduct?.SubCategoryId);
            ViewBag.Brands = new SelectList(_context.Brands, "Id", "Name", product.BrandId);

            return View("CatalogEdit", product);
        }

        [HttpPost]
        public IActionResult Delete(int id, string sortOrder, int? categoryId, int? subCategoryId)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", new { sortOrder, categoryId, subCategoryId });
        }
    }
}
