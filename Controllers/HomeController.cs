// using Microsoft.AspNetCore.Mvc;
// using BankAccManagerApp.Models;

// namespace BankAccManagerApp.Controllers
// {
//     public class HomeController : Controller
//     {
//         private static Account userAccount = new Account("1234", 1000m);

//         public IActionResult Index()
//         {
//             return View(userAccount);
//         }

//         [HttpPost]
//         public IActionResult Deposit(decimal amount, string currency)
//         {
//             try
//             {
//                 var selectedCurrency = Currency.FromCode(currency);
//                 userAccount.Deposit(amount, selectedCurrency);
//                 return Json(new { balance = userAccount.Balance.ToString("C") });
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, ex.Message);
//             }
//         }

//         // [HttpPost]
//         // public IActionResult Withdraw(decimal amount, string currency)
//         // {
//         //     try
//         //     {
//         //         var selectedCurrency = Currency.FromCode(currency);
//         //         userAccount.Withdraw(amount, selectedCurrency);
//         //         return Json(new { balance = userAccount.Balance.ToString("C") });
//         //     }
//         //     catch (InvalidOperationException ex)
//         //     {
//         //         return BadRequest("Insufficient funds. Please check your balance and try again.");
//         //     }
//         //     catch (Exception ex)
//         //     {
//         //         return StatusCode(500, "An unexpected error occurred. Please try again.");
//         //     }
//         // }
//         [HttpPost]
//         public IActionResult Withdraw(decimal amount, string currency)
//         {
//             var selectedCurrency = Currency.FromCode(currency);
//             try
//             {
//                 userAccount.Withdraw(amount, selectedCurrency);
//             }
//             catch (InvalidOperationException ex)
//             {
//                 // Handle the case where there's an insufficient balance
//                 TempData["ErrorMessage"] = ex.Message;
//             }
//             return RedirectToAction("Index");
//         }

//     }
// }

using Microsoft.AspNetCore.Mvc;
using BankAccManagerApp.Models;

namespace BankAccManagerApp.Controllers
{
    public class HomeController : Controller
    {
        private static Account userAccount = new Account("1234", 1000m);

        [HttpPost]
        public IActionResult Deposit(decimal amount, string currency)
        {
            var selectedCurrency = Currency.FromCode(currency);
            userAccount.Deposit(amount, selectedCurrency);
            return Json(new { balance = userAccount.Balance.ToString("C") });
        }

        [HttpPost]
        public IActionResult Withdraw(decimal amount, string currency)
        {
            var selectedCurrency = Currency.FromCode(currency);
            try
            {
                userAccount.Withdraw(amount, selectedCurrency);
                return Json(new { balance = userAccount.Balance.ToString("C") });
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return Json(new { error = TempData["ErrorMessage"] });
            }
        }

        public IActionResult Index()
        {
            return View(userAccount);
        }
    }
}
